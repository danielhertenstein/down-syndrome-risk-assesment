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
            bpdObserved = 0;
            nuchalFoldObserved = 0;
        }

        // Likelihood Ratios
        // All arrays must follow the pattern of { "Yes", "No", "Not Assessed" }.
        double[] echogenicFocusRatios = { 5.83, 0.8, 1 };
        double[] ventriculomegalyRatios = { 27.52, 0.94, 1 };
        double[] echogenicBowelRatios = { 11.44, 0.9, 1 };
        double[] urinaryDilationRatios = { 7.63, 0.92, 1 };
        double[,] longBoneRatios = new double[2, 3] { { 3.72, 0.8, 1 }, { 4.81, 0.74, 1 } };
        double[] nasalBoneRatios = { 66.75, 23.27, 0.46, 1 };

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
        private int _bpdObserved;
        public int bpdObserved
        {
            get { return _bpdObserved; }
            set
            {
                _bpdObserved = value;
                OnPropertyChanged("bpdObserved");
                OnPropertyChanged("nuchalFoldRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }

        private int _nuchalFoldObserved;
        public int nuchalFoldObserved
        {
            get { return _nuchalFoldObserved; }
            set
            {
                _nuchalFoldObserved = value;
                OnPropertyChanged("nuchalFoldObserved");
                OnPropertyChanged("nuchalFoldRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }
        
        public double nuchalFoldRatio
        {
            get
            {
                double expected = 0.131 + 0.08 * bpdObserved;
                return 0.4 + 0.1 * Math.Exp(2 * (nuchalFoldObserved - expected));
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
            get { return 100 / adjustedRisk; }
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
