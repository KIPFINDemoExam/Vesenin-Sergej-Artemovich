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
using System.Windows.Shapes;

namespace Session1.forms
{
    /// <summary>
    /// Логика взаимодействия для EditProductForm.xaml
    /// </summary>
    public partial class EditProductForm : Window
    {
		public Products product;
		public EditProductForm(Products p)
        {
			product = p;
            InitializeComponent();
        }

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			txtName.Text = product.Name;
			txtDec.Text = product.Description;
			txtPrice.Text = product.Price;
			txtProiz.Text = product.Proiz;
			if(product.Status == 0)
			{
				cmb.Content = "Неактивен";
				cmb.IsChecked = false;
			}
			else
			{
				cmb.Content = "Активен";
				cmb.IsChecked = true;
			}
		}

		private void BtnCreate_Click(object sender, RoutedEventArgs e)
		{

		}

		private void BtnAddImage_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
