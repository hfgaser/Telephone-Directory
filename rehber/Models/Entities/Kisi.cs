using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rehber.Models.Entities
{
    [Table("Kişiler")]
    public class Kisi
    {

        public int Id { get; set; }
        [DisplayName("Ad")]
        public string Ad { get; set; }


        [DisplayName("Soyad")]
        public string SoyAd { get; set; }

        [DisplayName("Telefon")]
        public string Telefon { get; set; }
        [DisplayName("Adres")]
        public string Adres { get; set; }


        [DisplayName("Email")]
        public string Email { get; set; }

        public int CurrentId { get; set; }

        [DisplayName("Şehir")]
        public int SehirId { get; set; }

        public Sehir Sehir { get; set; }

        
        

    }
}