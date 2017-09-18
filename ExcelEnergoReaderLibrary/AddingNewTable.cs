using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelEnergoReaderLibrary
{
	public static class AddingNewTable
	{
		public static string PushFromPath(string connectionString, string path, TableParamStruct param)
		{
			DataTable oldTable = LoadExcelOneTable.Load(path, param.listIndex);
			return PushUnformatted( connectionString, oldTable, param);
		}
		public static string PushUnformatted(string connectionString, DataTable oldTable, TableParamStruct param)
		{			
			Base_ExcelEnergoFormater formater = new Base_ExcelEnergoFormater(param, oldTable);
			DataTable table = formater.shortTable;
			return Push(connectionString, table, param);
		}
		public static string Push(string connectionString, DataTable oldTable, TableParamStruct param)
		{
			string resultString = "Успішно додано";				
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string query = GetQueryString(oldTable, param);

				SqlCommand sqlCom = new SqlCommand(query, connection);
				try
				{
					connection.Open();
					sqlCom.ExecuteNonQuery();				
				}
				catch(Exception exc)
				{
					connection.Close();
					resultString = "Таблица не создана" + exc.Message;
				}
				finally { connection.Close(); }
			}

			using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.TableLock))
			{
				bulkCopy.DestinationTableName = oldTable.TableName;
				bulkCopy.WriteToServer(oldTable);
			}
			return resultString;
		}

		private static string GetQueryString(DataTable oldTable, TableParamStruct param)
		{			
			//створення шапки SQL запиту
			StringBuilder query = new StringBuilder
				(
				$"IF OBJECT_ID('{param.name_}', 'U') IS NULL BEGIN CREATE TABLE dbo.{param.name_}  ( Id int not null IDENTITY(1, 1) primary key"
				);			

			// додавання колонок SQL таблиці
			foreach (KeyValuePair<string, string> item in param.colonsNamesTypes)
			{
				query.Append($", [{item.Key}] {ReTyping(item.Value)}");				
			}
			query.Append(") END ");

			//TESTING
			//Console.WriteLine("\n\n\n " + query.ToString());

			return query.ToString(); ;
		}

		private static string ReTyping(string cCharpType)
		{
			
			//переписати потім на делегати:
			string SQLType = "";
			switch (cCharpType)
			{
				case "String":
					SQLType = "NVARCHAR(max)";
					break;
				case "Double":					
					SQLType = "FLOAT";
					break;
				case "Int":
					SQLType = "INT";
					break;
				case "DateTime":
					SQLType = "DATETIME";
					break;
				case "Decimal":
					SQLType = "MONEY";
					break;
					
				default:
					throw new Exception("Помилка в свічі SQL-типів у класі AddingNewTable!!!!");
			}
			return SQLType;
		}
	}
}

//class MyClass
//{
//	public void createsqltable(DataTable dt, string tablename)
//	{
//		string strconnection = "";
//		string table = "";
//		table += "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + tablename + "]') AND type in (N'U'))";
//		table += "BEGIN ";
//		table += "create table " + tablename + "";
//		table += "(";
//		for (int i = 0; i < dt.Columns.Count; i++)
//		{
//			if (i != dt.Columns.Count - 1)
//				table += dt.Columns[i].ColumnName + " " + "varchar(max)" + ",";
//			else
//				table += dt.Columns[i].ColumnName + " " + "varchar(max)";
//		}
//		table += ") ";
//		table += "END";
//		InsertQuery(table, strconnection);
//		CopyData(strconnection, dt, tablename);
//	}
//	public void InsertQuery(string qry, string connection)
//	{
//		SqlConnection _connection = new SqlConnection(connection);
//		SqlCommand cmd = new SqlCommand();
//		cmd.CommandType = CommandType.Text;
//		cmd.CommandText = qry;
//		cmd.Connection = _connection;
//		_connection.Open();
//		cmd.ExecuteNonQuery();
//		_connection.Close();
//	}
//	public static void CopyData(string connStr, DataTable dt, string tablename)
//	{
//		using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connStr, SqlBulkCopyOptions.TableLock))
//		{
//			bulkCopy.DestinationTableName = tablename;
//			bulkCopy.WriteToServer(dt);
//		}
//	}
//}