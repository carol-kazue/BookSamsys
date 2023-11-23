﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;

namespace webApiBookSamsys.Infrastructure.Entities
{
    public class Book
    {

        [Key]
        public long id { get; set; } 
        [Column(TypeName = "varchar (50)")]
        public string ISBN { get; set; }

        [Column(TypeName = "varchar (50)")]
        public string Name { get; set; }    

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }

}