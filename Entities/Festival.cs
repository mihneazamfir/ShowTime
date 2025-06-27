using System.ComponentModel.DataAnnotations;

public class Festival
{
    public Guid Id { get; set; }
    [MaxLength(100)]
    public string Location { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    public ICollection<Band> Bands { get; } = new List<Band>();
    public ICollection<Booking> Bookings { get; } = new List<Booking>();
}