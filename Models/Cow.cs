using HalterExercise.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalterExercise.Models
{
    public class Cow
    {
        public Guid Id { get; set; }
        public int CollarId { get; set; }
        public int CowNumber { get; set; }

        public CollarStatus CollarStatus { get; set; }

        public Location LastLocation { get; set; }
    }
}
