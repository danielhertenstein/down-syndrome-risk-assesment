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
            nasalBoneList.SelectedItem = "Not Assessed";
            bpdList.SelectedItem = "Not Assessed";
            nuchalFoldList.SelectedItem = "Not Assessed";

            legBoneList.SelectedItem = "Not Assessed";
            legBoneBox.SelectedItem = "Short femur";
            legBoneList.SelectedIndexChanged += legBoneList_SelectedIndexChanged;
            legBoneBox.SelectedIndexChanged += legBoneBox_SelectedIndexChanged;
        }

        double echogenicFocusRatio = 1;
        double ventriculomegalyRatio = 1;
        double echogenicBowelRatio = 1;
        double hydronephrosisRatio = 1;
        double legBoneRatio = 1;
        double nasalBoneRatio = 1;

        // All arrays must follow the pattern of { "Yes", "No", "Not Assessed" }
        // to mirror the pattern used by the DropDownLists.
        double[] echogenicFocusRatios = { 5.83, 0.8, 1 };
        double[] ventriculomegalyRatios = { 27.52, 0.94, 1 };
        double[] echogenicBowelsRatios = { 11.44, 0.9, 1 };
        double[] hydronephrosisRatios = { 7.63, 0.92, 1 };
        double[,] legBoneRatios = new double[2, 3] { { 3.72, 0.8, 1 }, { 4.81, 0.74, 1 } };

        private void echogenicFocusList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                echogenicFocusRatio = echogenicFocusRatios[comboBox.SelectedIndex];
                echogenicFocusLabel.Text = echogenicFocusRatio.ToString();
            }
        }

        private void ventriculomegalyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                ventriculomegalyRatio = ventriculomegalyRatios[comboBox.SelectedIndex];
                ventriculomegalyLabel.Text = ventriculomegalyRatio.ToString();
            }
        }

        private void echogenicBowelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                echogenicBowelRatio = echogenicBowelsRatios[comboBox.SelectedIndex];
                echogenicBowelLabel.Text = echogenicBowelRatio.ToString();
            }
        }

        private void hydronephrosisList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                hydronephrosisRatio = hydronephrosisRatios[comboBox.SelectedIndex];
                hydronephrosisLabel.Text = hydronephrosisRatio.ToString();
            }
        }

        private void legBoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                legBoneRatio = legBoneRatios[legBoneBox.SelectedIndex, comboBox.SelectedIndex];
                legBoneLabel.Text = legBoneRatio.ToString();
            }
        }

        private void legBoneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            if (combobox != null)
            {
                legBoneRatio = legBoneRatios[combobox.SelectedIndex, legBoneList.SelectedIndex];
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
