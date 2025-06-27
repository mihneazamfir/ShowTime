using System.ComponentModel.DataAnnotations;

public class Band
{
    public Guid Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public Genre Genre { get; set; }

    public ICollection<Festival> Festivals { get; } = new List<Festival>();
}