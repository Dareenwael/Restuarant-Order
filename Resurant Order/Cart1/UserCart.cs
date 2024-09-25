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
    public partial class UserCart : Form
    {
        public int FormWidth { get; set; }
      
        public UserCart()
        {
            InitializeComponent();
            FormWidth = Width;
        }

        private void UserCart_Load(object sender, EventArgs e)//draw items or get the block of items in menu and add it to usercart
        {
            List<Cartitem> cartitems = new Globelcart().getCart(0); // 0 is for testing change it with the userid later.
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

        private void Render()
        {
          List<Cartitem> cartitems = new Globelcart().getCart(0); // 0 is for testing  change it with the userid later.
                                                                              //get user cart
                                                                              //get items with the cart item ids
        var itemWidth = 240;
            var itemHeight = 250;
            int levelMaxItems = FormWidth / itemWidth; //number of items in a row
            for (int i = 0; i < cartitems.Count; i++)
            {
                var xDistance = (10 * ((i % levelMaxItems) + 1)) + itemWidth * (i % levelMaxItems);
                var level = (i / levelMaxItems); // row level

                var yDistance = (10 * (level + 1)) + itemHeight * level;
                draw_Cartblock(xDistance, yDistance, itemWidth, itemHeight, cartitems[i].Item, cartitems[i].Quantity);
            }

            this.Hide();
            new UserCart().Show();
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

            distance += priceHeight;

            var button = new Button();

            button.Location = new Point(x, distance);
            var buttonHeight = 23;
            var buttonWidht = 75;
            button.Text = "Remove from cart";// it will be shown remove because of the button widht and height i gave
            button.Name = item.Id.ToString(); //to pass through the button event
            button.Click += RemoveCartButton_Click;
            Controls.Add(button);

            distance += buttonHeight;

            var minusQuantityButton = new Button();
            minusQuantityButton.Location = new Point(x, distance);
            var minusHeight = 24;
            var minusWidth = 24;
            minusQuantityButton.Size = new Size(minusWidth, minusHeight);
            minusQuantityButton.Text = "-";
            minusQuantityButton.Name = item.Id.ToString(); //to pass through the button event
            minusQuantityButton.Click += decreaseQuantityButton_Click;
            Controls.Add(minusQuantityButton);


            var quantityLabel = new Label();

            quantityLabel.Location = new Point(x + minusHeight +10, distance+3);
            var quantityLabelHeight = 24;
            var quantityLabelwidth = 24;
            quantityLabel.Size = new Size(quantityLabelHeight, quantityLabelwidth);
            quantityLabel.Text = quantity.ToString();
            Controls.Add(quantityLabel);

         

            var AddQuantityButton = new Button();
            AddQuantityButton.Location = new Point(x + minusHeight + minusHeight + 10, distance);
            AddQuantityButton.Size = new Size(minusWidth, minusHeight);
            AddQuantityButton.Text = "+";
            AddQuantityButton.Name = item.Id.ToString(); //to pass through the button event
            AddQuantityButton.Click += increseQuantityButton_Click;
            Controls.Add(AddQuantityButton);

            Show();
        }

        private void RemoveCartButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var itemid = int.Parse(button.Name);
            Globelcart globelcart = new Globelcart();
            globelcart.Removeitemfromcart(0, itemid);
            //redraw window
            Render();
        }

        private void increseQuantityButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var itemid = int.Parse(button.Name);
            Globelcart globelcart = new Globelcart();
            globelcart.IncreseQuantity(0, itemid);
            //redraw window
            Render();
        }

        private void decreaseQuantityButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var itemid = int.Parse(button.Name);
            Globelcart globelcart = new Globelcart();
            globelcart.DecreaseQuantity(0, itemid);
            //redraw window
            Render();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Receipt receipt = new Receipt();
            receipt.Show();
        }
    }
}
