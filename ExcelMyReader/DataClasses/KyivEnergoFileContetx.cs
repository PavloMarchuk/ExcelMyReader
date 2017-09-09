using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMyReader.DataClasses
{
	class KyivEnergoFileContetx: DbContext
	{
		public KyivEnergoFileContetx():base("name=TMPExcel")
        {
			Database.SetInitializer<KyivEnergoFileContetx>(new MyContextInitializer());
		}

		public DbSet<KyivEnergoRow> KyivEnergoRows { get; set; }
	}
}
