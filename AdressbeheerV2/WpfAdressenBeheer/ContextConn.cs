using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAdresBeheer {
    public class ContextConn : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                // ConnectionString www.connectionstrings.com
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True");
            }
        }

        public DbSet<Adres> Adres { get; set; }





    }
}
