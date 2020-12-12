using NGLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Binding.Models
{
    public class Db : DbContext
    {
        public DbSet<Users> users { get; set; }
    }
}