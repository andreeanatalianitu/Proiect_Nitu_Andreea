using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Nitu_Andreea.Models;

namespace Proiect_Nitu_Andreea.Data
{
    public class Proiect_Nitu_AndreeaContext : DbContext
    {
        public Proiect_Nitu_AndreeaContext (DbContextOptions<Proiect_Nitu_AndreeaContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Nitu_Andreea.Models.Zbor> Zbor { get; set; }
    }
}
