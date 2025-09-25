namespace Learn.Csharp.Week2.Solution.Api.Domain
{
    public class Blog
    {
        public long BlogId { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; } = new();
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }

    }
}
