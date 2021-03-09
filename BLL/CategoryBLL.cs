using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
    public class CategoryBLL
    {
        private readonly CategoryDAL _db;
        public CategoryBLL(CategoryDAL db)
        {
            _db = db;
        }
        public List<Category> GetCategory()
        {
            try
            {
                //Category category = new Category();
                DataTable dt = _db.GetCategory();
                List<Category> categories = new List<Category>();
                foreach (DataRow dr in dt.Rows)
                {
                    categories.Add(new Category
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = string.IsNullOrEmpty(dr["name"].ToString()) ? "" : dr["name"].ToString(),
                    });
                }
                return categories;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void UpdateCategory(Category category)
        {
            _db.UpdateCategory(category);
        }
        public void AddCategory(Category category)
        {
            _db.AddCategory(category);
        }
        public void DeleteCategory(int? id)
        {
            _db.DeleteCategory(id);
        }
        public Category GetCategoryById(int? id)
        {
            Category category = new Category();
            ;
            DataTable dt = _db.GetCategoryById(id);
            foreach (DataRow dr in dt.Rows)
            {
                category.id = Convert.ToInt32(dr["id"]);
                category.name = string.IsNullOrEmpty(dr["name"].ToString()) ? "" : dr["name"].ToString();

            }
            return category;
        }
    }
}
