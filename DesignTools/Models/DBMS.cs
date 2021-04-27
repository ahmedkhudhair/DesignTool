using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DesignTools.Models
{
    public class DBMS
    {
        public DBMS()
        {

        }
        public DataTable ExecuteSelectQuery(string query)
        {
            Mysql mysqlConnProp = new Mysql();
            DataTable table = new DataTable();
            if (mysqlConnProp.OpenConnection())
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, mysqlConnProp.Connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                table.Load(dataReader);
                mysqlConnProp.CloseConnection();
            }

            return table;
        }
        public bool ExecuteInsertQuery(string query)
        {
            Mysql mysqlConnProp = new Mysql();
            bool ok = false;
            if (mysqlConnProp.OpenConnection())
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, mysqlConnProp.Connection);
                //Create a data reader and Execute the command
                int rowsnumber = cmd.ExecuteNonQuery();
                mysqlConnProp.CloseConnection();
                if (rowsnumber > -1)
                {
                    ok = true;
                }
            }
            return ok;
        }
    }

    public class Mysql
    {
        private MySqlConnection _connection;
        private string _server;
        private string _Port;
        private string _database;
        private string _uid;
        private string _password;

        public MySqlConnection Connection { get => _connection; set => _connection = value; }
        public string Server { get => _server; set => _server = value; }
        public string Port { get => _Port; set => _Port = value; }
        public string Database { get => _database; set => _database = value; }
        public string Uid { get => _uid; set => _uid = value; }
        public string Password { get => _password; set => _password = value; }

        public Mysql()
        {
            Initialize();
        }

        private void Initialize()
        {
            _server = "localhost";
            _Port = "3307";
            _database = "design";
            _uid = "ahmed";
            _password = "ahmed@123";
            string connectionString;
            connectionString = "Server=" + _server + ";Port=" + _Port + ";Database=" + _database + ";Uid=" + _uid + ";Pwd=" + _password + ";";

            _connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                _connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
    }
}