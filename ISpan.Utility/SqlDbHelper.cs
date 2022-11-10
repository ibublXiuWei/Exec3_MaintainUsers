using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Utility
{
	
	public class SqlDbHelper
	{
		private string ConnString;
		public SqlDbHelper (string KeyConnString) 
		{ 
			ConnString= System.Configuration.ConfigurationManager.ConnectionStrings[KeyConnString].ConnectionString;
		}
		public void ExecuteNonQuery(string sql, SqlParameter[]parameters)
		{
			using(var conn = new SqlConnection(ConnString))
			{
				SqlCommand command=new SqlCommand(sql, conn);
				conn.Open();
				command.Parameters.AddRange(parameters);
				command.ExecuteNonQuery();
			}
			
		}
	}
}
