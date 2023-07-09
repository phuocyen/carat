using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DoAN.Models
{
    public class Nhasx
    {
        [Key]
        public int IdNhasx {get;set;}

        public string Name { get; set; }

    }
}