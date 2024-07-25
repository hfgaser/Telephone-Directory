using rehber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rehber.Models.KullaniciModel
{
    public class KullaniciEkleViewModel
    {
        public List<Kullanici> Kullanicilar { get; set; }
        public List<Kisi> Kisiler{ get; set; }

    }
}