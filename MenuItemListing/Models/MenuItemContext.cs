using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuItemListing.Models
{
    public class MenuItemContext : DbContext
    {
        public MenuItemContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<MenuItem> MenuItems { get; set; }
        
    }
}
