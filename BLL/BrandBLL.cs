using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
    public class BrandBLL
    {
        private readonly BrandDAL _branddal;
        public BrandBLL(BrandDAL brandDAL)
        {
            _branddal = brandDAL;
        }
        public List<Brand> GetBrand()
        {
            try
            {
                Brand brand = new Brand();
                DataTable dt = _branddal.GetBrand();
                List<Brand> brands = new List<Brand>();
                foreach(DataRow dr in dt.Rows)
                {
                    brands.Add(new Brand{
                        id = Convert.ToInt32(dr["id"]),
                        name = string.IsNullOrEmpty(dr["name"].ToString()) ? "" : dr["name"].ToString(),
                    });
                }
                return brands;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }          
        }
        public void AddBrand(Brand brand)
        {
            _branddal.AddBrand(brand);
        }
        public void DeleteBrand(int? id)
        {
            _branddal.DeleteBrand(id);
        }
        public Brand GetBrandById(int? id)
        {
            Brand brand = new Brand();
           ;
            DataTable dt = _branddal.GetBrandById(id);
            foreach (DataRow dr in dt.Rows)
            {
                brand.id = Convert.ToInt32(dr["id"]);
                brand.name = string.IsNullOrEmpty(dr["name"].ToString()) ? "" : dr["name"].ToString();
                
            }
            return brand;
        }
        public void UpdateBrand(Brand brand)
        {
            _branddal.UpdateBrand(brand);
        }
    }
}
