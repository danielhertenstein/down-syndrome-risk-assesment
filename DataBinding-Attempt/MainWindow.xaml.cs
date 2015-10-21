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

            DataContext = new RiskAssessmentModel() { aprioriRisk = 1000, echogenicFocusRatio = 1.0 };
        }
    }
}
