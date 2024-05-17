namespace Dev.Plugin.Blog.Core.Domain;

public class Author
{
    /// <summary>
    /// maybe same with User.Id
    /// </summary>
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}
