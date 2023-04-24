using Project.ENTITIES.Models;
using Project.MAP.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.ContextClasses
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PartyMap());
            modelBuilder.Configurations.Add(new VoteMap());
            modelBuilder.Configurations.Add(new ProvinceMap());
        }

        public DbSet<Party> Parties { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Vote> Vote { get; set; }
    }
}
