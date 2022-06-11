using System.ComponentModel;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;

namespace WC_Simulator.ViewModel.BaseClasses
{
    class BaseViewModel : INotifyPropertyChanged
    {
        private MainModel _model;
        private NavigationStore _navigationStore;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(params string[] namesOfProperties)
        {
            if (PropertyChanged != null)
            {
                foreach (var prop in namesOfProperties)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
                }
            }
        }

        public MainModel Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public NavigationStore NavigationStore
        {
            get { return _navigationStore; }
            set { _navigationStore = value; }
        }
    }
}
