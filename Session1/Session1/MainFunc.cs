using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;


namespace Session1
{
	public struct Products
	{
		public int Id;
		public string Name;
		public string Description;
		public string Price;
		public string ImagesPath;
		public string Proiz;
		public int Status;
		public string AddProducts;
	}

	public static class MainFunc
	{
		public static List<Products> productsList = new List<Products>();
		public static string ConnStr = @"Data Source=DESKTOP-M591BD6\SQLEXPRESS;Initial Catalog=Session1;Integrated Security=True";
		public static Exception LoadProductList()
		{
			SqlConnection conn = null;
			try
			{
				productsList.Clear();
				conn = new SqlConnection(ConnStr);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = "Select * From Products";
				SqlDataReader rd = cmd.ExecuteReader();
				if (rd.HasRows)
					while (rd.Read())
					{
						Products pr = new Products();
						pr.Id = Int32.Parse(rd.GetValue(0).ToString());
						pr.Name = rd.GetValue(1).ToString();
						pr.Description = rd.GetValue(2).ToString();
						pr.Price = rd.GetValue(3).ToString();
						pr.Proiz = rd.GetValue(5).ToString();
						pr.Status = Int32.Parse(rd.GetValue(6).ToString());
						pr.AddProducts = rd.GetValue(7).ToString();
						pr.ImagesPath = rd.GetValue(4).ToString(); 
						productsList.Add(pr);
					}
			}
			catch(Exception ex)
			{
				return ex;
			}
			finally
			{
				conn.Close();
			}
			return null;
		}
		public static Exception DeleteProduct(int id)
		{
			SqlConnection conn = null;
			try
			{
				productsList.Clear();
				conn = new SqlConnection(ConnStr);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = "Delete From Products where id="+id;
				int i = cmd.ExecuteNonQuery();
				if (i != 0)
				{
					MessageBox.Show("Продукт удален!", "Уведомление!");
				}

			}
			catch (Exception ex)
			{
				return ex;
			}
			finally
			{
				conn.Close();
			}
			return null;
		}
		public static Exception AddProduct(Products pr)
		{
			SqlConnection conn = null;
			try
			{
				productsList.Clear();
				conn = new SqlConnection(ConnStr);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = "Insert into Products values('"+pr.Name+"','"+pr.Description+"','"+pr.Price+"','"+pr.ImagesPath+"','"+pr.Proiz+"',"+pr.Status+",'"+pr.AddProducts+"')";
				int i = cmd.ExecuteNonQuery();
				if (i != 0)
				{
					MessageBox.Show("Продукт создан!", "Уведомление!");
				}
			}
			catch (Exception ex)
			{
				return ex;
			}
			finally
			{
				conn.Close();
			}
			return null;
		}

	}
}
