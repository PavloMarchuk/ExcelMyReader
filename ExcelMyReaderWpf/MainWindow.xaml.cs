using ExcelEnergoReaderLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace ExcelMyReaderWpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public List<TableParamStruct> ParamList { get; set; }
		public MainWindow()
		{
			InitializeComponent();
			ParamList = JsonMaker.JsonLoad(@"data\TableParam.json");


			//this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Dictionary1.xaml") };
			
			//this.Resources.Add("paramListWPF", ParamList);
			
			//cbTypes.Items.Add(ParamList[0].name_);
			
			//cbTypes.SelectedIndex = 0;
			//cbTypes.DataSource = 
			//foreach (TableParamStruct item in ParamList)
			//{
			//	cbTypes.Items.Add(item);
			//	cbTypes.Items.
			//}
			//cbTypes.DataContext = paramList;
			//DataContext="{Binding ElementName=paramListWPF, Path=name_}"
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			
			openFileDialog.Filter = "Excel files (*.xls, *.xlsx)|*.xls; *.xlsx"; //|All files (*.*)|*.*
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == true)
			{
				tmpLabel.Content = openFileDialog.FileName;
			}
				//txtEditor.Text = File.ReadAllText(openFileDialog.FileName);			
		}
	}
}
