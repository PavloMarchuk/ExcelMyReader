using ExcelEnergoReaderLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.Windows.Forms;


namespace ExcelMyReaderWpf
{
	public partial class MainWindow : Window
	{
		public List<TableParamStruct> ParamList { get; set; }
		public ObservableCollection<TableParamStruct> ParamObs { get; set; }
		public MainWindow()
		{
			InitializeComponent();
			ParamList = JsonMaker.JsonLoad(@"data\TableParam.json");			
			//JsonMaker.JsonSave(ParamList, @"data\TableParam.json");
			ParamObs = new ObservableCollection<TableParamStruct>(ParamList);
			cbTypes.ItemsSource = ParamObs;
			if (cbTypes.Items.Count>0)
			{
				cbTypes.SelectedIndex = 0;
			}			
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
			
			openFileDialog.Filter = "Excel files (*.xls, *.xlsx)|*.xls; *.xlsx"; //|All files (*.*)|*.*
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == true)
			{
				string conString = ConfigurationManager.ConnectionStrings["TMPExcel"].ConnectionString;

				string Messaga = AddingNewTable.PushFromPath(conString, openFileDialog.FileName, (TableParamStruct)cbTypes.SelectedItem);

				System.Windows.MessageBox.Show(Messaga);
				JsonMaker.JsonSave(ParamList, @"data\TableParam.json");

			}
						
		}
	}
}
