using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace ExcelMyReader.DataClasses
{
	class MyContextInitializer  : DropCreateDatabaseAlways<KyivEnergoFileContetx>
	{
		protected override void Seed(KyivEnergoFileContetx db)
		{
			KyivEnergoRow tmprow = new KyivEnergoRow()
			{
				TO = "TO 44",
				Name = "Name 44",
				Tip = "typ 444",
				Tarif = 1,
				Spojito = 2,
				Sum = 3
			};

			KyivEnergoRow tmprow2 = new KyivEnergoRow()
			{
				TO = "TO2",
				Name = "Name2",
				Tip = "typ2",
				Tarif = 12,
				Spojito = 22,
				Sum = 32
			};


			db.KyivEnergoRows.AddOrUpdate(tmprow);
			db.KyivEnergoRows.AddOrUpdate(tmprow2);
			db.SaveChanges();
		}
	}
}
