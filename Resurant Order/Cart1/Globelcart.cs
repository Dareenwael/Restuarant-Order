using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cart1
{
    internal class Globelcart
    {
        private static List<Cartitem> cartitems = new List<Cartitem>();
        public List<Cartitem> getCart(int userId)
        {
            return cartitems.Where(e => e.UserId == userId).Select(c => { c.Item = ItemStore.GetItemFromList().FirstOrDefault(i => i.Id == c.ItemId); return c; }).ToList();//if user id eaqual to the users id i have it will get its item from list
        }

        public void AddToCart(int itemid, int userId)
        {
            var cartitem = new Cartitem { ItemId = itemid, UserId = userId };//adding item id and user id to the cart
            cartitems.Add(cartitem);
            
        }

        public void Removeitemfromcart(int userId,int ItemId)
        {
            var removeItem=cartitems.FirstOrDefault(cI => cI.UserId == userId && cI.ItemId == ItemId);
            cartitems.Remove(removeItem);
        }

        //public void RemoveAllitemfromcart(int userId, int ItemId)
        //{
        //    var removeItem = cartitems.Where(cI => cI.UserId == userId && cI.ItemId == ItemId);
        //    cartitems.Remove((Cartitem)removeItem);
        //}

        public void RemoveAllItemsFromCart(int userId, int itemId)
        {
            var itemsToRemove = cartitems.Where(cI => cI.UserId == userId && cI.ItemId == itemId).ToList();

            foreach (var itemToRemove in itemsToRemove)
            {
                cartitems.Remove(itemToRemove);
            }
        }

        public void IncreseQuantity(int userId, int ItemId)
        {
            var updateItem = cartitems.FirstOrDefault(cI => cI.UserId == userId && cI.ItemId == ItemId);
            cartitems.Remove(updateItem); //removed 
            //update quantity
            if (updateItem.Quantity < 0)
            {
                MessageBox.Show("Invalid quantity after increment.");
                // If the increment operation leads to a negative quantity, you can handle it here.
                // For example, you may want to set the quantity to 0 or take other appropriate action.
                updateItem.Quantity = 0;
            }
            updateItem.Quantity = updateItem.Quantity + 1;
                cartitems.Add(updateItem); // added with the new quantity
            
        }

        public void DecreaseQuantity(int userId, int ItemId)
        {
            var updateItem = cartitems.FirstOrDefault(cI => cI.UserId == userId && cI.ItemId == ItemId);
            cartitems.Remove(updateItem); //removed 
             //update quantity
            if (updateItem.Quantity <= 0)
            {
                MessageBox.Show("Cannot decrement. Quantity is already 0.");
            }
            else
            {
                updateItem.Quantity = updateItem.Quantity - 1;
                cartitems.Add(updateItem); // added with the new quantity
            }
        }
    }
}
