using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cart1
{
    public partial class Receipt : Form
    {
        public int FormWidth { get; set; }
        public Receipt()
        {
            InitializeComponent();
            FormWidth = Width;
        }

        private void Receipt_Load(object sender, EventArgs e)
        {

            List<Cartitem> cartitems = new Globelcart().getCart(0); // 0 is for testing ya dodo change it with the userid later.
                                                                    //get user cart
                                                                    //get items with the cart item ids
            var itemWidth = 100;
            var itemHeight = 50;
            int levelMaxItems = FormWidth / itemWidth; //number of items in a row
            for (int i = 0; i < cartitems.Count; i++)
            {
                var xDistance = (10 * ((i % levelMaxItems) + 1)) + itemWidth * (i % levelMaxItems);
                var level = (i / levelMaxItems); // row level

                var yDistance = (10 * (level + 1)) + itemHeight * level;
                draw_Cartblock(xDistance, yDistance, itemWidth, itemHeight, cartitems[i].Item, cartitems[i].Quantity);
            }
        }
        private void draw_Cartblock(int x, int y, int width, int height, Item item, int quantity)
        {
            var distance = y;



            var name = new Label();

            name.Location = new Point(x, distance);
            var nameHeight = 24;
            var nameWidtht = 21;
            // label.Size = new Size(labelHeight, labelWidtht);
            name.Text = item.Name;
            Controls.Add(name);

            distance += nameHeight;

            var price = new Label();

            price.Location = new Point(x, distance);
            var priceHeight = 24;
            var priceWidtht = 21;
            // label.Size = new Size(labelHeight, labelWidtht);
            price.Text = item.Price.ToString();
            Controls.Add(price);
           
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
          foreach (Control control in Controls)
    {
        if (control is Label)
        {
            // Remove the label from the form
            Controls.Remove(control);
           control.Dispose(); // Dispose the label to release resources
        }
    }

            foreach (Control control in Controls)
            {
                if (control is Label)
                {
                    // Remove the label from the form
                    Controls.Remove(control);
                    control.Dispose(); // Dispose the label to release resources
                }
            }

            foreach (Control control in Controls)
            {
                if (control is Label)
                {
                    // Remove the label from the form
                    Controls.Remove(control);
                    control.Dispose(); // Dispose the label to release resources
                }
            }
        }
    }
}
