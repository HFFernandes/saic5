using System;
using System.Data.SqlClient;
using System.Data;

namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    public class CConn
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public CConn()
        {
        }

        public CConn(CDats cdat)
        {
            try
            {
                connectionString = "Data Source=" + cdat.Server + ";Initial Catalog=" + cdat.Catalog + ";User ID=" +
                                   cdat.User + "; Password=" + cdat.Password;
            }
            catch
            {
            }
        }

        public SqlDataReader EjecQuery(string sql)
        {
            SqlConnection cnn = null;
            SqlDataReader rdr = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cnn = new System.Data.SqlClient.SqlConnection();
                cnn.ConnectionString = connectionString;
                cnn.Open();

                cmd.Connection = cnn;
                cmd.CommandText = sql;
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                    return rdr;
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                cmd.Dispose();
                cnn.Close();
            }
        }

        public DataTable GetData(string sql)
        {
            SqlConnection cnn = null;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                cnn = new System.Data.SqlClient.SqlConnection();
                cnn.ConnectionString = connectionString;
                cnn.Open();

                cmd.Connection = cnn;
                cmd.CommandText = sql;
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.Fill(table);
                return table;
            }
            catch
            {
                return null;
            }
            finally
            {
                cmd.Dispose();
                cnn.Close();
            }
        }

        public bool EjecInsert(string sql)
        {
            SqlConnection cnn = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool flag = false;
                cnn = new System.Data.SqlClient.SqlConnection();
                cnn.ConnectionString = connectionString;
                cnn.Open();

                cmd.Connection = cnn;
                cmd.CommandText = sql;

                if (cmd.ExecuteNonQuery() > 0)
                    flag = true;
                return flag;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                cmd.Dispose();
                cnn.Close();
            }
        }

        public bool EjecUpdate(string sql)
        {
            SqlConnection cnn = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool flag = false;

                cnn = new System.Data.SqlClient.SqlConnection();
                cnn.ConnectionString = connectionString;
                cnn.Open();

                cmd.Connection = cnn;
                cmd.CommandText = sql;

                if (cmd.ExecuteNonQuery() > 0)
                    flag = true;

                return flag;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                cmd.Dispose();
                cnn.Close();
            }
        }

        public bool TestConn(CDats cdat)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = new System.Data.SqlClient.SqlConnection();
                cnn.ConnectionString = "Data Source=" + cdat.Server + ";Initial Catalog=" + cdat.Catalog + ";User ID=" +
                                       cdat.User + "; Password=" + cdat.Password;
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                cnn.Open();
                cnn.Close();
            }
        }


        public bool TestConn()
        {
            try
            {
                SqlConnection cnn;
                cnn = new System.Data.SqlClient.SqlConnection();
                cnn.ConnectionString = connectionString;
                cnn.Open();
                cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                //cnn.Close();
            }
        }
    }
}