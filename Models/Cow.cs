using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalterExercise.Models
{
    [Table("cows")]
    public class Cow
    {
        [Key]
        public Guid Id { get; set; }
        [Column("collarid")]
        public int CollarId { get; set; }
        [Column("cownumber")]
        public int CowNumber { get; set; }
        [NotMapped]
        public int Latitude { get; set; }
        [NotMapped]
        public int Longitude { get; set; }
    }
}
