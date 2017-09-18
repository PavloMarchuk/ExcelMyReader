using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using System.Reflection;

namespace ExcelEnergoReaderLibrary
{
	public class Base_ExcelEnergoFormater
	{
		DataTable oldTable;

		public DataTable shortTable{get; set; }

		//public Base_ExcelEnergoFormater(){}
		//workTable.Columns.Add("CustFName", Type.GetType("System.String"))  
		//workTable.Columns.Add("Purchases", Type.GetType("System.Double"))  
		public Base_ExcelEnergoFormater(TableParamStruct param, DataTable oldTable)
		{
			

			//видалення шапки
			for (int i = 0; i < param.skipHead; i++)
				{
					oldTable.Rows.RemoveAt(0);
				}

				// видалення підпису під таблицею
				for (int i = 0; i < param.skipSignature; i++)
				{
					oldTable.Rows.RemoveAt(oldTable.Rows.Count - 1);
				}
			//врахування <роздрукувати всі>
			int paramCountRows = 0;
			if (param.countRows == 0) paramCountRows = (oldTable.Rows.Count);


			//заповнення нової таблиці потрібними колонками
			shortTable = new DataTable(param.name_);
			shortTable.Columns.Add("Id", typeof(int));
			shortTable.Columns[0].AllowDBNull = true;


			foreach (KeyValuePair<string, string> column in param.colonsNamesTypes)
				{
				DataColumn newCollumn = new DataColumn(column.Key, Type.GetType($"System.{column.Value}"));
				newCollumn.AllowDBNull = true;
				shortTable.Columns.Add(newCollumn);
				}

			foreach (DataColumn item in shortTable.Columns)
			{
				Console.WriteLine(item.AllowDBNull);
			}

			//заповнення рядків комірками потрбіних типів даних
			for (int i = 0; i < paramCountRows; i++)
			{
					DataRow newRow = shortTable.NewRow();
					DataRow oldRow = oldTable.Rows[i];

					for (int k = 0; k < param.colonsNamesTypes.Count /*кількість колонок*/; k++)
					{
					
					// переписати потім на делегати
					try
					{
						switch (param.colonsNamesTypes[k].Value)
						{
							case "String":
								newRow[k + 1] = oldRow[param.skipColumn + k].ToString();
								break;
							case "Double":
								newRow[k + 1] = Convert.ToDouble(oldRow[param.skipColumn + k]);
								break;
							case "Int":
								newRow[k + 1] = Convert.ToInt64(oldRow[param.skipColumn + k]);
								break;
							case "DateTime":
								newRow[k + 1] = Convert.ToDateTime(oldRow[param.skipColumn + k]);
								break;
							case "Decimal":
								newRow[k + 1] = Convert.ToDecimal(oldRow[param.skipColumn + k]);
								break;
							default:
								throw new Exception("Помилка в свічі типів Base_ExcelEnergoFormater!!!!");
						}
					}
					catch (Exception)
					{
						//все нормально, значення нуль вже підставлено	
						//newRow[k + 1] = null;
					}
								
					}
				shortTable.Rows.Add(newRow);
			}
		}
	}
}

