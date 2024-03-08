using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using Dapper;
using System.Configuration;
using MISM5104.Models;

namespace MISM5104.Repositories
{
	public class Repository : IRepository
	{
		private readonly string _conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
		public Repository() { }
		private bool Execute(string sql)
		{
			using (var conn = new SqlConnection(_conn))
			{
				return conn.ExecuteAsync(sql).Result > 0;
			}
		}

		private bool ExecuteSp(string storedProcedure, string param)
		{
			using (var conn = new SqlConnection(_conn))
			{
				return conn.ExecuteAsync(storedProcedure, new { param }, commandType: CommandType.StoredProcedure).Result > 0;
			}
		}
		private bool ExecuteSpGrade(string storedProcedure, object paramList)
		{
			using (var conn = new SqlConnection(_conn))
			{
				return conn.ExecuteAsync(storedProcedure, paramList, commandType: CommandType.StoredProcedure).Result > 0;
			}
		}
		private long GetCount(string sql)
		{
			using (var conn = new SqlConnection(_conn))
			{
				return conn.ExecuteScalar<long>(sql);
			}
		}
		private bool Save<T>(string sql, T model)
		{
			using (var conn = new SqlConnection(_conn))
			{
				return conn.ExecuteAsync(sql, model).Result > 0;
			}
		}

		private int SaveRange<T>(string sql, IEnumerable<T> list)
		{
			var affected = 0;
			using (var conn = new SqlConnection(_conn))
			{
				affected += conn.ExecuteAsync(sql, list).Result;
			}

			return affected;
		}

		private IEnumerable<T> GetList<T>(string sql)
		{
			using (var conn = new SqlConnection(_conn))
			{
				return conn.QueryAsync<T>(sql).Result;
			}
		}

		public List<UsersVm> GetUsers()
		{
			var sql = $"select * from Users;";
			return GetList<UsersVm>(sql).ToList();
		}

		public bool SaveUser(UsersVm user)
		{
			var sql = $"Insert into Users ([FullName], [Gender], [Email], [Username], [Password], [UserRole], [CreatedOn], [CreatedBy]) values ( @FullName, @Gender, @Email, @Username, @Password, @UserRole, @CreatedOn, @CreatedBy);";
			return Save(sql,user);
		}
	}
}