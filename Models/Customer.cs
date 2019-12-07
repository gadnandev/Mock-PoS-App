/*
* FILE : CustomerWindow.cs
* PROJECT : Assignment 3
* PROGRAMMER : Robert Ochinski
* FIRST VERSION : 2019-12-06
* DESCRIPTION : 
*
*/


using System.ComponentModel;
using System.Collections.Generic;

namespace A3.Model {
    public class Customer : INotifyPropertyChanged {
        private int customerID;
        private string firstName;
        private string lastName;
        private string telephone;

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        public int CustomerID {
            get {
                return customerID;
            }
            set {
                customerID = value;
                OnPropertyChanged("CustomerID");
            }
        }

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        public string FirstName {
            get {
                return firstName;
            }
            set {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        public string LastName {
            get {
                return lastName;
            }
            set {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        public string Telephone {
            get {
                return telephone;
            }
            set {
                telephone = value;
                OnPropertyChanged("Telephone");
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
