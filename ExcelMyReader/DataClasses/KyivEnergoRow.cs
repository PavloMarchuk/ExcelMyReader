using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ExcelMyReader.DataClasses
{
	class KyivEnergoRow
	{
		public int KyivEnergoRowID { get; set; }
		public string TO { get; set; }
		public string Name { get; set; }
		public string Tip { get; set; }
		public decimal Tarif { get; set; }
		public decimal Spojito { get; set; }
		public decimal Sum { get; set; }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(TO);
			sb.Append($"\n{Name}\n{Tip}\n{Tarif}\n{Spojito}\n{Sum}\n ================\n");
			return sb.ToString();
		}
	}
}
