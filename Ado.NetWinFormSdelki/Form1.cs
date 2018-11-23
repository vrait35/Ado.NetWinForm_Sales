using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ado.NetWinFormSdelki
{
    public partial class Form1 : Form
    {
        string connectSqlServer = ConfigurationManager.ConnectionStrings["vrait34"].ConnectionString;
        string connectionString = ConfigurationManager.ConnectionStrings["vrait35"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string sqlQuery = "CREATE DATABASE MyDatabase142";
            
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectSqlServer);
            using (SqlConnection myConn = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand(sqlQuery, myConn);
                try
                {
                    myConn.Open();
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("БД создалась");
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (SqlException)
                {
                    MessageBox.Show(" бд существует ");
                }

                finally
                {
                    myConn.Close();
                }
            }

            
            builder.ConnectionString = connectionString;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand();
                sql.Connection = connection;
                try
                {                  
                    sql.CommandText = "create table Clients(id_client int primary key,last_name varchar(50),first_name varchar(50))";
                    sql.ExecuteNonQuery();

                    sql.CommandText = "create table Sallers(id_saller int primary key,last_name varchar(50),first_name varchar(50))";
                    sql.ExecuteNonQuery();

                    sql.CommandText = "create table Sales(id_sale int primary key,id_client int foreign key references Clients(id_client)," +
                        "id_saller int foreign key references Sallers(id_saller),price  int)";
                    sql.ExecuteNonQuery();

                    sql.CommandText = "insert into Clients values(1,'федоров','федя')";
                    sql.ExecuteNonQuery();
                    sql.CommandText = "insert into Clients values(2,'сашов','саша')";
                    sql.ExecuteNonQuery();

                    sql.CommandText = "insert into Sallers values(1,'юлива','юля')";
                    sql.ExecuteNonQuery();
                    sql.CommandText = "insert into Sallers values(2,'наташова','наташа')";
                    sql.ExecuteNonQuery();

                    sql.CommandText = "insert into Sales values(1,1,2,80)";
                    sql.ExecuteNonQuery();
                    sql.CommandText = "insert into Sales values(2,2,1,50)";
                    sql.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            //combobox1
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand();
                try
                {
                 //   sql.CommandText = "select*from Sales";
                 //   SqlDataReader reader=  sql.ExecuteReader();
                 //   while (reader.Read())
                 //   {
                 //   }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                    comboBox1.Items.Add("Клиенты");
                    comboBox1.Items.Add("Продавцы");
                    comboBox1.Items.Add("Продажи");
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int numTable = -1;
            try
            {               
                numTable = comboBox1.SelectedIndex;
            }
            catch(ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //MessageBox.Show(numTable.ToString());

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectSqlServer);
            builder.ConnectionString = connectionString;
            
            switch (numTable)
            {
                case 0:
                    {
                        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                        {
                            connection.Open();
                            SqlCommand sql = new SqlCommand();
                            sql.Connection = connection;
                            try
                            {
                                sql.CommandText = "select*from Clients";
                                SqlDataReader reader = sql.ExecuteReader();
                                //dataGridView1.ColumnCount = 3;
                                //dataGridView1.Columns.Add("id_client", "id_saller", "price");
                                dataGridView1.ColumnCount = 3;
                                dataGridView1.Columns.Add("id_client", "id_client");
                                dataGridView1.Columns.Add("id_saller", "id_saller");
                                dataGridView1.Columns.Add("price", "price");
                                dataGridView1.Rows.Add("id_client", "last_name", "first_name");
                                // dataGridView1.Rows.Add("asd","x","");
                                // dataGridView1.Rows.Add("asd","x2");
                                // dataGridView1.Rows.Add("asd","x1");
                                while (reader.Read())
                                {
                                    //dataGridView1.Columns.Add("id_client", reader["id_client"].ToString());
                                    dataGridView1.Rows.Add(reader["id_client"].ToString(), reader["last_name"].ToString(), reader["first_name"].ToString());
                                }
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            catch (InvalidOperationException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                        {
                            connection.Open();
                            SqlCommand sql = new SqlCommand();
                            sql.Connection = connection;
                            try
                            {
                                sql.CommandText = "select*from Sallers";
                                SqlDataReader reader = sql.ExecuteReader();
                                //dataGridView1.ColumnCount = 3;
                                //dataGridView1.Columns.Add("id_client", "id_saller", "price");
                                dataGridView1.ColumnCount = 3;
                                dataGridView1.Columns.Add("id_client", "id_client");
                                dataGridView1.Columns.Add("id_saller", "id_saller");
                                dataGridView1.Columns.Add("price", "price");
                                dataGridView1.Rows.Add("id_saller", "last_name", "first_name");
                                // dataGridView1.Rows.Add("asd","x","");
                                // dataGridView1.Rows.Add("asd","x2");
                                // dataGridView1.Rows.Add("asd","x1");
                                while (reader.Read())
                                {
                                    //dataGridView1.Columns.Add("id_client", reader["id_client"].ToString());
                                    dataGridView1.Rows.Add(reader["id_saller"].ToString(), reader["last_name"].ToString(), reader["first_name"].ToString());
                                }
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            catch (InvalidOperationException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                        {
                            connection.Open();
                            SqlCommand sql = new SqlCommand();
                            sql.Connection = connection;
                            try
                            {
                                sql.CommandText = "select*from Sales";
                                SqlDataReader reader = sql.ExecuteReader();
                                //dataGridView1.ColumnCount = 3;
                                //dataGridView1.Columns.Add("id_client", "id_saller", "price");
                                dataGridView1.ColumnCount = 3;
                                dataGridView1.Columns.Add("id_client", "id_client");
                                dataGridView1.Columns.Add("id_saller", "id_saller");
                                dataGridView1.Columns.Add("price", "price");
                                dataGridView1.Rows.Add("id_client", "id_saller", "price");
                                // dataGridView1.Rows.Add("asd","x","");
                                // dataGridView1.Rows.Add("asd","x2");
                                // dataGridView1.Rows.Add("asd","x1");
                                while (reader.Read())
                                {
                                    //dataGridView1.Columns.Add("id_client", reader["id_client"].ToString());
                                    dataGridView1.Rows.Add(reader["id_client"].ToString(), reader["id_saller"].ToString(), reader["price"].ToString());
                                }
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            catch (InvalidOperationException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                        break;
                    }
            }
        }
    }
}
