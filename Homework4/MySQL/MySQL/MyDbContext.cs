using System;
using System.Data.Entity;

namespace MySQL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DbConnectionString")
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }

        public DbSet<Server> Servers { get; set; }
        
    }
}
