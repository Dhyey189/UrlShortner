using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UrlShortener.Models;

namespace UrlShortener
{
    public class urlshortnercontext : DbContext
    {
        public urlshortnercontext() : base("name=urlshortner")
        {

        }
        public DbSet<urldata> urldata { get; set; }
    }
}