namespace dsram
{
    using System;
    using System.Windows;
    using System.ComponentModel;
    using System.Collections.Generic;

    class RiskAssessmentModel : INotifyPropertyChanged
    {
        public RiskAssessmentModel()
        {
            aprioriRisk = 1000;
            echogenicFocusRatio = 1;
            ventriculomegalyRatio = 1;
            echogenicBowelRatio = 1;
            urinaryDilationRatio = 1;
            longBoneAssessment = 2;
            LongBoneItems = new List<ListItem>()
            {
                new ListItem() { Name="Short Femur:", ID=0 },
                new ListItem() { Name="Short Humerus:", ID=1 }
            };
            longBoneChoice = 0;
            nasalBoneRatio = 1;
            bpdItems = new List<ListItem>()
            {
                new ListItem() { Name="Not Assessed", ID=0 },
                new ListItem() { Name="28", ID=1 },
                new ListItem() { Name="30", ID=2 },
                new ListItem() { Name="32", ID=3 },
                new ListItem() { Name="34", ID=4 },
                new ListItem() { Name="36", ID=5 },
                new ListItem() { Name="38", ID=6 },
                new ListItem() { Name="40", ID=7 },
                new ListItem() { Name="42", ID=8 },
                new ListItem() { Name="44", ID=9 },
                new ListItem() { Name="46", ID=10 },
                new ListItem() { Name="48", ID=11 },
                new ListItem() { Name="50", ID=12 },
                new ListItem() { Name="52", ID=13 },
                new ListItem() { Name="54", ID=14 },
                new ListItem() { Name="56", ID=15 },
                new ListItem() { Name="58", ID=16 },
                new ListItem() { Name="60", ID=17 },
            };
            bpdChoice = 0;
            nuchalFoldChoice = 0;
        }

        // Likelihood Ratios
        // All arrays must follow the pattern of { "Yes", "No", "Not Assessed" }.
        double[] echogenicFocusRatios = { 5.83, 0.8, 1 };
        double[] ventriculomegalyRatios = { 27.52, 0.94, 1 };
        double[] echogenicBowelRatios = { 11.44, 0.9, 1 };
        double[] urinaryDilationRatios = { 7.63, 0.92, 1 };
        double[,] longBoneRatios = new double[2, 3] { { 3.72, 0.8, 1 }, { 4.81, 0.74, 1 } };
        double[] nasalBoneRatios = { 40, 23.27, 0.46, 1 };
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

        List<ListItem> allNuchalFoldItems = new List<ListItem>()
        {
            new ListItem() { Name = "Not Assessed", ID = 0 },
            new ListItem() { Name="1-1.9 mm", ID=1 },
            new ListItem() { Name="2-2.9 mm", ID=2 },
            new ListItem() { Name="3-3.9 mm", ID=3 },
            new ListItem() { Name="4-4.9 mm", ID=4 },
            new ListItem() { Name="5-5.9 mm", ID=5 },
            new ListItem() { Name="6-6.9 mm", ID=6 },
            new ListItem() { Name="≥7 mm", ID=7 }
        };

        // a priori Risk
        private int _aprioriRisk;
        public int aprioriRisk
        {
            get { return _aprioriRisk; }
            set
            {
                _aprioriRisk = value;
                OnPropertyChanged("aprioriRisk");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }

        // Echogenic Focus
        private double _echogenicFocusRatio;
        public double echogenicFocusRatio
        {
            get { return _echogenicFocusRatio; }
            set
            {
                _echogenicFocusRatio = value;
                OnPropertyChanged("echogenicFocusYes");
                OnPropertyChanged("echogenicFocusNo");
                OnPropertyChanged("echogenicFocusNotAssessed");
                OnPropertyChanged("echogenicFocusRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }
        public bool echogenicFocusYes
        {
            get { return echogenicFocusRatio.Equals(echogenicFocusRatios[0]); }
            set { echogenicFocusRatio = echogenicFocusRatios[0]; }
        }
        public bool echogenicFocusNo
        {
            get { return echogenicFocusRatio.Equals(echogenicFocusRatios[1]); }
            set { echogenicFocusRatio = echogenicFocusRatios[1]; }
        }
        public bool echogenicFocusNotAssessed
        {
            get { return echogenicFocusRatio.Equals(echogenicFocusRatios[2]); }
            set { echogenicFocusRatio = echogenicFocusRatios[2]; }
        }

        // Ventriculomegaly
        private double _ventriculomegalyRatio;
        public double ventriculomegalyRatio
        {
            get { return _ventriculomegalyRatio; }
            set
            {
                _ventriculomegalyRatio = value;
                OnPropertyChanged("ventriculomegalyYes");
                OnPropertyChanged("ventriculomegalyNo");
                OnPropertyChanged("ventriculomegalyNotAssessed");
                OnPropertyChanged("ventriculomegalyRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }
        public bool ventriculomegalyYes
        {
            get { return ventriculomegalyRatio.Equals(ventriculomegalyRatios[0]); }
            set { ventriculomegalyRatio = ventriculomegalyRatios[0]; }
        }
        public bool ventriculomegalyNo
        {
            get { return ventriculomegalyRatio.Equals(ventriculomegalyRatios[1]); }
            set { ventriculomegalyRatio = ventriculomegalyRatios[1]; }
        }
        public bool ventriculomegalyNotAssessed
        {
            get { return ventriculomegalyRatio.Equals(ventriculomegalyRatios[2]); }
            set { ventriculomegalyRatio = ventriculomegalyRatios[2]; }
        }

        // Echogenic Bowel
        private double _echogenicBowelRatio;
        public double echogenicBowelRatio
        {
            get { return _echogenicBowelRatio; }
            set
            {
                _echogenicBowelRatio = value;
                OnPropertyChanged("echogenicBowelYes");
                OnPropertyChanged("echogenicBowelNo");
                OnPropertyChanged("echogenicBowelNotAssessed");
                OnPropertyChanged("echogenicBowelRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }
        public bool echogenicBowelYes
        {
            get { return echogenicBowelRatio.Equals(echogenicBowelRatios[0]); }
            set { echogenicBowelRatio = echogenicBowelRatios[0]; }
        }
        public bool echogenicBowelNo
        {
            get { return echogenicBowelRatio.Equals(echogenicBowelRatios[1]); }
            set { echogenicBowelRatio = echogenicBowelRatios[1]; }
        }
        public bool echogenicBowelNotAssessed
        {
            get { return echogenicBowelRatio.Equals(echogenicBowelRatios[2]); }
            set { echogenicBowelRatio = echogenicBowelRatios[2]; }
        }

        // Urinary Tract Dilation
        private double _urinaryDilationRatio;
        public double urinaryDilationRatio
        {
            get { return _urinaryDilationRatio; }
            set
            {
                _urinaryDilationRatio = value;
                OnPropertyChanged("urinaryDilationYes");
                OnPropertyChanged("urinaryDilationNo");
                OnPropertyChanged("urinaryDilationNotAssessed");
                OnPropertyChanged("urinaryDilationRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }
        public bool urinaryDilationYes
        {
            get { return urinaryDilationRatio.Equals(urinaryDilationRatios[0]); }
            set { urinaryDilationRatio = urinaryDilationRatios[0]; }
        }
        public bool urinaryDilationNo
        {
            get { return urinaryDilationRatio.Equals(urinaryDilationRatios[1]); }
            set { urinaryDilationRatio = urinaryDilationRatios[1]; }
        }
        public bool urinaryDilationNotAssessed
        {
            get { return urinaryDilationRatio.Equals(urinaryDilationRatios[2]); }
            set { urinaryDilationRatio = urinaryDilationRatios[2]; }
        }

        // Long Bone (Short Femur or Short Humerus)
        public List<ListItem> LongBoneItems { get; set; }
        private int _longBoneChoice;
        public int longBoneChoice
        {
            get { return _longBoneChoice; }
            set
            {
                _longBoneChoice = value;
                OnPropertyChanged("longBoneChoice");
                OnPropertyChanged("longBoneRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }

        private int _longBoneAssessment;
        public int longBoneAssessment
        {
            get { return _longBoneAssessment; }
            set
            {
                _longBoneAssessment = value;
                OnPropertyChanged("longBoneYes");
                OnPropertyChanged("longBoneNo");
                OnPropertyChanged("longBoneNotAssessed");
                OnPropertyChanged("longBoneRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }
        public bool longBoneYes
        {
            get { return longBoneAssessment.Equals(0); }
            set { longBoneAssessment = 0; }
        }
        public bool longBoneNo
        {
            get { return longBoneAssessment.Equals(1); }
            set { longBoneAssessment = 1; }
        }
        public bool longBoneNotAssessed
        {
            get { return longBoneAssessment.Equals(2); }
            set { longBoneAssessment = 2; }
        }

        public double longBoneRatio
        {
            get { return longBoneRatios[longBoneChoice, longBoneAssessment]; }
        }

        // Absent or Hypoplastic Nasal Bone
        private double _nasalBoneRatio;
        public double nasalBoneRatio
        {
            get { return _nasalBoneRatio; }
            set
            {
                _nasalBoneRatio = value;
                OnPropertyChanged("nasalBoneAbsent");
                OnPropertyChanged("nasalBoneHypoplastic");
                OnPropertyChanged("nasalBonePresent");
                OnPropertyChanged("nasalBonePreviouslyEvaluated");
                OnPropertyChanged("nasalBoneRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }
        public bool nasalBoneAbsent
        {
            get { return nasalBoneRatio.Equals(nasalBoneRatios[0]); }
            set { nasalBoneRatio = nasalBoneRatios[0]; }
        }
        public bool nasalBoneHypoplastic
        {
            get { return nasalBoneRatio.Equals(nasalBoneRatios[1]); }
            set { nasalBoneRatio = nasalBoneRatios[1]; }
        }
        public bool nasalBonePresent
        {
            get { return nasalBoneRatio.Equals(nasalBoneRatios[2]); }
            set { nasalBoneRatio = nasalBoneRatios[2]; }
        }
        public bool nasalBonePreviouslyEvaluated
        {
            get { return nasalBoneRatio.Equals(nasalBoneRatios[3]); }
            set { nasalBoneRatio = nasalBoneRatios[3]; }
        }

        // BPD and Nuchal Fold Thickness
        public List<ListItem> bpdItems { get; set; }
        private int _bpdChoice;
        public int bpdChoice
        {
            get { return _bpdChoice; }
            set
            {
                _bpdChoice = value;
                OnPropertyChanged("bpdChoice");
                SetNuchalFoldItems();
                OnPropertyChanged("nuchalFoldRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }

        public List<ListItem> nuchalFoldItems { get; set; }
        private int _nuchalFoldChoice;
        public int nuchalFoldChoice
        {
            get { return _nuchalFoldChoice; }
            set
            {
                _nuchalFoldChoice = value;
                OnPropertyChanged("nuchalFoldChoice");
                OnPropertyChanged("nuchalFoldRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }
        
        public double nuchalFoldRatio
        {
            get { return nuchalFoldRatios[bpdChoice, nuchalFoldChoice];}
        }

        private void SetNuchalFoldItems()
        {
            if (bpdChoice == 0)
            {
                CheckNuchalFoldChoice(1);
                nuchalFoldItems = allNuchalFoldItems.GetRange(0, 1);
            }
            else if (bpdChoice > 0 && bpdChoice <= 5)
            {
                CheckNuchalFoldChoice(6);
                nuchalFoldItems = allNuchalFoldItems.GetRange(0, 6);
            }
            else if (bpdChoice > 5 && bpdChoice <= 11)
            {
                CheckNuchalFoldChoice(7);
                nuchalFoldItems = allNuchalFoldItems.GetRange(0, 7);
            }
            else if (bpdChoice > 11)
                nuchalFoldItems = allNuchalFoldItems;
            OnPropertyChanged("nuchalFoldItems");
        }

        // Abandoning MVVM here because something as simple as a message box is disgustingly complex.
        private void CheckNuchalFoldChoice(int maxIndex)
        {
            if (nuchalFoldChoice >= maxIndex)
            {
                MessageBox.Show("No data for this nuchal fold thickness / BPD combination." + Environment.NewLine + "Resetting the nuchal fold thickness.",
                    "Option Selection Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                nuchalFoldChoice = 0;
            }
        }

        // Likelihood Ratio
        public double likelihoodRatio
        {
            get { return echogenicFocusRatio * ventriculomegalyRatio * echogenicBowelRatio * urinaryDilationRatio * longBoneRatio * nasalBoneRatio * nuchalFoldRatio; }
        }

        // Adjusted Risk Factor
        public double adjustedRisk
        {
            get { return aprioriRisk / likelihoodRatio; }
        }

        // Adjusted Risk Percentage
        public double riskPercentage
        {
            get { return 1 / adjustedRisk; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }

    // Simple class to hold the information for the long bone dropdown box items.
    public class ListItem
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
