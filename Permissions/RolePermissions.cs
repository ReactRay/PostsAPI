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
                    Permissions.CreatePost,
                    Permissions.EditPost,
                    Permissions.DeletePost
                }
            },
            {
                "Commenter",
                new[]
                {
                    Permissions.CreateComment,
                    Permissions.EditComment,
                    Permissions.DeleteComment
                }
            }
        };
    }
}
