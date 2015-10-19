using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wider_Layout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            echogenicFocusNotAssessed.IsChecked = true;
        }

        double echogenicFocusRatio = 1;
        double ventriculomegalyRatio = 1;
        double echogenicBowelRatio = 1;
        double hydronephrosisRatio = 1;
        double longBoneRatio = 1;
        double nasalBoneRatio = 1;
        double nuchalFoldRatio = 1;

        // All arrays must follow the pattern of { "Not Assessed", "Yes", "No" }
        // to mirror the pattern used by the DropDownLists.
        double[] echogenicFocusRatios = { 1, 5.83, 0.8 };
        double[] ventriculomegalyRatios = { 1, 27.52, 0.94 };
        double[] echogenicBowelsRatios = { 1, 11.44, 0.9 };
        double[] hydronephrosisRatios = { 1, 7.63, 0.92 };
        double[,] longBoneRatios = new double[2, 3] { { 1, 3.72, 0.8 }, { 1, 4.81, 0.74 } };
        double[] nasalBoneRatios = { 1, 23.27, 0.46 };

        // Need to keep track of currently selected nuchal fold thickness index for better 
        // switching of nucal fold thickness lists.
        int currentNuchalFoldIndex;

        // The BPD list of options starts with "Not Assessed" and then goes by twos from 28 to 60.
        double[,] nuchalFoldRatios = new double[18, 8]
        {
            { 1, -1, -1, -1, -1, -1, -1, -1 },
            { 1, 0.41, 0.44, 0.72, 2.75, 17.78, -1, -1 },
            { 1, 0.4, 0.43, 0.63, 2.11, 13.02, -1, -1 },
            { 1, 0.4, 0.42, 0.57, 1.64, 9.57, -1, -1 },
            { 1, 0.4, 0.42, 0.52, 1.3, 7.06, -1, -1 },
            { 1, 0.4, 0.41, 0.49, 1.05, 5.23, -1, -1 },
            { 1, 0.4, 0.41, 0.46, 0.87, 3.91, 26.33, -1 },
            { 1, 0.4, 0.41, 0.45, 0.74, 2.95, 19.23, -1 },
            { 1, 0.4, 0.4, 0.43, 0.65, 2.25, 14.07, -1 },
            { 1, 0.4, 0.4, 0.42, 0.58, 1.74, 10.33, -1 },
            { 1, 0.4, 0.4, 0.42, 0.53, 1.38, 7.61, -1 },
            { 1, 0.4, 0.4, 0.41, 0.5, 1.11, 5.64, -1 },
            { 1, 0.4, 0.4, 0.41, 0.47, 0.91, 4.2, 28.49 },
            { 1, 0.4, 0.4, 0.41, 0.45, 0.77, 3.16, 20.8 },
            { 1, 0.4, 0.4, 0.4, 0.44, 0.67, 2.4, 15.21 },
            { 1, 0.4, 0.4, 0.4, 0.43, 0.6, 1.86, 11.16 },
            { 1, 0.4, 0.4, 0.4, 0.42, 0.54, 1.46, 8.21 },
            { 1, 0.4, 0.4, 0.4, 0.41, 0.5, 1.17, 6.07 },
        };
        List<List<string>> nuchalFoldOptions = new List<List<string>>()
        {
            new List<string>() { "Not Assessed" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "≥7 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "≥7 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "≥7 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "≥7 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "≥7 mm" },
            new List<string>() { "Not Assessed", "1-1.9 mm", "2-2.9 mm", "3-3.9 mm", "4-4.9 mm", "5-5.9 mm", "6-6.9 mm", "≥7 mm" },
        };

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UpdateEchogenicFocusRatio(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                if (radioButton.Content.ToString() == "Not Assessed")
                {
                    echogenicFocusRatio = echogenicFocusRatios[0];
                    echogenicFocusRatioLabel.Content = echogenicFocusRatio.ToString();
                }
                else if (radioButton.Content.ToString() == "Yes")
                {
                    echogenicFocusRatio = echogenicFocusRatios[1];
                    echogenicFocusRatioLabel.Content = echogenicFocusRatio.ToString();
                }
                else if (radioButton.Content.ToString() == "No")
                {
                    echogenicFocusRatio = echogenicFocusRatios[2];
                    echogenicFocusRatioLabel.Content = echogenicFocusRatio.ToString();
                }
            }
        }

        private void UpdateVentrigulomegalyRatio(object sender, RoutedEventArgs e)
        {
            if (ventrigulomegalyNotAssessed.IsChecked == true)
            {
                ventriculomegalyRatio = ventriculomegalyRatios[0];
                ventriculomegalyRatioLabel.Content = ventriculomegalyRatio.ToString();
            }
            else if (ventrigulomegalyYes.IsChecked == true)
            {
                ventriculomegalyRatio = ventriculomegalyRatios[1];
                ventriculomegalyRatioLabel.Content = 
            }
        }
    }
}
