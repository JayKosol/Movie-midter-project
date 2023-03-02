using Microsoft.Data.SqlClient;
namespace Movie
{
    internal class Dbconnection
    {
        public static SqlConnection Connect()
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = " Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=movie;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;";
                return conn;

            }
            catch(Exception exp)
            {
                
            }
            return null;
        }
    }
}
