using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR9
{
    public partial class MainForm : Form
    {
        private List<Car> mCarsList;

        public MainForm()
        {
            InitializeComponent();
            mCarsList = new List<Car>();
        }

        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar != (char)Keys.Enter)
            {
                return;
            }

            if(!Utils.IsNumberValid(numTextBox.Text))
            {
                return;
            }

            mCarsList.Add(new Car(numberTextBox.Text));
        }
    }
}
