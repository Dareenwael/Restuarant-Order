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
    public partial class Itemsmenu : Form
    {
        public int FormWidth { get; set; }

        List<Item> items = ItemStore.GetItemFromList();
        string searchQuery = ""; //used to save the search bar from clearing
        public Itemsmenu()
        {
            InitializeComponent();
            FormWidth = Width;
        }

        private void Itemsmenu_Load(object sender, EventArgs e)
        {

            render(items);


        }

        void render (List<Item> renderedItems)
        {
            var itemWidth = 240;
            var itemHeight = 250;
            int levelMaxItems = FormWidth / itemWidth; //number of items in a row

            //draw items
            for (int i = 0; i < renderedItems.Count; i++)
            {
                var xDistance = (10 * ((i % levelMaxItems) + 1)) + itemWidth * (i % levelMaxItems);
                var level = (i / levelMaxItems); // row level

                var yDistance = (10 * (level + 1)) + itemHeight * level;
                draw_block(xDistance, yDistance+20, itemWidth, itemHeight, renderedItems[i]);
            }

            //draw text box and to to cart button
            var goToCart = new Button();
            goToCart.Location = new Point(Width - 100, 0);
            goToCart.Text = "Go To Cart";
            goToCart.Click += button1_Click;

            Controls.Add(goToCart);

            var search = new TextBox();
            search.Location = new Point(Width - 200, 0);
            search.Text = searchQuery;
            search.TextChanged += textBox1_TextChanged;
            Controls.Add(search);
        }

        private void draw_block(int x, int y,int width, int height, Item item)
        {
            var distance = y;

            var picture = new PictureBox();
            picture.Location = new Point(x, distance);//position
            var pictureHeight = 180;
            var pictureWidth = width;
            picture.Size = new Size(pictureWidth, pictureHeight);
            //controls can be used to add new blocks to the form page
            picture.BackColor = Color.White;

            if (item.PicturePath != null)
            {
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                MyImage = new Bitmap(item.PicturePath);
                picture.ClientSize = new Size(width, pictureHeight);
                picture.Image = (Image)MyImage;
            }




            Controls.Add(picture);


            distance += pictureHeight;

            var name= new Label();

            name.Location = new Point(x, distance);
            var nameHeight = 24;
            var nameWidtht = 21;
           // label.Size = new Size(labelHeight, labelWidtht);
            name.Text = item.Name;
            Controls.Add(name);

            distance += nameHeight;

            var price= new Label();
            
            price.Location = new Point(x, distance);
            var priceHeight = 24;
            var priceWidtht = 21;
           // label.Size = new Size(labelHeight, labelWidtht);
            price.Text = item.Price.ToString();
            Controls.Add(price);
        
            distance += priceHeight;

            var button= new Button();
            button.Location = new Point(x, distance);
            var buttonHeight = 23;
            var buttonWidht = 75;
            button.Text = "Add to cart";
            button.Name = item.Id.ToString(); //to pass through the button event
            button.Click += AddTOCartButton_Click;
            Controls.Add(button);
            Show();
        }

        private void AddTOCartButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var itemid = int.Parse( button.Name);
            Globelcart globelcart = new Globelcart();
            globelcart.AddToCart(itemid, 0);//0 is user id
            

        }

        private void button1_Click(object sender, EventArgs e)//this is go to cart button that i will click it to go to user cart
        {
            var form = new UserCart();
            form.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;
            var list = ItemStore.SearchFromList(textbox.Text);
            searchQuery = textbox.Text;
            Controls.Clear(); // removes all the controls to rerender them

            render(list);

        }

        private Bitmap MyImage;
      

    }
}
