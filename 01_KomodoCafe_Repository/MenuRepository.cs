using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repository
{
    public class MenuRepository
    {
        //GithubTest
        private List<Menu> _listofitems = new List<Menu>();
        //Create a menu item 
        public void CreateMenuItem(Menu item)
        {
            _listofitems.Add(item);
        }
        //Read a menu item 
        public List<Menu> ReadMenuItem()
        {
            return _listofitems;
        }
        //Update a menu item 
        public bool UpdateMenuItem(string originalOrderName, Menu newItemName)
        {
            //find the item
            Menu oldItemName = ReadMenuItemByName(originalOrderName);
            //update the item
            if (oldItemName != null)
            {
                oldItemName.ItemName = newItemName.ItemName;
                return true;
            }
            return false;
        }
        //Delete a menu item 
        public bool DeleteMenuItem(string ordername)
        {
            Menu item = ReadMenuItemByName(ordername);
            if (item == null)
            {
                return false;
            }
            int initialCount = _listofitems.Count;
            _listofitems.Remove(item);
            if (initialCount > _listofitems.Count)
                return true;
            else
                return false;
        }
        //Helper Method
        public Menu ReadMenuItemByName(string ordername)
        {
            foreach (Menu item in _listofitems)
            {
                if (item.ItemName.ToLower() == ordername.ToLower())

                    return item;
            }
            return null;
        }
    }
}
