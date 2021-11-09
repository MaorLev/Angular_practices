using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Data.Entities
{
    [Table("Product")]
    public class Item
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Company")]
        public string CompanyName { get; set; }
        [Column("Count")]
        public int Count { get; set; }
        [Column("Serial")]
        public int Serial { get; set; }
        [Column("Active")]
        public bool Active { get; set; }
        [Column("Price")]
        public int Price { get; set; }
    }
}
