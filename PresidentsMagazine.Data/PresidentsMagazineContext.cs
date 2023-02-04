using Microsoft.EntityFrameworkCore;
using PresidentsMagazine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresidentsMagazine.Data
{
    public class PresidentsMagazineContext :DbContext
    {
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<PresidentEntity> Presidents { get; set; }
        public DbSet<ContinentEntity> Continents { get; set; }
        public PresidentsMagazineContext(DbContextOptions<PresidentsMagazineContext> options) :base(options)
        {

        }
    }
}
