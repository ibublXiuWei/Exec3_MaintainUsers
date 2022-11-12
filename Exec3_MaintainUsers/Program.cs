using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Exec3_MaintainUsers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				var Parameters = new SqlParamBuilder().AddNvarchar("name", 50, "Ellen")
													.AddNvarchar("account", 50, "base")
													.AddNvarchar("password", 50, "IN")
													.AddDatetime("dateOfBirth", "1999-11-11")
													.AddInt("height", 199)
													.AddInt("id", 10)
													.Buid();

				var Select_Parameters = new SqlParamBuilder().AddInt("id", 0).Buid();
				Crud crud = new Crud();

				crud.Insert(Parameters);
				crud.Update(Parameters);
				crud.Delete(Parameters);
				crud.Select(Select_Parameters);

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
		public SqlDbHelper Insert(SqlParameter[] parameters)
		{
			string sql = @"INSERT INTO Users(Name, Account,PassWord, DateOfBirth,Height)
							VALUES(@name, @account,@password, @dateOfBirth,@height)";
			return Execute(sql, parameters);
		}
		public SqlDbHelper Update (SqlParameter[] parameters)
		{ 
			string sql = @"UPDATE Users 
							SET Account=@account, PassWord=@password, Height=@height
							,Name=@name , DateOfBirth=@dateOfBirth
							WHERE Id=@Id";
			return Execute(sql, parameters);
		}
		public SqlDbHelper Delete(SqlParameter[] parameters)
		{
			string sql = @"Delete Users WHERE Id=@Id";
			return Execute(sql, parameters);
		}
		private SqlDbHelper Execute(string sql, SqlParameter[] parameters)
		{
			var dbhelper = new SqlDbHelper("default");
			dbhelper.ExecuteNonQuery(sql, parameters);
			return dbhelper;
		}
		public void Select(SqlParameter[] parameters)
		{
			string sql = "SELECT * FROM Users WHERE Id> @Id  ORDER BY Id ASC";
			var dbhelper = new SqlDbHelper("default");
			DataTable news = dbhelper.Select(sql, parameters);

			foreach (DataRow row in news.Rows)
			{
				int id = row.Field<int>("id");
				string name = row.Field<string>("name");
				string account = row.Field<string>("account");
				string password = row.Field<string>("password");
				DateTime dateOfBirth = row.Field<DateTime>("dateOfBirth");
				int height = row.Field<int>("height");
				Console.WriteLine($"Name={name}, Account={account},PassWord={password}," +
					$" DateOfBirth={dateOfBirth},Height={height}");
			}
		}
	}
}
