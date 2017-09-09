using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using System.Data;

namespace ATMP_Start
{
	public static class TMP_DataTable_Printer
	{		
		public static void Print(DataTable t)
		{
			Console.WriteLine($"Назва таблиці: {t.TableName}\n  ===================");
			Console.WriteLine($"Перелік колонок і їх типів:");
			foreach (DataColumn c in t.Columns)
			{
				Console.Write($"{c.ColumnName, 20}\t {c.DataType} \n");
			}
			Console.WriteLine("==========================");
			foreach (DataRow r in t.Rows)
			{
				foreach (DataColumn c in t.Columns)
				{
					Console.Write($"{r[c]}  ##  ");
				}
				Console.WriteLine("\n==================");
			}
		}
	}
}
