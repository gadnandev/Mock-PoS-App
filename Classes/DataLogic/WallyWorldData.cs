/*
* FILE : CustomerWindow.cs
* PROJECT : Assignment 3
* PROGRAMMER : Robert Ochinski
* FIRST VERSION : 2019-12-06
* DESCRIPTION : 
*
*/

using System;
using System.Data;
using System.Collections.Generic;
using A3.Model;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows;

namespace A3.Classes.DataLogic {
    /// \brief The purpose of <b>the ContractMarketplace Class</b> is to connect the MySQL contract marketplace and return a set of contracts
    /// \details <b>Details</b>
    /// <ul>
    /// <li>Private:</li>
    /// <li>Data Members:</li>
    ///     - private string connectionString="server=159.89.117.198;port=3306; user id=DevOSHT;password=Snodgr4ss!;database=cmp;SslMode=none"; *note this is temporary
    /// <li>Constructor(s):</li>
    ///     - Void
    /// <li>Methods:</li>
    ///     - public string GetContract()
    ///     - private string DataTableToString (DataTable table)
    /// </ul>
    public class WallyWorldData {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        /// \brief This method is used to query the data base for all contracts (rows/columns)
        /// \details <b>Details</b>
        /// \public string GetContract()
        /// \param 
        /// 
        /// In this method, we stablish the connection with the database and execute a command to generate 
        /// a sql adapter with a batch of contracts

        //public List<Order> GetOrders() {
        //    const string sqlStatement = @"select * from orderDetail;";
        //    using (var myConn = new MySqlConnection(connectionString)) {
        //        var myCommand = new MySqlCommand(sqlStatement, myConn);


        //        //For offline connection we weill use  MySqlDataAdapter class.  
        //        var myAdapter = new MySqlDataAdapter(myCommand);
        //        var dataTable = new DataTable();

        //        myAdapter.Fill(dataTable);

        //        List<Order> _OrderDetial = DataTableToOrderList(dataTable);

        //        myAdapter.Dispose();

        //        return _OrderDetial;
        //    }
        //}


        public List<Product> GetProducts() {
            const string sqlStatement = @"select * from products;";
            using (var myConn = new MySqlConnection(connectionString)) {
                var myCommand = new MySqlCommand(sqlStatement, myConn);


                //For offline connection we weill use  MySqlDataAdapter class.  
                var myAdapter = new MySqlDataAdapter(myCommand);
                var dataTable = new DataTable();

                myAdapter.Fill(dataTable);

                List<Product> _ProductList = DataTableToProductList(dataTable);

                myAdapter.Dispose();

                return _ProductList;
            }
        }


        public List<Branch> GetBranches() {
            const string sqlStatement = @"select * from branchs;";
            using (var myConn = new MySqlConnection(connectionString)) {
                var myCommand = new MySqlCommand(sqlStatement, myConn);
                var myAdapter = new MySqlDataAdapter(myCommand);
                var dataTable = new DataTable();

                myAdapter.Fill(dataTable);

                List<Branch> _BranchList = DataTableToBranchList(dataTable);

                myAdapter.Dispose();

                return _BranchList;
            }
        }

        public List<Customer> GetCustomers() {
            const string sqlStatement = @"select * from customers;";
            using (var myConn = new MySqlConnection(connectionString)) {
                var myCommand = new MySqlCommand(sqlStatement, myConn);
                var myAdapter = new MySqlDataAdapter(myCommand);
                var dataTable = new DataTable();

                myAdapter.Fill(dataTable);

                List<Customer> _Customers = DataTableToCustomerList(dataTable);

                myAdapter.Dispose();

                return _Customers;
            }
        }

        public void CreateCustomer(Customer customer) {
            string custFirst = customer.FirstName;
            string custLast= customer.LastName;
            string custPhone = customer.Telephone;

            using (MySqlConnection cn = new MySqlConnection(connectionString)) {
                try {
                    string query = "INSERT INTO customers(CustomerID,FirstName, LastName, Telephone) VALUES (?CustomerID,?FirstName,?LastName,?Telephone);";
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, cn)) {
                        cmd.Parameters.Add("?CustomerID", MySqlDbType.Int32).Value = default;
                        cmd.Parameters.Add("?FirstName", MySqlDbType.String).Value = custFirst;
                        cmd.Parameters.Add("?LastName", MySqlDbType.String).Value = custLast;
                        cmd.Parameters.Add("?Telephone", MySqlDbType.String).Value = custPhone;
                        cmd.ExecuteNonQuery();
                    }
                } catch (MySqlException ex) {
                    MessageBox.Show("Error in adding mysql row. Error: " + ex.Message);
                }
            }
        }

        

        private List<Customer> DataTableToCustomerList(DataTable table) {
            //Contract newContract = new Contract();
            List<Customer> _CustomerList = new List<Customer>();
            foreach (DataRow row in table.Rows) {
                Customer newCustomer = new Customer();
                newCustomer.CustomerID = Convert.ToInt32(row["CustomerID"]); ;
                newCustomer.FirstName = row["FirstName"].ToString();
                newCustomer.LastName = row["LastName"].ToString();
                newCustomer.Telephone = row["Telephone"].ToString(); 
                _CustomerList.Add(newCustomer);
            }

            return _CustomerList;
        }

        private List<Product> DataTableToProductList(DataTable table) {          
            List<Product> _ProductList = new List<Product>();
            foreach (DataRow row in table.Rows) {
                Product newProduct = new Product();
                newProduct.SKU = Convert.ToInt32(row["ProductID"]); ;
                newProduct.Name = row["ProductName"].ToString();
                newProduct.WholeSalePrice = Convert.ToDecimal(row["WholeSalePrice"]);
                newProduct.Stock = Convert.ToInt32(row["Stock"]);
                _ProductList.Add(newProduct);
            }
            return _ProductList;
        }


        private List<Branch> DataTableToBranchList(DataTable table) {
            List<Branch> _BranchList = new List<Branch>();
            foreach (DataRow row in table.Rows) {
                Branch newBranch = new Branch();
                newBranch.BranchID = Convert.ToInt32(row["BranchID"]); ;
                newBranch.BranchName = row["BranchName"].ToString();
                _BranchList.Add(newBranch);
            }
            return _BranchList;
        }
    }
}
