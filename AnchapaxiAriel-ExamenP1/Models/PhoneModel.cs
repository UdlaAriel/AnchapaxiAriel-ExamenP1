using System.ComponentModel.DataAnnotations;

namespace AnchapaxiAriel_ExamenP1.Models
{
    public class PhoneModel
    {
        [Key]
        [Display(Name = "Phone Code")]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Model { get; set; }
        [Range(2000, 2100)]
        public int Year { get; set; }
        [Editable(true)]
        public float Price { get; set; }
    }
}
