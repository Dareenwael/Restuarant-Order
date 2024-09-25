using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Security;
using System.Data;
using System.Data.Common;


namespace Cart1
{
    internal class Database
    {
        public OleDbConnection connection;
        public Database()
        {
           
            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Users\Dareen\Desktop\Bts\Cart123\Cart1\Cart1\Database71.mdb");
            //Change it to your own Path
            this.connection = connection;
        }
        

        public bool CheckUserNameAndPassword(string username, string password)//check in DB
        {
            // checks in db
           connection.Open();

            var query = "SELECT * from `user` where Username = '" + username + "' and Password = '" + password + "'";

            OleDbCommand cmd = new OleDbCommand(query, connection);


            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    connection.Close();
                    return true;
                }
            }
            connection.Close();
            return false;

        }
     

        public bool CheckUserName(string username)//check in DB
        {
            connection.Open();
            
            var query = "SELECT * from `user` where Username = '" + username + "'";

            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read()) 
                {
                    connection.Close();
                    return true;
                }
            }
            connection.Close();
            return false;

        }

        public bool createUser(string username, string password)
        {
            
                // first checks for the username it it is present in the db,
                // return a false, as in process failed
                if (CheckUserName(username))
                {
                    return false;
                }
            // opens a database connection if closed
               connection.Open();
              
                var command = new OleDbCommand("Insert Into `user` ([username], [password]) values (@username, @password)", connection);
                //replaces @username in the query with the given username 
                command.Parameters.AddWithValue("@username", username);
                //replaces @password with the password given
                command.Parameters.AddWithValue("@password", password);

     
            var result = command.ExecuteNonQuery();
            connection.Close();

            if (result == 0) return false;
            return true;

        }

    }
}

