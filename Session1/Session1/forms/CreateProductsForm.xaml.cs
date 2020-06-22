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
using System.Windows.Forms;

namespace Session1.forms
{
	/// <summary>
	/// Логика взаимодействия для CreateProductsForm.xaml
	/// </summary>
	public partial class CreateProductsForm : Window
	{
		public string path;

		public CreateProductsForm()
		{
			InitializeComponent();
		}

		private void BtnAddImage_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.ShowDialog();
			if (fileDialog.FileName != "")
			{
				img.Source = new BitmapImage(new Uri(fileDialog.FileName));
				path = fileDialog.SafeFileName;
			}

		}

		private void BtnCreate_Click(object sender, RoutedEventArgs e)
		{
			if(!String.IsNullOrEmpty(txtName.Text)&& !String.IsNullOrEmpty(txtDec.Text)&&
				!String.IsNullOrEmpty(txtPrice.Text)&& !String.IsNullOrEmpty(txtProiz.Text))
			{
				Products pd = new Products();
				pd.Name = txtName.Text;
				pd.Description = txtDec.Text;
				pd.Price = txtPrice.Text;
				pd.Proiz = txtProiz.Text;
				pd.ImagesPath = path;
				pd.Status = 1;
				Exception ex = MainFunc.AddProduct(pd);
				if (ex != null)
					System.Windows.MessageBox.Show(ex.Message);
				this.Close();
			}
		}
	}
}
