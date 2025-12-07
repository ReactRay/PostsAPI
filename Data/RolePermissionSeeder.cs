using Microsoft.AspNetCore.Identity;
using postsAPI.Permissions;
using System.Security.Claims;

namespace postsAPI.Data
{
    public static class RolePermissionSeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            // 1️⃣ Ensure roles exist
            var posterRole = await EnsureRole(roleManager, "Poster");
            var commenterRole = await EnsureRole(roleManager, "Commenter");

            // 2️⃣ Assign permissions to rolesz
            await AddPermissions(roleManager, posterRole, new[]
            {
                Permissions.Permissions.CreatePost,
                Permissions.Permissions.EditPost,
                Permissions.Permissions.DeletePost
            });

            await AddPermissions(roleManager, commenterRole, new[]
            {
               Permissions.Permissions.CreateComment,
               Permissions. Permissions.EditComment,
               Permissions. Permissions.DeleteComment
            });
        }

        private static async Task<IdentityRole> EnsureRole(
            RoleManager<IdentityRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                await roleManager.CreateAsync(role);
            }
            return role;
        }

        private static async Task AddPermissions(
            RoleManager<IdentityRole> roleManager,
            IdentityRole role,
            IEnumerable<string> permissions)
        {
            var existingClaims = await roleManager.GetClaimsAsync(role);

            foreach (var permission in permissions)
            {
                if (!existingClaims.Any(c =>
                        c.Type == "permission" && c.Value == permission))
                {
                    await roleManager.AddClaimAsync(
                        role,
                        new Claim("permission", permission)
                    );
                }
            }
        }
    }
}
