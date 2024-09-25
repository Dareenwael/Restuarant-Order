using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart1
{
    internal class ItemStore
    {
        static List<Item> items = new List<Item> //list will have multiple of objects each object have its property, will be added from db
        {

             new Item
            {
                Id = 0,
                Name = "CheeseCake",
                Quantity = 2,
                Price = 1,
                PicturePath="C:/Users/Dareen/Desktop/Bts/Cart123/Cart1/Cart1/Resources/Triple-Berry-No-Bake-Cheesecake_EXPS_TOHcom19_138951_B01_30_6b.jpg"//Change it to your own path
                //Pictures in Resources Folder
            },
             new Item
            {
                Id = 1,
                Name = "StrawberryTart",
                Quantity = 1,
                Price = 3,
                PicturePath="C:/Users/Dareen/Desktop/Bts/Cart123/Cart1/Cart1/Resources/R (2).jpeg"



            },
              new Item
            {
                Id = 2,
                Name = "Pizza",
                Quantity = 3,
                Price = 4,
                PicturePath="C:/Users/Dareen/Desktop/Bts/Cart123/Cart1/Cart1/Resources/R.jpeg"



            },
              new Item
            {
                Id = 3,
                Name = "Burger",
                Quantity = 2,
                Price = 1,
               PicturePath= "C:/Users/Dareen/Desktop/Bts/Cart123/Cart1/Cart1/Resources/OIP (1).jpeg"


            },

        };
        public static List<Item> GetItemFromList()
        {
            return items;
        }

        public static List<Item> SearchFromList(string key)
        {
            return items.Where(item => item.Name.Contains(key)).ToList();
        }


        public static void AddItemToList(Item item)
        {
            items.Add(item);
        }
    }  
}
