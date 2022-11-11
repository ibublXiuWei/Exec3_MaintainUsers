using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Utility
{
	public class SqlParamBuilder
	{
		private List<SqlParameter> parameters= new List<SqlParameter>();
		public SqlParamBuilder AddNvarchar(string name,int Length ,string value) 
		{  
			var param=new SqlParameter(name, SqlDbType.NVarChar, Length) { Value=value};
			parameters.Add(param);
			return this;
		}
		public SqlParamBuilder AddInt(string name,int value)
		{
			var param=new SqlParameter(name, SqlDbType.Int) { Value=value };
			parameters.Add(param);
			return this;
		}
		public SqlParamBuilder AddDatetime(string Birth, string value)
		{
			var param=new SqlParameter(Birth,SqlDbType.DateTime) { Value= value };
			parameters.Add(param);
			return this;
		}
		public SqlParameter[] Buid()
		{
			return parameters.ToArray();
		}
	}
}
