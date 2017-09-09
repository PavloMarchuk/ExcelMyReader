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
		public static  DataTable Load(string path, int tableIndex=0)
		{			 
			using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
			{
				using (var reader = ExcelReaderFactory.CreateReader(stream))
				{
					DataSet dataSet = reader.AsDataSet();
					DataTable fullTable = dataSet.Tables[tableIndex];
					//fullTable.WriteXmlSchema("XmlSchema.txt");
					return fullTable;
				}
			}			
		}
	}
}
