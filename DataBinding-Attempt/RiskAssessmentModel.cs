namespace DataBinding_Attempt
{
    using System;
    using System.ComponentModel;

    class RiskAssessmentModel : INotifyPropertyChanged
    {
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

        // Echogenic Focus Ratio

        // Likelihood Ratio

        // Adjusted Risk Factor
        public double adjustedRisk
        {
            get { return aprioriRisk; }
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
}
