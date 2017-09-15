using System;
using System.Collections.Generic;
using System.Data;

namespace ExcelEnergoReaderLibrary
{
	public class TableParamStruct
	{
		public String name_;
		//public DataTable oldTable { get; set; }
		public List<KeyValuePair<string, string>> colonsNamesTypes;
		public int skipHead = 0;
		public int skipColumn = 0;
		public int skipSignature = 0;
		public int countRows = 0;
	}
}
