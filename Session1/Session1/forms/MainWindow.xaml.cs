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
using System.Data.SqlClient;
using Session1.forms;

namespace Session1
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Exception ex = MainFunc.LoadProductList();
			if (ex != null)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
			LoadList();
		}
		public void LoadList()
		{
			int ind = 0;
			lsProd1.Items.Clear();
			lsProd2.Items.Clear();
			lsProd3.Items.Clear();
			foreach (Products it in MainFunc.productsList)
			{
				if(ind == 0)
				{
					
					ProductsItem Lsitem = new ProductsItem(it);
					Lsitem.txtName.Text = it.Name;
					Lsitem.txtPrice.Content = it.Price.Trim(new char[] { ' ' }) + " рублей.";
					Lsitem.imgBox.Source = new BitmapImage(new Uri(Environment.CurrentDirectory+@"\images\" + it.ImagesPath));
					Lsitem.Height = 200;
					Lsitem.Width = 200;
					lsProd1.Items.Add(Lsitem);
					ind++;
				}
				else if (ind == 1)
				{
					ProductsItem Lsitem = new ProductsItem(it);
					Lsitem.txtName.Text = it.Name;
					Lsitem.txtPrice.Content = it.Price.Trim(new char[] { ' ' }) + " рублей.";
					Lsitem.imgBox.Source = new BitmapImage(new Uri(Environment.CurrentDirectory+@"\images\" + it.ImagesPath));
					Lsitem.Height = 200;
					Lsitem.Width = 200;
					lsProd2.Items.Add(Lsitem);
					ind++;
				}
				else if (ind == 2)
				{
					ProductsItem Lsitem = new ProductsItem(it);
					Lsitem.txtName.Text = it.Name;
					Lsitem.txtPrice.Content = it.Price.Trim(new char[] { ' ' }) + " рублей.";
					Lsitem.imgBox.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\images\" + it.ImagesPath));
					Lsitem.Height = 200;
					Lsitem.Width = 200;
					lsProd3.Items.Add(Lsitem);
					ind = 0;
				}


			}
		}

		private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
		{
			CreateProductsForm form = new CreateProductsForm();
			form.ShowDialog();
			Exception ex = MainFunc.LoadProductList();
			if (ex != null)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
			LoadList();
		}

		private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
