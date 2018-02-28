namespace dsram
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Data;

    class RiskAssessmentModel : INotifyPropertyChanged
    {
        public RiskAssessmentModel()
        {
            aprioriRisk = 1000;
            echogenicFocusRatio = 1;
            ventriculomegalyRatio = 1;
            echogenicBowelRatio = 1;
            urinaryDilationRatio = 1;
            aberrantArteryRatio = 1;
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
        double[] aberrantArteryRatios = { 21.48, 0.71, 1 };
        double[] nasalBoneRatios = { 66.75, 23.27, 0.46, 1 };
        double[] femurRatios = { 3.72, 0.80};
        double[] humerusRatios = { 4.81, 0.80 };

        //Long Bone Cutoffs
        double[] shortfemurCutoff = { 13.64, 14.40, 15.16, 15.93, 16.69, 17.45, 18.21, 18.97, 19.73, 20.50, 21.26, 22.02,
                                      22.78, 23.54, 24.30, 25.07, 25.83, 26.59, 27.35, 28.11, 28.87, 29.64, 30.40, 31.16,
                                      31.92, 32.68, 33.44, 34.21, 34.97, 35.73, 36.49, 37.25, 38.01 };
        double[] shortHumerusCutoff = { 13.73, 14.42, 15.11, 15.80, 16.50, 17.19, 17.88, 18.57, 19.26, 19.95, 20.64, 21.33,
                                        22.02, 22.71, 23.40, 24.09, 24.78, 25.48, 26.17, 26.86, 27.55, 28.24, 28.93, 29.62,
                                        30.31, 31.00, 31.69, 32.38, 33.07, 33.76, 34.46, 35.15, 35.84 };        

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
                OnPropertyChanged("adjustedRiskString");
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
                OnPropertyChanged("adjustedRiskString");
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
                OnPropertyChanged("adjustedRiskString");
                OnPropertyChanged("riskPercentage");
            }
        }
        public bool ventriculomegalyYes
        {
            get { return ventriculomegalyRatio.Equals(ventriculomegalyRatios[0]); }
            set
            {
                ventriculomegalyRatio = ventriculomegalyRatios[0];
                MessageBox.Show("This calculator is only intended to be utilized for Down Syndrome risk assessment when lateral cerebral ventricles measure <= 15 mm. If ventricle measurement exceeds 15 mm, this calculator should not be used.",
                                "DSRAM Proper Usage Notice");
            }
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
                OnPropertyChanged("adjustedRiskString");
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
                OnPropertyChanged("adjustedRiskString");
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

        // Aberrant Right Subclavian Artery
        private double _aberrantArteryRatio;
        public double aberrantArteryRatio
        {
            get { return _aberrantArteryRatio; }
            set
            {
                _aberrantArteryRatio = value;
                OnPropertyChanged("aberrantArteryYes");
                OnPropertyChanged("aberrantArteryNo");
                OnPropertyChanged("aberrantArteryNotAssessed");
                OnPropertyChanged("aberrantArteryRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("adjustedRiskString");
                OnPropertyChanged("riskPercentage");
            }
        }
        public bool aberrantArteryYes
        {
            get { return aberrantArteryRatio.Equals(aberrantArteryRatios[0]); }
            set { aberrantArteryRatio = aberrantArteryRatios[0]; }
        }
        public bool aberrantArteryNo
        {
            get { return aberrantArteryRatio.Equals(aberrantArteryRatios[1]); }
            set { aberrantArteryRatio = aberrantArteryRatios[1]; }
        }
        public bool aberrantArteryNotAssessed
        {
            get { return aberrantArteryRatio.Equals(aberrantArteryRatios[2]); }
            set { aberrantArteryRatio = aberrantArteryRatios[2]; }
        }

        // Long Bone (Short Femur and Short Humerus)
        private double _femurObserved;
        public double femurObserved
        {
            get { return _femurObserved; }
            set
            {
                _femurObserved = value;
                OnPropertyChanged("femurObserved");
                OnPropertyChanged("longBoneRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("adjustedRiskString");
                OnPropertyChanged("riskPercentage");
            }
        }

        private double _humerusObserved;
        public double humerusObserved
        {
            get { return _humerusObserved; }
            set
            {
                _humerusObserved = value;
                OnPropertyChanged("humerusObserved");
                OnPropertyChanged("longBoneRatio");
                OnPropertyChanged("likelihoodRatio");
                OnPropertyChanged("adjustedRisk");
                OnPropertyChanged("adjustedRiskString");
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

                int bpdCategory = -1;
                switch (bpdObserved)
                {
                    case 28:
                        bpdCategory = 0;
                        break;
                    case 29:
                        bpdCategory = 1;
                        break;
                    case 30:
                        bpdCategory = 2;
                        break;
                    case 31:
                        bpdCategory = 3;
                        break;
                    case 32:
                        bpdCategory = 4;
                        break;
                    case 33:
                        bpdCategory = 5;
                        break;
                    case 34:
                        bpdCategory = 6;
                        break;
                    case 35:
                        bpdCategory = 7;
                        break;
                    case 36:
                        bpdCategory = 8;
                        break;
                    case 37:
                        bpdCategory = 9;
                        break;
                    case 38:
                        bpdCategory = 10;
                        break;
                    case 39:
                        bpdCategory = 11;
                        break;
                    case 40:
                        bpdCategory = 12;
                        break;
                    case 41:
                        bpdCategory = 13;
                        break;
                    case 42:
                        bpdCategory = 14;
                        break;
                    case 43:
                        bpdCategory = 15;
                        break;
                    case 44:
                        bpdCategory = 16;
                        break;
                    case 45:
                        bpdCategory = 17;
                        break;
                    case 46:
                        bpdCategory = 18;
                        break;
                    case 47:
                        bpdCategory = 19;
                        break;
                    case 48:
                        bpdCategory = 20;
                        break;
                    case 49:
                        bpdCategory = 21;
                        break;
                    case 50:
                        bpdCategory = 22;
                        break;
                    case 51:
                        bpdCategory = 23;
                        break;
                    case 52:
                        bpdCategory = 24;
                        break;
                    case 53:
                        bpdCategory = 25;
                        break;
                    case 54:
                        bpdCategory = 26;
                        break;
                    case 55:
                        bpdCategory = 27;
                        break;
                    case 56:
                        bpdCategory = 28;
                        break;
                    case 57:
                        bpdCategory = 29;
                        break;
                    case 58:
                        bpdCategory = 30;
                        break;
                    case 59:
                        bpdCategory = 31;
                        break;
                    case 60:
                        bpdCategory = 32;
                        break;
                    default:
                        bpdCategory = -1;
                        break;
                }

                if (femurObserved == 0 || bpdCategory == -1)
                {
                    femurLikelihoodRatio = 1;
                }
                else
                {
                    if (femurObserved <= shortfemurCutoff[bpdCategory])
                    {
                        femurLikelihoodRatio = femurRatios[0];
                    }
                    else
                    {
                        femurLikelihoodRatio = femurRatios[1];
                    }
                }

                if (humerusObserved == 0 || bpdCategory == -1)
                {
                    humerusLikelihoodRatio = 1;
                }
                else
                {
                    if (humerusObserved <= shortHumerusCutoff[bpdCategory])
                    {
                        humerusLikelihoodRatio = humerusRatios[0];
                    }
                    else
                    {
                        humerusLikelihoodRatio = humerusRatios[1];
                    }
                }

                if (femurLikelihoodRatio >= humerusLikelihoodRatio)
                {
                    if (femurLikelihoodRatio == 1 && humerusLikelihoodRatio != 1)
                    {
                        return humerusLikelihoodRatio;
                    }
                    else
                        return femurLikelihoodRatio;
                }
                else
                {
                    if (humerusLikelihoodRatio == 1 && femurLikelihoodRatio != 1)
                    {
                        return femurLikelihoodRatio;
                    }
                    else
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
                OnPropertyChanged("adjustedRiskString");
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
                OnPropertyChanged("adjustedRiskString");
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
                OnPropertyChanged("adjustedRiskString");
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
            get { return echogenicFocusRatio * ventriculomegalyRatio * echogenicBowelRatio * urinaryDilationRatio * aberrantArteryRatio * longBoneRatio * nasalBoneRatio * nuchalFoldRatio; }
        }

        // Adjusted Risk Factor
        public double adjustedRisk
        {
            get { return aprioriRisk / likelihoodRatio; }
        }

        // String Representation of the Adjusted Risk Factor
        public string adjustedRiskString
        {
            get
            {
                if (adjustedRisk < 2)
                {
                    return "< 2";
                }
                else
                    return adjustedRisk.ToString("N3");
            }
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
                else if (percentage > 50)
                {
                    return "> 50%";
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

    public class StringToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string strVal = value.ToString();
            if (string.IsNullOrEmpty(strVal))
            {
                return 0.0;
            }
            else
            {
                return Double.Parse(strVal);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return 0;
            }
            return value.ToString();
        }
    }

    // Simple class to hold the information for the long bone dropdown box items.
    public class ListItem
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
