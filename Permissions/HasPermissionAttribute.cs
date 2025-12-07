using Microsoft.AspNetCore.Authorization;

namespace postsAPI.Permissions
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(string permission)
        {
            Policy = permission;
        }
    }
}
