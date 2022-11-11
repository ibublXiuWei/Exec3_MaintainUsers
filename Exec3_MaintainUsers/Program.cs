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
			//string sql = @"INSERT INTO Users(Name, Account,PassWord, DateOfBirth,Height)
			//				VALUES(@name, @account ,@password , @dateOfBirth ,@height)";
			var dbhelper = new SqlDbHelper("default");
			
			try
			{
				var Parameters = new SqlParamBuilder().AddNvarchar("name", 50, "Liz")
													.AddNvarchar("account",50,"Lizcountt")
													.AddNvarchar("password",50,"66666")
													.AddDatetime("dateOfBirth", "1997-01-9")
													.AddInt("height",164)
													.AddInt("Id",6)
													.Buid();
				Crud crud = new Crud();
				dbhelper.ExecuteNonQuery(crud.Update(), Parameters);
				//dbhelper.ExecuteNonQuery(sql, Parameters);
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
				string sql = @"UPDATE Users 
								SET Account=@account, PassWord=@password, Height=@height
								,Name=@name , DateOfBirth=@dateOfBirth 
								WHERE ID=@ID";
				return sql;
		}
		public string Delete()
		{
			string sql = @"Delete Users WHERE ID=@ID"; 
			return sql;
		}

	}
}
