using System.ComponentModel;
using System.Collections.Generic;

namespace A3.Model {
    public class Branch : INotifyPropertyChanged {
        private int branchID;
        private string branchName;
        public int BranchID {
            get {
                return branchID;
            }
            set {
                branchID = value;
                OnPropertyChanged("BranchID");
            }
        }
        public string BranchName {
            get {
                return branchName;
            }
            set {
                branchName = value;
                OnPropertyChanged("BranchName");
            }
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
