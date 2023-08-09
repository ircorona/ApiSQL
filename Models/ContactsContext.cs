using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiSQLPlatzi.Models
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions options) : base(options)
        {            
        }

            public DbSet<Contacts> Contacts { get; set; }

    }
}
