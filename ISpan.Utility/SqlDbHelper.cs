using System;
using System.Collections.Generic;
using System.Data;
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
		public DataTable Select(string sql, SqlParameter[] parameters)
		{
			using(var conn=new SqlConnection(ConnString))
			{
				var command=new SqlCommand(sql, conn);
				if(parameters!=null)
				{
					command.Parameters.AddRange(parameters);
				}
				SqlDataAdapter adapter = new SqlDataAdapter(command);
				DataSet dataset=new DataSet();

				adapter.Fill(dataset, "Tablename");

				return dataset.Tables["Tablename"];
			}
		}
	
	}
}
