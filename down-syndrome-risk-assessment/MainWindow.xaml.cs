using System;
using System.Windows;

namespace DataBinding_Attempt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new RiskAssessmentModel();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            aprioriRiskBox.CaretIndex = aprioriRiskBox.Text.Length;
        }
    }
}
