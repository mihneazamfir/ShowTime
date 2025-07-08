using System.ComponentModel.DataAnnotations;

namespace ShowTime.Entities
{
    public class Band
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Genre Genre { get; set; }

        public ICollection<Festival> Festivals { get; } = new List<Festival>();

        public ICollection<FestivalBand> FestivalBand { get; } = new List<FestivalBand>();
    }
}