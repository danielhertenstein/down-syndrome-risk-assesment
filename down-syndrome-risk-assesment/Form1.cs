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
                    case "Yes":
                        echogenicFocusRatio = 5.83;
                        break;
                    case "No":
                        echogenicFocusRatio = 0.8;
                        break;
                    default:
                        echogenicFocusRatio = 1;
                        break;
                }
                echogenicFocusLabel.Text = echogenicFocusRatio.ToString();
            }
        }

        private void ventriculomegalyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                switch (comboBox.SelectedItem.ToString())
                {
                    case "Yes":
                        ventriculomegalyRatio = 27.52;
                        break;
                    case "No":
                        ventriculomegalyRatio = 0.94;
                        break;
                    default:
                        ventriculomegalyRatio = 1;
                        break;
                }
                ventriculomegalyLabel.Text = ventriculomegalyRatio.ToString();
            }
        }

        private void echogenicBowelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                switch (comboBox.SelectedItem.ToString())
                {
                    case "Yes":
                        echogenicBowelRatio = 11.44;
                        break;
                    case "No":
                        echogenicBowelRatio = 0.9;
                        break;
                    default:
                        echogenicBowelRatio = 1;
                        break;
                }
                echogenicBowelLabel.Text = echogenicBowelRatio.ToString();
            }
        }

        private void hydronephrosisList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                switch (comboBox.SelectedItem.ToString())
                {
                    case "Yes":
                        hydronephrosisRatio = 7.63;
                        break;
                    case "No":
                        hydronephrosisRatio = 0.92;
                        break;
                    default:
                        hydronephrosisRatio = 1;
                        break;
                }
                hydronephrosisLabel.Text = hydronephrosisRatio.ToString();
            }
        }

        private void legBoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                switch (comboBox.SelectedItem.ToString())
                {
                    case "Yes":
                        if (legBoneBox.SelectedItem.ToString() == "Short femur")
                            legBoneRatio = 3.72;
                        else
                            legBoneRatio = 4.81;
                        break;
                    case "No":
                        if (legBoneBox.SelectedItem.ToString() == "Short femur")
                            legBoneRatio = 0.8;
                        else
                            legBoneRatio = 0.74;
                        break;
                    default:
                        legBoneRatio = 1;
                        break;
                }
                legBoneLabel.Text = legBoneRatio.ToString();
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
                        case "Yes":
                            legBoneRatio = 3.72;
                            break;
                        case "No":
                            legBoneRatio = 0.8;
                            break;
                        default:
                            legBoneRatio = 1;
                            break;
                    }
                }
                else
                {
                    switch (legBoneList.SelectedItem.ToString())
                    {
                        case "Yes":
                            legBoneRatio = 4.81;
                            break;
                        case "No":
                            legBoneRatio = 0.74;
                            break;
                        default:
                            legBoneRatio = 1;
                            break;
                    }
                }
                legBoneLabel.Text = legBoneRatio.ToString();
            }
        }

        private void nasalBoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                switch (comboBox.SelectedItem.ToString())
                {
                    case "Yes":
                        nasalBoneRatio = 23.27;
                        break;
                    case "No":
                        nasalBoneRatio = 0.46;
                        break;
                    default:
                        nasalBoneRatio = 1;
                        break;
                }
                nasalBoneLabel.Text = nasalBoneRatio.ToString();
            }
        }

        private void UpdateLikelihoodRatio(object sender, EventArgs e)
        {
            double risk = ((double)ageRelatedRisk.Value / echogenicFocusRatio
                           / ventriculomegalyRatio / echogenicBowelRatio
                           / hydronephrosisRatio / legBoneRatio
                           / nasalBoneRatio);
            adjustedRisk.Text = risk.ToString("0.#####");

            double likelihood = (double)ageRelatedRisk.Value / risk;
            likelihoodRatio.Text = likelihood.ToString("0.#####");
        }
    }
}
