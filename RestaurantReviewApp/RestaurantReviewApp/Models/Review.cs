using Microsoft.AspNetCore.Routing.Constraints;

public class Review
{
    public string Reviewer { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
}