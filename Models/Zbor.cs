using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Nitu_Andreea.Models
{
    public class Zbor
    {
        public int ID { get; set; }
        [Required]
        public string Airline { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
