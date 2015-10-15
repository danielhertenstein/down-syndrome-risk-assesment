using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace down_syndrome_risk_assesment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            echogenicFocusList.SelectedItem = "Not Assessed";
            ventriculomegalyList.SelectedItem = "Not Assessed";
            echogenicBowelList.SelectedItem = "Not Assessed";
            hydronephrosisList.SelectedItem = "Not Assessed";
            legBoneList.SelectedItem = "Not Assessed";
            nasalBoneList.SelectedItem = "Not Assessed";
            bpdList.SelectedItem = "Not Assessed";
            nuchalFoldList.SelectedItem = "Not Assessed";
            legBoneBox.SelectedItem = "Short femur";
        }

        double echogenicFocusRatio;
        double ventriculomegalyRatio;
        double echogenicBowelRatio;
        double hydronephrosisRatio;
        double legBoneRatio;
        double nasalBoneRatio;

        private void echogenicFocusList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                switch (comboBox.SelectedItem.ToString())
                {
                    case "Not Assessed":
                        echogenicFocusRatio = 1;
                        echogenicFocusLabel.Text = echogenicFocusRatio.ToString();
                        break;
                    case "Yes":
                        echogenicFocusRatio = 5.83;
                        echogenicFocusLabel.Text = echogenicFocusRatio.ToString();
                        break;
                    case "No":
                        echogenicFocusRatio = 0.8;
                        echogenicFocusLabel.Text = echogenicFocusRatio.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void ventriculomegalyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                switch (comboBox.SelectedItem.ToString())
                {
                    case "Not Assessed":
                        ventriculomegalyRatio = 1;
                        ventriculomegalyLabel.Text = ventriculomegalyRatio.ToString();
                        break;
                    case "Yes":
                        ventriculomegalyRatio = 27.52;
                        ventriculomegalyLabel.Text = ventriculomegalyRatio.ToString();
                        break;
                    case "No":
                        ventriculomegalyRatio = 0.94;
                        ventriculomegalyLabel.Text = ventriculomegalyRatio.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void echogenicBowelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                switch (comboBox.SelectedItem.ToString())
                {
                    case "Not Assessed":
                        echogenicBowelRatio = 1;
                        echogenicBowelLabel.Text = echogenicBowelRatio.ToString();
                        break;
                    case "Yes":
                        echogenicBowelRatio = 11.44;
                        echogenicBowelLabel.Text = echogenicBowelRatio.ToString();
                        break;
                    case "No":
                        echogenicBowelRatio = 0.9;
                        echogenicBowelLabel.Text = echogenicBowelRatio.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void hydronephrosisList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                switch (comboBox.SelectedItem.ToString())
                {
                    case "Not Assessed":
                        hydronephrosisRatio = 1;
                        hydronephrosisLabel.Text = hydronephrosisRatio.ToString();
                        break;
                    case "Yes":
                        hydronephrosisRatio = 7.63;
                        hydronephrosisLabel.Text = hydronephrosisRatio.ToString();
                        break;
                    case "No":
                        hydronephrosisRatio = 0.92;
                        hydronephrosisLabel.Text = hydronephrosisRatio.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void legBoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                switch (comboBox.SelectedItem.ToString())
                {
                    case "Not Assessed":
                        legBoneRatio = 1;
                        legBoneLabel.Text = legBoneRatio.ToString();
                        break;
                    case "Yes":
                        if (legBoneBox.SelectedItem.ToString() == "Short femur")
                            legBoneRatio = 3.72;
                        else
                            legBoneRatio = 4.81;
                        legBoneLabel.Text = legBoneRatio.ToString();
                        break;
                    case "No":
                        if (legBoneBox.SelectedItem.ToString() == "Short femur")
                            legBoneRatio = 0.8;
                        else
                            legBoneRatio = 0.74;
                        legBoneLabel.Text = legBoneRatio.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void legBoneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                if (comboBox.SelectedItem.ToString() == "Short femur")
                {
                    switch (legBoneList.SelectedItem.ToString())
                    {
                        case "Not Assessed":
                            legBoneRatio = 1;
                            legBoneLabel.Text = legBoneRatio.ToString();
                            break;
                        case "Yes":
                            legBoneRatio = 3.72;
                            legBoneLabel.Text = legBoneRatio.ToString();
                            break;
                        case "No":
                            legBoneRatio = 0.8;
                            legBoneLabel.Text = legBoneRatio.ToString();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (legBoneList.SelectedItem.ToString())
                    {
                        case "Not Assessed":
                            legBoneRatio = 1;
                            legBoneLabel.Text = legBoneRatio.ToString();
                            break;
                        case "Yes":
                            legBoneRatio = 4.81;
                            legBoneLabel.Text = legBoneRatio.ToString();
                            break;
                        case "No":
                            legBoneRatio = 0.74;
                            legBoneLabel.Text = legBoneRatio.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void nasalBoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                switch (comboBox.SelectedItem.ToString())
                {
                    case "Not Assessed":
                        nasalBoneRatio = 1;
                        nasalBoneLabel.Text = nasalBoneRatio.ToString();
                        break;
                    case "Yes":
                        nasalBoneRatio = 23.27;
                        nasalBoneLabel.Text = nasalBoneRatio.ToString();
                        break;
                    case "No":
                        nasalBoneRatio = 0.46;
                        nasalBoneLabel.Text = nasalBoneRatio.ToString();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
