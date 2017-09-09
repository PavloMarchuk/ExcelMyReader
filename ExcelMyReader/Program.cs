using ExcelDataReader;
using ExcelMyReader.DataClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using ExcelEnergoReaderLibrary;

namespace ExcelMyReader
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = new UTF8Encoding();
			//ExcelDataReader.
			string filePath = @"F:\Projects\17. Курсова ExcelReader\ExcelMyReader\ExcelMyReader\Files\Kievenergo012017.xls";
			
			
			int SkipHeader = 4;
			int SkipLast =5;
			int CollCounter = 6;


			Manager manager = new Manager( filePath,  SkipHeader,  SkipLast,  CollCounter);

			KyivEnergoFileContetx context = new KyivEnergoFileContetx();
			
			//context.KyivEnergoUsers.AddOrUpdate(tmprow);
			//context.SaveChanges();


			//foreach (var item in manager.ListKRow)
			//{
			//	context.KyivEnergoUsers.AddOrUpdate(item);
			//	context.SaveChanges();
			//}

			//

			var tmp = context.KyivEnergoRows;
			foreach (var i in tmp)
			{
				Console.WriteLine(i);
			}
		}
	}
}




//			using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
//			{
//				// Auto-detect format, supports:
//				//  - Binary Excel files (2.0-2003 format; *.xls)
//				//  - OpenXml Excel files (2007 format; *.xlsx)
//				using (var reader = ExcelReaderFactory.CreateReader(stream))
//				{
//					DataSet dataSet = reader.AsDataSet();

////відрізаємо шапку
//DataTable preTable = dataSet.Tables[0];
//					for (int i = 0; i<SkipHeader; i++)
//					{
//						preTable.Rows.RemoveAt(0);
//					}
//					DataTable table = preTable;

//int k = 1;
//					foreach (DataRow row in table.Rows)
//						{
//							foreach (DataColumn column in table.Columns)
//							{							
//							String str1 = String.Copy(row[column].ToString().Trim());

//								if (row[column] != null | str1.Length > 0)
//								{									
//									String str2 = str1.Replace("\n", " ");
//Console.WriteLine($"{str2,-40} \t {column.DataType.ToString()} {str1.Length}");
//								}
//							}
//							k ++;
							
//							if (k > SkipLast) break;// просто беремо перших SkipLast записів

//						Console.WriteLine($"===============  {k-1}");
//						}

//				}//
//			}
