namespace dsram
{
    using System;
    using System.ComponentModel;

    class RiskAssessmentModel : INotifyPropertyChanged
    {
        public RiskAssessmentModel()
        {
            aprioriRisk = 1000;
            echogenicFocusRatio = 1;
            ventriculomegalyRatio = 1;
            echogenicBowelRatio = 1;
            urinaryDilationRatio = 1;
            nasalBoneRatio = 1;
            femurObserved = 0;
            humerusObserved = 0;
            bpdObserved = 0;
            nuchalFoldObserved = 0;
        }

        // Likelihood Ratios
        // All arrays must follow the pattern of { "Yes", "No", "Not Assessed" }.
        double[] echogenicFocusRatios = { 5.83, 0.8, 1 };
        double[] ventriculomegalyRatios = { 27.52, 0.94, 1 };
        double[] echogenicBowelRatios = { 11.44, 0.9, 1 };
        double[] urinaryDilationRatios = { 7.63, 0.92, 1 };
        double[] nasalBoneRatios = { 66.75, 23.27, 0.46, 1 };
        double[,] femurRatios = new double[2, 2] { { 0.5, 1.5 }, { 0.6, 1.6 } };
        double[,] humerusRatios = new double[2, 2] { { 0.4, 1.4 }, { 0.3, 1.3 } };

        //Long Bone Cutoffs
        double[] shortfemurCutoff = { 1, 2 };
        double[] shortHumerusCutoff = { 1, 2 };        

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

        // Long Bone (Short Femur and Short Humerus)
        private int _femurObserved;
        public int femurObserved
        {
            get { return _femurObserved; }
            set
            {
                _femurObserved = value;
                OnPropertyChanged("femurObserved");
                OnPropertyChanged("longBoneRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }

        private int _humerusObserved;
        public int humerusObserved
        {
            get { return _humerusObserved; }
            set
            {
                _humerusObserved = value;
                OnPropertyChanged("humerusObserved");
                OnPropertyChanged("longBoneRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }

        public double longBoneRatio
        {
            get
            {
                // Compute the likelihood ratio for both bones.
                // Use the most conservative ratio.
                double femurLikelihoodRatio;
                double humerusLikelihoodRatio;

                int bpdCategory = 0;
                if (bpdObserved < 20)
                {
                    bpdCategory = 1;
                }

                if (femurObserved == 0)
                {
                    femurLikelihoodRatio = 1;
                }
                else
                {
                    if (femurObserved <= shortfemurCutoff[bpdCategory])
                    {
                        return femurRatios[bpdCategory, 0];
                    }
                    else
                    {
                        return femurRatios[bpdCategory, 1];
                    }
                }

                if (humerusObserved == 0)
                {
                    humerusLikelihoodRatio = 1;
                }
                else
                {
                    if (humerusObserved <= shortHumerusCutoff[bpdCategory])
                    {
                        return humerusRatios[bpdCategory, 0];
                    }
                    else
                    {
                        return humerusRatios[bpdCategory, 1];
                    }
                }

                if (femurLikelihoodRatio >= humerusLikelihoodRatio)
                {
                    return femurLikelihoodRatio;
                }
                else
                {
                    return humerusLikelihoodRatio;
                }
            }
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
                OnPropertyChanged("longBoneRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("riskPercentage");
            }
        }

        private double _nuchalFoldObserved;
        public double nuchalFoldObserved
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
                if (bpdObserved == 0 || nuchalFoldObserved == 0)
                {
                    return 1;
                }
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
        public string riskPercentage
        {
            get
            {
                double percentage = 100 / adjustedRisk;
                if (percentage < 0.001)
                {
                    return "< 0.001%";
                }
                else
                {
                    return percentage.ToString("N3") + "%";
                }

            }
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
