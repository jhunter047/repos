using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uncloseable_Textbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Hides the form and doesnt show a icon in the task bar 
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            //Simple var 
            var a = 2;

            //Infinite loop
            while (a == 2)
            {
                foo();
            }
        }

        //Function to show a message box to the screen
        public void foo()
        {
            MessageBox.Show("Foo");

        }
    }
}
