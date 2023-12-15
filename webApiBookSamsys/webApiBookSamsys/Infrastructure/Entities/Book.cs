using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace webApiBookSamsys.Infrastructure.Entities
{
    public class Book
    {
        internal string ErrorMessage;

        [Key]
        public long id { get; set; } 
        [Column(TypeName = "varchar (50)")]
        public string ISBN { get; set; }

        [Column(TypeName = "varchar (50)")]
        public string Name { get; set; }    

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public  string Color { get; set; }
        public decimal Weight { get; set; }


        public void UpdateBook(string name, decimal price, string color, decimal weight )   
        {
            Name = name;
            Price = price;
            Color = color;
            Weight = weight;
        }
    }

}