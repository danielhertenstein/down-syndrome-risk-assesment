namespace DataBinding_Attempt
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;

    class RiskAssessmentModel : INotifyPropertyChanged
    {
        public RiskAssessmentModel()
        {
            aprioriRisk = 1000;
            echogenicFocusRatio = 1;
            ventriculomegalyRatio = 1;
            echogenicBowelsRatio = 1;
            hydronephrosisRatio = 1;
            longBoneRatio = 1;
            LongBoneItems = new List<LongBoneItem>()
            {
                new LongBoneItem() { Name="Short Femur:", ID=0 },
                new LongBoneItem() { Name="Short Humerus:", ID=1 }
            };
            longBoneChoice = 0;
        }

        // Likelihood Ratios
        // All arrays must follow the pattern of { "Yes", "No", "Not Assessed" }.
        double[] echogenicFocusRatios = { 5.83, 0.8, 1 };
        double[] ventriculomegalyRatios = { 27.52, 0.94, 1 };
        double[] echogenicBowelsRatios = { 11.44, 0.9, 1 };
        double[] hydronephrosisRatios = { 7.63, 0.92, 1 };
        double[,] longBoneRatios = new double[2, 3] { { 3.72, 0.8, 1 }, { 4.81, 0.74, 1 } };

        // a priori Risk
        private double _aprioriRisk;
        public double aprioriRisk
        {
            get { return _aprioriRisk; }
            set
            {
                _aprioriRisk = value;
                OnPropertyChanged("aprioriRisk");
                OnPropertyChanged("adjustedRisk");
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

        // Echogenic Bowels
        private double _echogenicBowelsRatio;
        public double echogenicBowelsRatio
        {
            get { return _echogenicBowelsRatio; }
            set
            {
                _echogenicBowelsRatio = value;
                OnPropertyChanged("echogenicBowelsYes");
                OnPropertyChanged("echogenicBowelsNo");
                OnPropertyChanged("echogenicBowelsNotAssessed");
                OnPropertyChanged("echogenicBowelsRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
            }
        }
        public bool echogenicBowelsYes
        {
            get { return echogenicBowelsRatio.Equals(echogenicBowelsRatios[0]); }
            set { echogenicBowelsRatio = echogenicBowelsRatios[0]; }
        }
        public bool echogenicBowelsNo
        {
            get { return echogenicBowelsRatio.Equals(echogenicBowelsRatios[1]); }
            set { echogenicBowelsRatio = echogenicBowelsRatios[1]; }
        }
        public bool echogenicBowelsNotAssessed
        {
            get { return echogenicBowelsRatio.Equals(echogenicBowelsRatios[2]); }
            set { echogenicBowelsRatio = echogenicBowelsRatios[2]; }
        }

        // Mild Hydronephrosis
        private double _hydronephrosisRatio;
        public double hydronephrosisRatio
        {
            get { return _hydronephrosisRatio; }
            set
            {
                _hydronephrosisRatio = value;
                OnPropertyChanged("hydronephrosisYes");
                OnPropertyChanged("hydronephrosisNo");
                OnPropertyChanged("hydronephrosisNotAssessed");
                OnPropertyChanged("hydronephrosisRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
            }
        }
        public bool hydronephrosisYes
        {
            get { return hydronephrosisRatio.Equals(hydronephrosisRatios[0]); }
            set { hydronephrosisRatio = hydronephrosisRatios[0]; }
        }
        public bool hydronephrosisNo
        {
            get { return hydronephrosisRatio.Equals(hydronephrosisRatios[1]); }
            set { hydronephrosisRatio = hydronephrosisRatios[1]; }
        }
        public bool hydronephrosisNotAssessed
        {
            get { return hydronephrosisRatio.Equals(hydronephrosisRatios[2]); }
            set { hydronephrosisRatio = hydronephrosisRatios[2]; }
        }

        // Long Bone (Short Femur or Short Humerus)
        public List<LongBoneItem> LongBoneItems { get; set; }
        private int _longBoneChoice;
        public int longBoneChoice
        {
            get { return _longBoneChoice; }
            set
            {
                _longBoneChoice = value;
                if (longBoneRatio == longBoneRatios[0, 0])
                    longBoneRatio = longBoneRatios[1, 0];
                else if (longBoneRatio == longBoneRatios[0, 1])
                    longBoneRatio = longBoneRatios[1, 1];
                else if (longBoneRatio == longBoneRatios[1, 0])
                    longBoneRatio = longBoneRatios[0, 0];
                else if (longBoneRatio == longBoneRatios[1, 1])
                    longBoneRatio = longBoneRatios[0, 1];
                else if (longBoneRatio == longBoneRatios[0, 2])
                    longBoneRatio = longBoneRatios[1, 2];
                else if (longBoneRatio == longBoneRatios[1, 2])
                    longBoneRatio = longBoneRatios[0, 2];
                OnPropertyChanged("longBoneChoice");
                OnPropertyChanged("longBoneYes");
                OnPropertyChanged("longBoneNo");
                OnPropertyChanged("longBoneNotAssessed");
                OnPropertyChanged("longBoneRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
            }
        }

        private double _longBoneRatio;
        public double longBoneRatio
        {
            get { return _longBoneRatio; }
            set
            {
                _longBoneRatio = value;
                OnPropertyChanged("longBoneYes");
                OnPropertyChanged("longBoneNo");
                OnPropertyChanged("longBoneNotAssessed");
                OnPropertyChanged("longBoneRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
            }
        }
        public bool longBoneYes
        {
            get { return longBoneRatio.Equals(longBoneRatios[longBoneChoice, 0]); }
            set { longBoneRatio = longBoneRatios[longBoneChoice, 0]; }
        }
        public bool longBoneNo
        {
            get { return longBoneRatio.Equals(longBoneRatios[longBoneChoice, 1]); }
            set { longBoneRatio = longBoneRatios[longBoneChoice, 1]; }
        }
        public bool longBoneNotAssessed
        {
            get { return longBoneRatio.Equals(longBoneRatios[longBoneChoice, 2]); }
            set { longBoneRatio = longBoneRatios[longBoneChoice, 2]; }
        }

        // Likelihood Ratio
        public double likelihoodRatio
        {
            get { return echogenicFocusRatio * ventriculomegalyRatio * echogenicBowelsRatio * hydronephrosisRatio * longBoneRatio; }
        }

        // Adjusted Risk Factor
        public double adjustedRisk
        {
            get { return aprioriRisk / likelihoodRatio; }
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
    public class LongBoneItem
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
