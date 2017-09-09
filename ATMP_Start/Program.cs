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
			Console.OutputEncoding = new UTF8Encoding();			
			string filePath = @"F:\Projects\17. Курсова ExcelReader\ExcelMyReader\ExcelMyReader\Files\Kievenergo012017.xls";

			DataTable table = LoadExcelOneTable.Load(filePath);
			
			List<KeyValuePair<string, string>> listCol = new List<KeyValuePair<string, string>>()
			{
				new KeyValuePair<string, string>("Point", "String"),
				new KeyValuePair<string, string>("PointName", "String"),
				new KeyValuePair<string, string>("PointType", "String"),
				new KeyValuePair<string, string>("Tariff", "Double"),
				new KeyValuePair<string, string>("Consumption", "Double"),
				new KeyValuePair<string, string>("Amount", "Double")
			};
			TableParamStruct param = new TableParamStruct()
			{
				name_ = "TESTMyQuery23",
				oldTable = table,
				colonsNamesTypes = listCol,
				skipHead = 4,
				skipColumn = 0,
				skipSignature = 2,
				countRows = 7
			};
			//Base_ExcelEnergoFormater formater = new Base_ExcelEnergoFormater ("КиївЕнерго" ,table, listCol, 4, 0, 2, 10);
			Base_ExcelEnergoFormater formater = new Base_ExcelEnergoFormater(param);			
			table = formater.shortTable;
			

			//string sConnectionString = @"data source=(localdb)\MSSQLLocalDB;initial catalog=TMPExcel;integrated security = True; App = CodeFirst";
			//SqlConnection objConn = new SqlConnection(sConnectionString);
			//objConn.Open();
			//SqlDataAdapter adapter = new SqlDataAdapter();


			DataSet kyivEnergoDataSet = new DataSet("KyivEnergoDataSet");
			kyivEnergoDataSet.Tables.Add(table);

			//Update(DataSet)
			TMP_DataTable_Printer.Print(table);

			Console.WriteLine("\n\n\n\n");

			string conString = ConfigurationManager.ConnectionStrings["TMPExcel"].ConnectionString;
			string Messaga = AddingNewTable.Push(conString, table, param);

			table.WriteXmlSchema("XmlSchema.txt");

			Console.WriteLine(Messaga);
			Console.ReadLine();
		}
	}
}
