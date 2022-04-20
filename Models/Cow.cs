using System;
using System.ComponentModel.DataAnnotations;

namespace HalterExercise.Models
{
    public class Cow
    {
        [Key]
        public Guid Id { get; set; }
        public int CollarId { get; set; }
        public int CowNumber { get; set; }

        public Location LastLocation { get; set; }
    }
}
