using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnchapaxiAriel_ExamenP1.Models
{
    public class AnchapaxiModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(0, 100)]
        public int Age { get; set; }
        public float MoneyInTheBank { get; set; }
        public bool IsStudent { get; set; }
        [Required]
        public DateOnly BirthDay { get; set; }
        [ForeignKey(nameof(PhoneModel))]
        public int idPhone { get; set; }
        public PhoneModel? Phone { get; set; }
    }   
}
