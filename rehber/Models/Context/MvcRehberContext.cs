using rehber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace rehber.Models.Context
{
    public class MvcRehberContext:DbContext
    {
        public MvcRehberContext():base("Server=DESKTOP-LC7JQ7I;Database=MvcRehberDB;Trusted_Connection=true")
        {

        }

        public DbSet<Kisi> Kisiler{ get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }


    }
}