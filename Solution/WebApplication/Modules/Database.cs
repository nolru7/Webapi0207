using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Modules
{
    public class Database
    {
        private MySqlConnection conn;
        private bool status;

        public Database()
        {
            status = Connection();
        }

        private bool Connection()
        {
            string host = "192.168.3.149";
            string user = "root";
            string password = "1234";
            string db = "gudi";
            //string port = "";
            string connStr = string.Format("server={0};uid={1};password={2};database={3};port={4}", host, user, password,db/*,port*/);
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                this.conn = conn;
                return true;
            }
            catch
            {
                conn.Close();
                this.conn = null;
                return false;
            }
        }

        public bool ConnectionClose()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool NonQuery(string sql)
        {
            try
            {
                if (status)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    comm.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public MySqlDataReader Reader(string sql)
        {
            try
            {
                if (status)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    
                    return comm.ExecuteReader();
                }
                else
                {
                    
                    return null;
                }
            }
            catch
            {
                
                return null;
            }

        }

        public MySqlDataReader Test(string sql)
        {
            MySqlCommand comm = new MySqlCommand(sql, conn);
            return comm.ExecuteReader();
            //Console.WriteLine(sql);
        }
        public void ReaderClose(MySqlDataReader reader)
        {
            reader.Close();
        }
    }
}