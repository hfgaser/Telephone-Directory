using rehber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rehber.Models.KisiModel
{
    public class KisiEkleViewModel
    {
        public Kisi Kisi{ get; set; }
        public List<Sehir> Sehirler { get; set; }
        public List<Kullanici> Kullanicilar { get; set; }


    }
}