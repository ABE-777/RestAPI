using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL
{
    public class PasteDBContext : DbContext
    {
        public PasteDBContext() : base("PasteDB")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }


        public DbSet<Paste> Pastes { get; set; }
    }
}
