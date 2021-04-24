using MenuItemListing.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MenuItemListing.Models.DataManager
{
    public class MenuManager : IDataRepository<MenuItem>
    {
        readonly MenuItemContext _context;
        public  MenuManager(MenuItemContext context)
        {
            _context = context;
        }
        public MenuItem Get(int id)
        {
            return _context.MenuItems.FirstOrDefault(e => e.Id == id);
           
        }

        public IEnumerable<MenuItem> GetAll()
        {
            MenuItem m1 = new MenuItem() {
                Name = "Pizza",
                FreeDelivery = true,
                Price = 120,
                DateOfLaunch = new DateTime(2021,01,03),
                Active = true
            };
            MenuItem m2 = new MenuItem() {
                Name = "Burger",
                FreeDelivery = true,
                Price = 80,
                DateOfLaunch = new DateTime(2021,04,03),
                Active = true
            };
            _context.Add(m1);
            _context.Add(m2);
            _context.SaveChanges();

            return _context.MenuItems.ToList();
        }
    }
}
