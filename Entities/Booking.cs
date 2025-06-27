using System.ComponentModel.DataAnnotations;

public class Booking
{
    public Guid Id { get; set; }
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    [Required]
    public DateTime Date { get; set; }
    public Guid FestivalId { get; set; }
    public Festival Festival { get; set; } = null!;
}