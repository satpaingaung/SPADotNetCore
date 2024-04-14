
using SPADotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;
using System.Text;

Console.WriteLine("Hello, World!");
//to search package -- nuget.org
//need to add sqlconnection package



/*//DB Connection String Builder
SqlConnectionStringBuilder DBConnectionStringBuilder = new SqlConnectionStringBuilder();
DBConnectionStringBuilder.DataSource = "MDYLPT-0001"; //database servername
DBConnectionStringBuilder.InitialCatalog = "SPADotNetCoreDB"; //database name
DBConnectionStringBuilder.UserID = "sa";
DBConnectionStringBuilder.Password = "sa@123";

SqlConnection sqlserverConnection = new SqlConnection(DBConnectionStringBuilder.ConnectionString);
sqlserverConnection.Open();
Console.WriteLine("Connection Open");
string selectquery = "select * from tbl_Blog";
SqlCommand cmd = new SqlCommand(selectquery, sqlserverConnection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
sqlDataAdapter.Fill (dt);

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
}*/


//CRUD 
AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

adoDotNetExample.create("title","author","content");
adoDotNetExample.read();
Console.ReadLine();