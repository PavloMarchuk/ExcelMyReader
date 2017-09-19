using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using System.IO;
using System.Data;

namespace ExcelEnergoReaderLibrary
{
	public static class LoadExcelOneTable
	{
		public static  DataTable Load(string path, int listIndex = 0)
		{			 
			using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
			{
				using (var reader = ExcelReaderFactory.CreateReader(stream))
				{					
					DataSet dataSet = reader.AsDataSet();

					//як що лист у файлі стоїть після кількох пустих листів, і це не вказано у TableParamStruct, цей цикл промотає до першого заповненого листа
					foreach (DataTable item in dataSet.Tables)
					{
						if (item.Rows.Count == 0)
						{
							listIndex++;
						}
						else
						{
							break;
						}
					}

					//перевірка чи взагалі у файлі є заповнені рядки
					if (dataSet.Tables.Count == listIndex)
					{
						throw new Exception("Файл path пустий");
					}
					DataTable fullTable = dataSet.Tables[listIndex];
					return fullTable;
				}
			}			
		}
	}
}
