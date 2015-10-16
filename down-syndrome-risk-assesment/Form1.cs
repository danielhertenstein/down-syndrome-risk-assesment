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
        double nuchalFoldRatio = 1;

        // All arrays must follow the pattern of { "Yes", "No", "Not Assessed" }
        // to mirror the pattern used by the DropDownLists.
        double[] echogenicFocusRatios = { 5.83, 0.8, 1 };
        double[] ventriculomegalyRatios = { 27.52, 0.94, 1 };
        double[] echogenicBowelsRatios = { 11.44, 0.9, 1 };
        double[] hydronephrosisRatios = { 7.63, 0.92, 1 };
        double[,] longBoneRatios = new double[2, 3] { { 3.72, 0.8, 1 }, { 4.81, 0.74, 1 } };
        double[] nasalBoneRatios = { 23.27, 0.46, 1 };

        // The BPD list of options starts at 28, goes by twos up to 60, then ends with "Not Assessed".
        double[,] nuchalFoldRatios = new double[18, 8]
        {
            { 0.41, 0.44, 0.72, 2.75, 17.78, 1, -1, -1 },
            { 0.4, 0.43, 0.63, 2.11, 13.02, 1, -1, -1 },
            { 0.4, 0.42, 0.57, 1.64, 9.57, 1, -1, -1 },
            { 0.4, 0.42, 0.52, 1.3, 7.06, 1, -1, -1 },
            { 0.4, 0.41, 0.49, 1.05, 5.23, 1, -1, -1 },
            { 0.4, 0.41, 0.46, 0.87, 3.91, 26.33, 1, -1 },
            { 0.4, 0.41, 0.45, 0.74, 2.95, 19.23, 1, -1 },
            { 0.4, 0.4, 0.43, 0.65, 2.25, 14.07, 1, -1 },
            { 0.4, 0.4, 0.42, 0.58, 1.74, 10.33, 1, -1 },
            { 0.4, 0.4, 0.42, 0.53, 1.38, 7.61, 1, -1 },
            { 0.4, 0.4, 0.41, 0.5, 1.11, 5.64, 1, -1 },
            { 0.4, 0.4, 0.41, 0.47, 0.91, 4.2, 28.49, 1 },
            { 0.4, 0.4, 0.41, 0.45, 0.77, 3.16, 20.8, 1 },
            { 0.4, 0.4, 0.4, 0.44, 0.67, 2.4, 15.21, 1 },
            { 0.4, 0.4, 0.4, 0.43, 0.6, 1.86, 11.16, 1 },
            { 0.4, 0.4, 0.4, 0.42, 0.54, 1.46, 8.21, 1 },
            { 0.4, 0.4, 0.4, 0.41, 0.5, 1.17, 6.07, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1 },
        };
        List<List<string>> nuchalFoldOptions = new List<List<string>>()
        {
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "≥7 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "≥7 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "≥7 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "≥7 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "≥7 mm", "Not Assessed" },
            new List<string>() { "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "≥7 mm", "Not Assessed" },
            new List<string>() { "Not Assessed" },
        };

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
                                 * longBoneRatio * nasalBoneRatio
                                 * nuchalFoldRatio);
            double risk = (double)ageRelatedRisk.Value / likelihood;

            adjustedRisk.Text = risk.ToString("0.#####");
            likelihoodRatio.Text = likelihood.ToString("0.#####");
        }

        private void UpdateNuchalFoldOptions(object sender, EventArgs e)
        {
            nuchalFoldList.DataSource = nuchalFoldOptions[bpdList.SelectedIndex];
        }

        private void nuchalFoldList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            if (combobox != null)
            {
                nuchalFoldRatio = nuchalFoldRatios[bpdList.SelectedIndex, nuchalFoldList.SelectedIndex];
                nuchalFoldLabel.Text = nuchalFoldRatio.ToString();
            }
        }
    }
}
