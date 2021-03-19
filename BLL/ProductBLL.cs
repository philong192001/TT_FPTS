using DAL;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BLL
{

    public class ProductBLL
    {
        private readonly ConnectDB _connectDB;
        public ProductBLL(ConnectDB connectDB)
        {
            _connectDB = connectDB;
        }
        public List<Product> GetAllProduct(){
            
            try
            {
                Product product = new Product();
                DataTable dt = _connectDB.ReadProduct();
                List<Product> products = new List<Product>();
                //var listProducts = dt.Select();
                //for (int i = 0; listProducts != null && i < listProducts.Count(); i++)
                //{
                //    var row = listProducts.ElementAt(i);
                //    int? id = row.Field<int?>("Id");
                //    string name = row.Field<string>("Name");
                //    int? quantity = row.Field<int?>("Quantity");
                //    double? price = row.Field<double?>("Price");
                //    DateTime? CreatedAt = row.Field<DateTime?>("CreatedAt");
                //    string brand = row.Field<string>("brand");
                //    string category = row.Field<string>("category");
                //    products.Add(new Product() { Id = id, Name = name, Quantity = quantity, Price = price, Created_Date = CreatedAt, brand = brand, category = category });
                //}
                //c2
                foreach (DataRow dr in dt.Rows)
                {
                    products.Add(new Product
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Name = string.IsNullOrEmpty(dr["name"].ToString()) ? "" : dr["name"].ToString() ,
                        Price = string.IsNullOrEmpty(dr["price"].ToString()) ? 0 : float.Parse(dr["price"].ToString()),
                        Quantity = string.IsNullOrEmpty(dr["quantity"].ToString()) ? 0 : Convert.ToInt32(dr["quantity"]),
                        //product.brand = dr["brand"].ToString();
                        Id_brands = string.IsNullOrEmpty(dr["id_brands"].ToString()) ? 0 : Convert.ToInt32(dr["id_brands"]),
                        Id_categories = string.IsNullOrEmpty(dr["id_categories"].ToString()) ? 0 : Convert.ToInt32(dr["id_categories"]),
                        Created_Date = string.IsNullOrEmpty(dr["CreatedAt"].ToString()) ? DateTime.Now : DateTime.Parse(dr["CreatedAt"].ToString())
                });
                }
                return products;
            }
            catch (Exception e )
            {
                throw new Exception(e.Message);
            }
         
        }
        public List<Product> GetProductFullJoin()
        {
            try
            {
                Product product = new Product();
                DataTable dt = _connectDB.ProductJoinBrand();
                List<Product> products = new List<Product>();
                foreach(DataRow dr in dt.Rows)
                {
                    products.Add(new Product
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Name = string.IsNullOrEmpty(dr["name"].ToString()) ? "" : dr["name"].ToString(),
                        Price = string.IsNullOrEmpty(dr["price"].ToString()) ? 0 : float.Parse(dr["price"].ToString()),
                        Quantity = string.IsNullOrEmpty(dr["quantity"].ToString()) ? 0 : Convert.ToInt32(dr["quantity"]),
                        Id_brands = string.IsNullOrEmpty(dr["id_brands"].ToString()) ? 0 : Convert.ToInt32(dr["id_brands"]),
                        Id_categories = string.IsNullOrEmpty(dr["id_categories"].ToString()) ? 0 : Convert.ToInt32(dr["id_categories"]),
                        brand = string.IsNullOrEmpty(dr["brand"].ToString()) ? "" : dr["brand"].ToString(),
                        category = string.IsNullOrEmpty(dr["category"].ToString()) ? "" :dr["category"].ToString(),
                        Created_Date = string.IsNullOrEmpty(dr["CreatedAt"].ToString()) ? DateTime.Now : DateTime.Parse(dr["CreatedAt"].ToString())

                    });
                }
                return products;

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void AddProduct(Product product)
        {
           
            //SqlParameter[] sqlParameters = new SqlParameter[6];
            //sqlParameters[0] = new SqlParameter("@NAME", product.Name);
            //sqlParameters[1] = new SqlParameter("@PRICE", product.Price);
            //sqlParameters[2] = new SqlParameter("@QUANTITY", product.Quantity);
            //sqlParameters[3] = new SqlParameter("@ID_CATEGORIES", product.Id_categories);
            //sqlParameters[4] = new SqlParameter("@ID_BRANDS", product.Id_brands);
            //sqlParameters[5] = new SqlParameter("@CREATED_AT", product.Created_Date);
           
            _connectDB.InsertProduct(product);
        }
        public void UpdateProduct(Product product)
        {
            _connectDB.UpdateProduct(product);
        }
        public void DeleteProduct(int? id)
        {
            _connectDB.DeleteProduct(id);
         
        }
        public Product GetProductById(int? id)
        {
            Product product = new Product();
            product.Id = id;
            DataTable dt = _connectDB.GetProductById(id);
            //var myProduct = dt.Select();
            foreach(DataRow dr in dt.Rows)
            {
                product.Id = Convert.ToInt32(dr["id"]);
                product.Name = string.IsNullOrEmpty(dr["name"].ToString()) ? "" : dr["name"].ToString();
                product.Price = string.IsNullOrEmpty(dr["price"].ToString()) ? 0 : float.Parse(dr["price"].ToString());
                product.Quantity = string.IsNullOrEmpty(dr["quantity"].ToString()) ? 0 : Convert.ToInt32(dr["quantity"]);
                product.Id_brands = string.IsNullOrEmpty(dr["id_brands"].ToString()) ? 0 : Convert.ToInt32(dr["id_brands"]);
                product.Id_categories = string.IsNullOrEmpty(dr["id_categories"].ToString()) ? 0 : Convert.ToInt32(dr["id_categories"]);
                product.Created_Date = string.IsNullOrEmpty(dr["CreatedAt"].ToString()) ? DateTime.Now : DateTime.Parse(dr["CreatedAt"].ToString());
            }
            return product;
        }
        public List<Category> AllCategory()
        {
            List<Category> categories = new List<Category>();
            var listCategory = _connectDB.AllCategory();
            foreach (DataRow dr in listCategory.Tables[0].Rows)
            {
                Category category = new Category();
                category.id = Convert.ToInt32(dr["id"]);
                category.name = dr["name"].ToString();
                categories.Add(category);
            }
            return categories;
        }
        public List<Brand> AllBrand()
        {
            List<Brand> list_brand = new List<Brand>();
            var listBrand = _connectDB.AllBrand();
            foreach (DataRow dr in listBrand.Tables[0].Rows)
            {
                Brand brand = new Brand();
                brand.id = Convert.ToInt32(dr["id"]);
                brand.name = dr["name"].ToString();
                list_brand.Add(brand);
            }
            return list_brand;
        }
    }
}
