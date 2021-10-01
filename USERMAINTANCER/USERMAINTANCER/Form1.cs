using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USERMAINTANCER.Entities;
using System.Windows.Forms;

namespace USERMAINTANCER
{


    

    public partial class Form1 : Form
        {
        BindingList<User> users = new BindingList<User>();

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                LastName = label1.Text,
                FirstName = label2.Text
            };
            users.Add(u);
        }

        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.LastName; // label1
            label2.Text = Resource1.FirstName; // label2
            button1.Text = Resource1.Add; // button1

            // listbox1
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }



        



        

        
    }
}
