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

            ChangeStateOfGroupBoxControls(false);
        }

        private void UpdateListBox()
        {
            numbersListBox.Items.Clear();
            mCarsList.ForEach(carInfo => numbersListBox.Items.Add(carInfo.mNumber));
        }

        private void ChangeStateOfGroupBoxControls(bool isEnabled)
        {
            numTextBox.Enabled = isEnabled;
            modelTextBox.Enabled = isEnabled;
            colorComboBox.Enabled = isEnabled;
            fioTextBox.Enabled = isEnabled;

            saveButton.Enabled = isEnabled;
            revertButton.Enabled = isEnabled;
        }

        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar != (char)Keys.Enter)
            {
                return;
            }

            if(!Utils.IsNumberValid(numberTextBox.Text))
            {
                return;
            }

            if (mCarsList.Any(carInfo => carInfo.mNumber == numberTextBox.Text))
            {
                return;
            }

            mCarsList.Add(new Car(numberTextBox.Text));
            UpdateListBox();
        }

        private void numbersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(numbersListBox.SelectedIndex == -1)
            {
                ChangeStateOfGroupBoxControls(false);
                return;
            }
            ChangeStateOfGroupBoxControls(true);

            var carInfo = mCarsList.ElementAt(numbersListBox.SelectedIndex);
            numTextBox.Text = carInfo.mNumber;
            modelTextBox.Text = carInfo.mModel;
            colorComboBox.Text = Utils.ConvertColorToString(carInfo.mColor);
            fioTextBox.Text = carInfo.mFio;
        }
    }
}
