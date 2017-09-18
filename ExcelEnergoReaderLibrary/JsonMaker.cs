using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelEnergoReaderLibrary
{
	public static class JsonMaker
	{
		public static string JsonSave( List<TableParamStruct> paramList)
		{
			string jsonString = JsonConvert.SerializeObject(paramList);
			//System.Console.Write(jsonString);
			string path = "TableParam2.json";			
			File.WriteAllText(path, jsonString);
			return "successfully";
		}
		public static string JsonSave(List<TableParamStruct> paramList, string path )
		{
			string jsonString = JsonConvert.SerializeObject(paramList);
			//System.Console.Write(jsonString);
			//string path = "TableParam2.json";
			File.WriteAllText(path, jsonString);
			return "successfully";
		}

		public static List<TableParamStruct> JsonLoad(string path)
		{
			//List<TableParamStruct> res = new List<TableParamStruct>();

			FileStream fs = new FileStream(path, FileMode.Open,
			   FileAccess.Read);
			StreamReader sr = new StreamReader(fs, Encoding.UTF8);
			string j_data_string = sr.ReadToEnd();
			sr.Close();
			fs.Close();

			List<TableParamStruct> res  = JsonConvert.DeserializeObject<List<TableParamStruct>>(j_data_string);
			
			return res;
		}
	}
}
