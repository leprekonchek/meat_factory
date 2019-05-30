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

        void deleteSmth(Product product)
        {
            try
            {
                if (connection == null)
                {
                    throw new Exception("Connection String is Null");
                }

                connection.Open();

                SqlCommand query = new SqlCommand(
                    "DELETE FROM Products " +
                    "WHERE Name = '" + product.Name + "'",
                    connection);
                query.ExecuteNonQuery();

            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }

        }

        void selectSmth()
        {
            try
            {
                if (connection == null)
                {
                    throw new Exception("Connection String is Null");
                }

                connection.Open();

                SqlCommand query = new SqlCommand(
                    "SELECT Name_contr FROM Contractor"
                    , connection);

                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    //ListContractors.Add(reader["Name_contr"].ToString().Trim(' '));
                }

                reader.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }
        }

        public List<Product> selectAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                if (connection == null)
                {
                    throw new Exception("Connection String is Null");
                }

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
                    "SELECT * FROM Buyer",
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
                        Price = reader.GetString(4),
                        IsPackage = reader.GetBoolean(5),

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
                    "SELECT * FROM Buyer",
                    connection);

                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    Provisioner provisioner = new Provisioner
                    {
                        EDRPOU = reader.GetString(0),
                        Name = reader.GetString(1),
                        Phone = reader.GetString(2),
                        IsLegal =  reader.GetBoolean(3),
                        Street = reader.GetString(4),
                        BuildingNumber = reader.GetString(5),
                        Town = reader.GetString(6),
                        PostCode = reader.GetString(7),

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
                    "SELECT * FROM Buyer",
                    connection);

                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) 
                {
                    Transport transport = new Transport
                    {
                        AutoNumber = reader.GetString(0),
                        Type = reader.GetString(1),
                        PriceOfPetrol = reader.GetString(2),
                        Driver = reader.GetString(3),
                        

                    };
                    transports.Add(transport);
                }

                reader.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally { connection?.Close(); }

            return transports;
        }

    }
}
