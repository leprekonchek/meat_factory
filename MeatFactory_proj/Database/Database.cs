using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using MeatFactory_proj.Models;

namespace MeatFactory_proj.Database
{
    class Database : IDataStorage
    {
        // ExecuteNonQuery is used for SELECT queries
        // ExecuteReader is used for not SELECT queries like INSERT, DELETE, UPDATE
        // reader[*name of attribute*].toString()

        SqlConnection connection = new SqlConnection(Properties.Settings.Default.MeatFactoryConnectionString);

        #region Examples
        // ADD PUBLIC IDENTIFICATOR TO THEM AFTER COPYING

        void insertSmth(Product product)
        {
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }
                connection.Open();

                SqlCommand query = new SqlCommand("INSERT INTO table_name (Name, column2, ..) " + // which columns
                    "VALUES 'gosha', value2, ..", connection); // which values

                query.ExecuteNonQuery();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }
        }

        // пока надо разобраться с этим
        void updateSmth(Product product)
        {
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }
                connection.Open();

                SqlCommand query = new SqlCommand("UPDATE table_name " +
                    $"SET column1 = '{product.Name}', ..." + // here are columns and values which to update, list all columns (!)
                    $"WHERE Barcode = '{product.Barcode}'", connection);

                query.ExecuteNonQuery();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }
        }

        void deleteSmth(/*Product product*/ String name)
        {
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }
                connection.Open();

                /*SqlCommand query = new SqlCommand(                    "DELETE FROM table_name " +
                    "WHERE Name = '" + product.Name + "'",
                    connection);*/

                SqlCommand query = new SqlCommand("DELETE FROM table_name " +
                    $"WHERE Name = '{name}'", connection);
                /*$"WHERE Age = {age}",*/

                query.ExecuteNonQuery();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }
        }

        void selectSmth()
        {
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }

                connection.Open();

                SqlCommand query = new SqlCommand(
                    "SELECT Name_contr FROM Contractor",
                    connection);

                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    // there add things to list
                }

                reader.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }
        }


        #endregion

        #region SelectAll

        public List<Product> selectAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }

                connection.Open();

                SqlCommand query = new SqlCommand(
                    "SELECT * FROM Product",
                    connection);

                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        Barcode = reader.GetString(0),
                        Name = reader.GetString(1),
                        Type = reader.GetString(2),
                        Quantity = reader.GetInt32(3),
                        Weight = reader.GetDouble(4),
                        MeasureType = reader.GetString(5),
                        Price = reader.GetDecimal(6),
                        ExpirationDate = reader.GetDateTime(7)
                    };
                    products.Add(product);
                }

                reader.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }

            return products;
        }

        public List<Buyer> selectAllBuyers()
        {
            List<Buyer> buyers = new List<Buyer>();
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }

                connection.Open();

                SqlCommand query = new SqlCommand(
                    "SELECT * FROM Buyer",
                    connection);

                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    Buyer buyer = new Buyer
                    {
                        EDRPOU = reader.GetString(0),
                        Name = reader.GetString(1),
                        Phone = reader.GetString(2),
                        IsLegal = reader.GetBoolean(3),
                        Street = reader.GetString(4),
                        BuildingNumber = reader.GetString(5),
                        Town = reader.GetString(6),
                        PostCode = reader.GetString(7)
                    };
                    buyers.Add(buyer);
                }

                reader.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }

            return buyers;
        }

        public List<Component> selectAllComponents()
        {
            List<Component> components = new List<Component>();
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }

                connection.Open();

                SqlCommand query = new SqlCommand(
                    "SELECT * FROM Components",
                    connection);

                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    Component component = new Component
                    {
                        Code = reader.GetString(0),
                        Name = reader.GetString(1),
                        Type = reader.GetString(2),
                        Quantity = reader.GetString(3),
                        Price = reader.GetDecimal(4),
                        IsPackage = reader.GetBoolean(5)
                    };
                    components.Add(component);
                }

                reader.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }

            return components;

        }

        public List<Provisioner> selectAllProvisioners()
        {
            List<Provisioner> provisioners = new List<Provisioner>();
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }

                connection.Open();

                SqlCommand query = new SqlCommand(
                    "SELECT * FROM Provisioner",
                    connection);

                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    Provisioner provisioner = new Provisioner
                    {
                        EDRPOU = reader.GetString(0),
                        Name = reader.GetString(1),
                        Phone = reader.GetString(2),
                        IsLegal = reader.GetBoolean(3),
                        Street = reader.GetString(4),
                        BuildingNumber = reader.GetString(5),
                        Town = reader.GetString(6),
                        PostCode = reader.GetString(7)
                    };
                    provisioners.Add(provisioner);
                }

                reader.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }

            return provisioners;
        }

        public List<Transport> selectAllTransports()
        {
            List<Transport> transports = new List<Transport>();
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }

                connection.Open();

                SqlCommand query = new SqlCommand(
                    "SELECT * FROM Transport",
                    connection);

                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    Transport transport = new Transport
                    {
                        AutoNumber = reader.GetString(0),
                        Type = reader.GetString(1),
                        PriceOfPetrol = reader.GetString(2),
                        Driver = reader.GetString(3)
                    };
                    transports.Add(transport);
                }

                reader.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }

            return transports;
        }
        #endregion

        #region User

        public bool userExists(String login)
        {
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }
                connection.Open();

                SqlCommand query = new SqlCommand(
                    "SELECT COUNT(*) " +
                    "FROM Users " +
                    $"WHERE Login='{login}'",
                connection);
                int count = (int)query.ExecuteScalar();
                return count == 1;
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }
            return false;
        }

        public User getUser(string login)
        {
            User user = new User();
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }
                connection.Open();

                SqlCommand query = new SqlCommand($"SELECT * " +
                                                  "FROM Users " +
                                                  $"WHERE Login = '{login}'", connection);

                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    user = new User
                    {
                        Login = reader.GetString(0),
                        Password = reader.GetString(1)
                    };
                }

                reader.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }

            return user;
        }

        public String getPassword(string login)
        {
            string password = "";
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }
                connection.Open();

                SqlCommand query = new SqlCommand("SELECT Password " +
                                                  "FROM Users " +
                                                  $"WHERE Login = '{login}'", connection);

                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) { password = reader.GetString(0); }

                reader.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }

            return password;
        }

        public void insertNewUser(string login, string password)
        {
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }
                connection.Open();

                SqlCommand query = new SqlCommand(
                $"INSERT INTO Users (Login, Password) VALUES ('{login}', '{password}')", connection);
                query.ExecuteNonQuery();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }
        }

        #endregion

        #region Component

        public List<Component> selectComponentByProductId(string barcode)
        {
            List<Component> lc = new List<Component>();
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }

                connection.Open();

                SqlCommand query = new SqlCommand(
                    "SELECT Component_name, Component_type, Is_package " +
                    "FROM Components c INNER JOIN ComponentAndProduct cp ON c.Component_code = cp.Component_code " +
                    $"WHERE Barcode = '{barcode}'", connection);

                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    Component c = new Component
                    {
                        Name = reader.GetString(0),
                        Type = reader.GetString(1),
                        IsPackage = reader.GetBoolean(2)
                    };
                    lc.Add(c);
                }

                reader.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }

            return lc;
        }

        #endregion

        #region Product

        public void insertNewProduct(Product product)
        {
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }
                connection.Open();

                SqlCommand query = new SqlCommand("INSERT INTO Product (Barcode, Product_name, Product_type, Product_quantity, " +
                                                  "Weight, Product_measure_type, Product_price, Expiration_date) " +
                                                  $"VALUES ('{product.Barcode}','{product.Name}','{product.Type}','{product.Quantity}'," +
                                                  $"'{product.Weight}','{product.MeasureType}', '{product.Price}','{product.ExpirationDate}')", connection); // which values

                query.ExecuteNonQuery();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }
        }

        public void updateProduct(Product product)
        {
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }
                connection.Open();

                SqlCommand query = new SqlCommand("UPDATE Product " +
                                                  $"SET Product_name = '{product.Name}', Product_type = '{product.Type}', Product_quantity = '{product.Quantity}', " +
                                                  $"Weight = '{product.Weight}', Product_measure_type = '{product.MeasureType}', Product_price = '{product.Price}', " +
                                                  $"Expiration_date = '{product.ExpirationDate}' " +
                                                  $"WHERE Barcode = '{product.Barcode}'", connection);

                query.ExecuteNonQuery();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }
        }

        public void deleteProduct(string barcode)
        {
            try
            {
                if (connection == null) { throw new Exception("Connection String is Null"); }
                connection.Open();

                SqlCommand query = new SqlCommand("DELETE FROM Product " +
                                                  $"WHERE Barcode = '{barcode}'", connection);

                query.ExecuteNonQuery();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }
        }

        #endregion
    }
}
