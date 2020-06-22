using Session1.forms;
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

namespace Session1
{
	/// <summary>
	/// Логика взаимодействия для ProductsItem.xaml
	/// </summary>
	public partial class ProductsItem : UserControl
	{
		public Products product;
		public ProductsItem(Products pr)
		{
			product = pr;
			InitializeComponent();
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e)
		{
			EditProductForm form = new EditProductForm(product);
			form.ShowDialog();
		}
	}
}
