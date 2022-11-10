using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exec3_MaintainUsers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"INSERT INTO Users(Name, Account,PassWord, DateOfBirth,Height)
							VALUES(@name, @account ,@password , @dateOfBirth ,@height)";
			var dbhelper = new SqlDbHelper("default");

			try
			{
				var Parameters = new SqlParamBuilder().AddNvarchar("name", 50, "Aice")
													.AddNvarchar("account",50,"AiiAaccount")
													.AddNvarchar("password",50,"ji32k7au4a83")
													.AddDatetime("dateOfBirth",new DateTime (2020-2-2) )
													.AddInt("height",178)
													.Buid();
				//Crud insert = new Crud();
				dbhelper.ExecuteNonQuery(sql, Parameters);
				Console.WriteLine("紀錄成功");
			}
			catch(Exception ex)
			{
				Console.WriteLine($"失敗原因：{ex.Message}");
			}
			
		}
	}
	public class Crud
	{
		public string Insert()
		{
			
			string sql = @"INSERT INTO Users(Name, Account,PassWord, DateOfBirth,Height)
							VALUES(@name, @account,@password @dateOfBirth,@height)"; 
			return sql;
		}
		public string Update ()
		{ 
				string sql = $"UPDATE Users SET Height=@height,Name=@name,DateOfBirth=@dateOfBirth " +
				$"WHERE ID=@ID";
				return sql;
		}
		public string Delete()
		{
			string sql = "Delete Users SET Height=@height,Name=@name,DateOfBirth=@dateOfBirth " +
				$"WHERE ID=@ID"; ;
			return sql;
		}

	}
}
