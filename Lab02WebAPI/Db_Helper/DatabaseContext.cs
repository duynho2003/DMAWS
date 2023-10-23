using System.Data.SqlClient;

namespace Lab02WebAPI.Db_Helper
{
    public class DatabaseContext
    {
        string connectdb = "server=duy2003.database.windows.net;database=duy2003;uid=duy2003;pwd=Anhduy0211";
        public SqlConnection setConnectDB()
        {
            var conn = new SqlConnection(connectdb);
            return conn;
        }
    }
}
