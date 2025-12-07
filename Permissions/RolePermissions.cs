namespace postsAPI.Permissions
{
    public static class RolePermissions
    {
        public static readonly Dictionary<string, string[]> PermissionsByRole
            = new()
        {
            {
                "Poster",
                new[]
                {
                    AppPermissions.CreatePost,
                    AppPermissions.EditPost,
                    AppPermissions.DeletePost,
                    AppPermissions.GetPost
                }
            },
            {
                "Commenter",
                new[]
                {
                    AppPermissions.CreateComment,
                    AppPermissions.EditComment,
                    AppPermissions.DeleteComment,
                    AppPermissions.GetComment
                }
            }
        };
    }
}
