using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelEnergoReaderLibrary;
using ExcelDataReader;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ATMP_Start
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.OutputEncoding = new UTF8Encoding();			
			//string filePath = @"F:\Projects\17. Курсова ExcelReader\ExcelMyReader\ExcelMyReader\Files\Kievenergo012017.xls";

			//DataTable table = LoadExcelOneTable.Load(filePath);

			//List<KeyValuePair<string, string>> listCol = new List<KeyValuePair<string, string>>()
			//{
			//	new KeyValuePair<string, string>("Point", "String"),
			//	new KeyValuePair<string, string>("PointName", "String"),
			//	new KeyValuePair<string, string>("PointType", "String"),
			//	new KeyValuePair<string, string>("Tariff", "Double"),
			//	new KeyValuePair<string, string>("Consumption", "Double"),
			//	new KeyValuePair<string, string>("Amount", "Double")
			//};
			//TableParamStruct param = new TableParamStruct()
			//{
			//	name_ = "TESTMyQuery23",
			//	colonsNamesTypes = listCol,
			//	skipHead = 4,
			//	skipColumn = 0,
			//	skipSignature = 2,
			//	countRows = 0,
			//	listIndex = 0
			//};
			//List < TableParamStruct > tablesParamsList = JsonMaker.JsonLoad(@"F:\Projects\17. Курсова ExcelReader\ExcelMyReader\ATMP_Start\data\TableParam.json");			

			//Base_ExcelEnergoFormater formater = new Base_ExcelEnergoFormater(tablesParamsList[0], table);			
			//table = formater.shortTable;
					

			//string conString = ConfigurationManager.ConnectionStrings["TMPExcel"].ConnectionString;
			//// тут запихую в базу НЕ ВИТИРАТИ
			//string Messaga = AddingNewTable.Push(conString, table, tablesParamsList[0]);
			
			//Console.ReadLine();
		}
	}
}
