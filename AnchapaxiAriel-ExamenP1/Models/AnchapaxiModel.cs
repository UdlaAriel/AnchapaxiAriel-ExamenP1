using System.ComponentModel.DataAnnotations;

namespace AnchapaxiAriel_ExamenP1.Models
{
    public class AnchapaxiModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public bool IsStudent { get; set; }
        [Required]
        public DateOnly BirthDay { get; set; }
    }   
}
