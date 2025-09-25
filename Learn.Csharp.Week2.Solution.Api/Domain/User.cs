namespace Learn.Csharp.Week2.Solution.Api.Domain
{
    public class User
    {
        public long UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }

        public List<Blog> Blogs { get; set; } = [];
    }
}
