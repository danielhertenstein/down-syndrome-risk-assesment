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

            longBoneList.SelectedItem = "Not Assessed";
            longBoneBox.SelectedItem = "Short femur";
            longBoneList.SelectedIndexChanged += longBoneList_SelectedIndexChanged;
            longBoneBox.SelectedIndexChanged += longBoneBox_SelectedIndexChanged;
        }

        double echogenicFocusRatio = 1;
        double ventriculomegalyRatio = 1;
        double echogenicBowelRatio = 1;
        double hydronephrosisRatio = 1;
        double longBoneRatio = 1;
        double nasalBoneRatio = 1;

        // All arrays must follow the pattern of { "Yes", "No", "Not Assessed" }
        // to mirror the pattern used by the DropDownLists.
        double[] echogenicFocusRatios = { 5.83, 0.8, 1 };
        double[] ventriculomegalyRatios = { 27.52, 0.94, 1 };
        double[] echogenicBowelsRatios = { 11.44, 0.9, 1 };
        double[] hydronephrosisRatios = { 7.63, 0.92, 1 };
        double[,] longBoneRatios = new double[2, 3] { { 3.72, 0.8, 1 }, { 4.81, 0.74, 1 } };
        double[] nasalBoneRatios = { 23.27, 0.46, 1 };

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

        private void longBoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                longBoneRatio = longBoneRatios[longBoneBox.SelectedIndex, comboBox.SelectedIndex];
                longBoneLabel.Text = longBoneRatio.ToString();
            }
        }

        private void longBoneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            if (combobox != null)
            {
                longBoneRatio = longBoneRatios[combobox.SelectedIndex, longBoneList.SelectedIndex];
                longBoneLabel.Text = longBoneRatio.ToString();
            }
        }

        private void nasalBoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                nasalBoneRatio = nasalBoneRatios[comboBox.SelectedIndex];
                nasalBoneLabel.Text = nasalBoneRatio.ToString();
            }
        }

        private void UpdateLikelihoodRatio(object sender, EventArgs e)
        {
            double likelihood = (echogenicFocusRatio * ventriculomegalyRatio
                                 * echogenicBowelRatio * hydronephrosisRatio
                                 * longBoneRatio * nasalBoneRatio);
            double risk = (double)ageRelatedRisk.Value / likelihood;

            adjustedRisk.Text = risk.ToString("0.#####");
            likelihoodRatio.Text = likelihood.ToString("0.#####");
        }
    }
}
