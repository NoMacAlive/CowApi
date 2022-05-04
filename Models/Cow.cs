using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CowApi.Models
{
    [Table("cows")]
    public class Cow
    {
        [Key, Column("id")]
        public Guid Id { get; set; }
        [Column("collarId")]
        public int CollarId { get; set; }
        [Column("cowNumber")]
        public int CowNumber { get; set; }
        [NotMapped]
        public int Latitude { get; set; }
        [NotMapped]
        public int Longitude { get; set; }
    }
}
