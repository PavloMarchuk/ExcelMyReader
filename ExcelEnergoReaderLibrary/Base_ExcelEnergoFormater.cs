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
		DataTable fullTable;
		public DataTable shortTable{get; set; }

		//public Base_ExcelEnergoFormater(){}
		//workTable.Columns.Add("CustFName", Type.GetType("System.String"))  
		//workTable.Columns.Add("Purchases", Type.GetType("System.Double"))  
		public Base_ExcelEnergoFormater(TableParamStruct param)
		{
			fullTable = param.oldTable;

				//видалення шапки
				for (int i = 0; i < param.skipHead; i++)
				{
					fullTable.Rows.RemoveAt(0);
				}

				// видалення підпису під таблицею
				for (int i = 0; i < param.skipSignature; i++)
				{
					fullTable.Rows.RemoveAt(fullTable.Rows.Count - 1);
				}
				//врахування <роздрукувати всі>
				if (param.countRows == 0) param.countRows = (fullTable.Rows.Count);


				//заповнення нової таблиці потрібними колонками
				shortTable = new DataTable(param.name_);
				foreach (KeyValuePair<string, string> column in param.colonsNamesTypes)
				{
					shortTable.Columns.Add(column.Key, Type.GetType($"System.{column.Value}"));
				}

				//заповнення рядків комірками потрбяних типів даних
				for (int i = 0; i < param.countRows; i++)
				{
					DataRow newRow = shortTable.NewRow();
					DataRow oldRow = fullTable.Rows[i];
					for (int k = 0; k < param.colonsNamesTypes.Count /*кількість колонок*/; k++)
					{
						// переписати потім на делегати
						switch (param.colonsNamesTypes[k].Value)
						{
							case "String":
								newRow[k] = oldRow[param.skipColumn + k].ToString();
								break;
							case "Double":
								newRow[k] = Convert.ToDouble(oldRow[param.skipColumn + k]);
								break;
							case "Int":
								newRow[k] = Convert.ToInt64(oldRow[param.skipColumn + k]);
								break;
							case "DateTime":
								newRow[k] = Convert.ToDateTime(oldRow[param.skipColumn + k]);
								break;				
						case "Decimal":
							newRow[k] = Convert.ToDecimal(oldRow[param.skipColumn + k]);
							break;
						default:
							throw new Exception("Помилка в свічі типів Base_ExcelEnergoFormater!!!!");
								break;
						}
					}
					shortTable.Rows.Add(newRow);
				}
			}
				
		public Base_ExcelEnergoFormater(String name_, DataTable oldTable, List<KeyValuePair<string, string>> colonsNamesTypes, int skipHead=0, int skipColumn=0, int skipSignature=0, int countRows=0)
		{
			fullTable = oldTable;
						
			//видалення шапки
				for (int i = 0; i < skipHead; i++)
				{
					fullTable.Rows.RemoveAt(0);
				}
			
			// видалення підпису під таблицею
			for (int i = 0; i < skipSignature; i++)
			{
				fullTable.Rows.RemoveAt(fullTable.Rows.Count-1);
			}
			//врахування <роздрукувати всі>
			if (countRows == 0) countRows = (fullTable.Rows.Count);


			//заповнення нової таблиці потрібними колонками
			shortTable = new DataTable(name_);
			foreach (KeyValuePair<string, string> column in colonsNamesTypes)
			{
				shortTable.Columns.Add(column.Key, Type.GetType($"System.{column.Value}"));
			}

			//заповнення рядків комірками потрбяних типів даних
			for (int i = 0; i < countRows; i++)
			{
				DataRow newRow = shortTable.NewRow();
				DataRow oldRow = fullTable.Rows[i];
				for (int k = 0; k < colonsNamesTypes.Count /*кількість колонок*/; k++)
				{
					// переписати потім на делегати
					switch (colonsNamesTypes[k].Value)
					{
						case "String":
							newRow[k] = oldRow[skipColumn + k].ToString();
							break;
						case "Double":
							newRow[k] =  Convert.ToDouble(oldRow[skipColumn + k]);
							break;
						case "Int":
							newRow[k] = Convert.ToInt64(oldRow[skipColumn + k]);
							break;
						case "DateTime":
							newRow[k] = Convert.ToDateTime(oldRow[skipColumn + k]);
							break;

						default:							
							break;
					}			
				}			
				shortTable.Rows.Add(newRow);
			}
		}

	}
}
