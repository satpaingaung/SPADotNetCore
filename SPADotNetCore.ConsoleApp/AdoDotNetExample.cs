using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPADotNetCore.ConsoleApp
{
    internal class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _dbConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "SPADotNetCoreDB",
            UserID = "sa",
            Password = "sa@123"
        };
        
        public void read()
        {
            SqlConnection sqlserverConnection = new SqlConnection(_dbConnectionStringBuilder.ConnectionString);
            sqlserverConnection.Open();
            Console.WriteLine("Connection Open");
            string selectquery = "select * from tbl_Blog";
            SqlCommand cmd = new SqlCommand(selectquery, sqlserverConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            sqlserverConnection.Close();
            Console.WriteLine("Connection Close");

            //all data show from database
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog ID =>" + dr["BlogID"]);
                Console.WriteLine("Blog Title =>" + dr["BlogTitle"]);
                Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content =>" + dr["BlogContent"]);
                Console.WriteLine("--------------------------");
            }
        }
        public void create(string title, string author, string content)
        {
            SqlConnection sqlserverConnection = new SqlConnection(_dbConnectionStringBuilder.ConnectionString);
            sqlserverConnection.Open();

            string insertQuery = @"INSERT INTO [dbo].[tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            SqlCommand cmd = new SqlCommand(insertQuery, sqlserverConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result =cmd.ExecuteNonQuery();

            sqlserverConnection.Close();
        }
    }
}
