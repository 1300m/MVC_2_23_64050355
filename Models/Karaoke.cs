using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCTest.Models
{
    public class Karaoke
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Song name")]
        public string SongName { get; set; }

        [Required]
        [DisplayName("Song duration")]
        public int SongDuration { get; set; }

        [Required]
        [DisplayName("Singer number1")]
        public string Singer1 { get; set; }

        [DisplayName("Singer number2")]
        public string Singer2 { get; set; }

        [DisplayName("Singer number3")]
        public string Singer3 { get; set; }

        [DisplayName("Karaoke score")]
        public double Score { get; set; }
    }
}
