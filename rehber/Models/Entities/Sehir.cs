using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rehber.Models.Entities
{
    [Table("Şehirler")]
    public class Sehir
    {
        public int Id{ get; set; }
        public string SehirAdi { get; set; }

        public int PlakaKodu { get; set; }


    }
}