using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMyReader.DataClasses
{
	class Manager
	{
		string filePath;
		int SkipHeader;
		int SkipLast;
		int CollCounter;
		public DataTable tableAll;
		public List<KyivEnergoRow> ListKRow = new List<KyivEnergoRow>(); 

		public Manager(string filePath_, int SkipHeader_, int SkipLast_, int CollCounter_)
		{
			filePath = filePath_;
			SkipHeader = SkipHeader_;
			SkipLast = SkipLast_;
			CollCounter = CollCounter_;


			tableAll = new DataTable("KyivEnergo");
			tableAll.Columns.Add("TO", typeof(String));
			tableAll.Columns.Add("Name", typeof(String));
			tableAll.Columns.Add("Tip", typeof(String));
			tableAll.Columns.Add("Tarif", typeof(Double));
			tableAll.Columns.Add("Spojito", typeof(Double));
			tableAll.Columns.Add("Sum", typeof(Double));

			FillTable();
			Print();
		}

		private void FillTable()
		{
			using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
			{
				// Auto-detect format, supports:
				//  - Binary Excel files (2.0-2003 format; *.xls)
				//  - OpenXml Excel files (2007 format; *.xlsx)
				using (var reader = ExcelReaderFactory.CreateReader(stream))
				{
					DataSet dataSet = reader.AsDataSet();

					//відрізаємо шапку
					DataTable preTable = dataSet.Tables[0];
					for (int i = 0; i < SkipHeader; i++)
					{
						preTable.Rows.RemoveAt(0);
					}
					DataTable table = preTable;
					//=============================
					int k = 1;
					foreach (DataRow row in table.Rows)
					{
						//заповнення обєктів моделі 
						KyivEnergoRow kRow = new KyivEnergoRow(); 
						kRow.TO = row[0].ToString().Trim(); 
						kRow.Name = row[1].ToString().Trim();
						kRow.Tip = row[2].ToString().Trim();
						kRow.Tarif = Convert.ToDecimal(row[3]);
						kRow.Spojito = Convert.ToDecimal(row[4]);
						kRow.Sum = Convert.ToDecimal(row[5]);
						ListKRow.Add(kRow);

						//заповнення рядків DataTable
						DataRow DRow = tableAll.NewRow();
						DRow[0] = row[0].ToString().Trim();
						DRow[1] = row[1].ToString().Trim();
						DRow[2] = row[2].ToString().Trim();
						DRow[3] = Convert.ToDecimal(row[3]);
						DRow[4] = Convert.ToDecimal(row[4]);
						DRow[5] = Convert.ToDecimal(row[5]);

						tableAll.Rows.Add(DRow);



						//foreach (DataColumn column in table.Columns)
						//{
						//	String str1 = String.Copy(row[column].ToString().Trim());

						//	if (row[column] != null | str1.Length > 0)
						//	{
						//		String str2 = str1.Replace("\n", " ");
						//		Console.WriteLine($"{str2,-40} \t {column.DataType.ToString()} {str1.Length}");
						//	}
						//}
						k++;
						if (k > SkipLast) break;// просто беремо перших SkipLast записів					
					}

				}//
			}
		}

		public void Print()
		{
			//foreach (DataRow row in tableAll.Rows)
			//{
			//	foreach (DataColumn column in tableAll.Columns)
			//	{
			//		Console.WriteLine ( $"{row[column]}");
			//	}
			//	Console.WriteLine("==================");
			//}

			foreach (KyivEnergoRow item in ListKRow)
			{
				Console.WriteLine(item);
			}
		}
	}
}
