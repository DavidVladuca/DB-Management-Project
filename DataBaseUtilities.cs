using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace bike
{
    public class DataBaseUtilities
    {
        #region produse
        public List<product> GetProducts1()
        {
            using (bikeStoresEntities context = new bikeStoresEntities())
            {
                return context.products.ToList();
            }
        }
        public List<product> GetProducts2(string searched_text)
        {
            using (bikeStoresEntities context = new bikeStoresEntities())
            {
                return context.products.Where(x => x.product_name.Contains(searched_text)).ToList();
            }
        }

        public product GetProduct(int productID) //method for reading only one product
        {
            using (bikeStoresEntities context=new bikeStoresEntities())
            {
                return context.products.Find(productID);
            }
        }
        public List<product> GetProducts3(string searched_text)
        {
            using (bikeStoresEntities context = new bikeStoresEntities())
            {

                var declared_query = context.products.AsQueryable();
                if (searched_text.Length >= 3)
                {
                    declared_query = declared_query.Where(x => x.product_name.Contains(searched_text));
                }
                declared_query = declared_query.OrderBy(x => x.product_name);
                var data_obtained_from_db = declared_query.ToList();

                return data_obtained_from_db;
            }
        }

        public List<MyProduct> GetProducts4(string searched_text)
        {

            using (bikeStoresEntities context = new bikeStoresEntities())
            {
                var declared_query = from p in context.products
                                     join b in context.brands on p.brand_id equals b.brand_id

                                     join c in context.categories on p.category_id equals c.category_id

                                     select new
                                     {
                                         p.product_id,
                                         p.product_name,
                                         b.brand_name,
                                         c.category_name,
                                         p.model_year,
                                         p.list_price
                                     };


                if (searched_text.Length >= 3)
                {
                    declared_query = declared_query.Where(x =>
                        x.product_name.Contains(searched_text) ||
                        x.brand_name.Contains(searched_text) ||
                        x.category_name.Contains(searched_text));
                }

                declared_query = declared_query.OrderBy(x => x.category_name).ThenBy(x => x.product_name);

                var data_obtained_from_db = declared_query
                    .ToList()
                    .Select(x => new MyProduct()
                    {
                        product_id = x.product_id,
                        product_name = x.product_name,
                        model_year = x.model_year,
                        price = x.list_price,
                        brand_name = x.brand_name,
                        category_name = x.category_name
                    })
                    .ToList();
                return data_obtained_from_db;
            }
        }
        public void DeleteProduct(int id_produs) //delete method 
        {
            using (bikeStoresEntities context = new bikeStoresEntities())
            {
                var product_db = context.products.Find(id_produs);
                if (product_db != null)
                {
                    context.products.Remove(product_db);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateProduct(product p)
        {
            using (bikeStoresEntities context = new bikeStoresEntities())
            {
                var product_db = context.products.Find(p.product_id);
                if (product_db != null)
                {
                    context.Entry(product_db).CurrentValues.SetValues(p);
                    context.Entry(product_db).State = System.Data.Entity.EntityState.Modified;

                    context.SaveChanges();
                }
            }
        }

        
        #endregion
        public List<brand> GetBrands(string searched_text)
        {
            using (bikeStoresEntities context = new bikeStoresEntities())
            {
                var brand_query = from b in context.brands
                                  select b;



                if (searched_text.Length >= 3)
                {
                    brand_query = brand_query.Where(x => x.brand_name.Contains(searched_text));
                }

                var db_data = brand_query.ToList();
                return db_data;
            }

        }

        
    }

    public class MyProduct
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public short model_year { get; set; }
        public decimal price { get; set; }
        public string brand_name { get; set; }
        public string category_name { get; set; }
    }

    public class DbBrands
    {
        public class Brands
        {
            public int brand_id { get; set; }
            public string brand_name { get; set; }
        }

        public List<Brands> GetBrands(string searched_text)
        {
            using (bikeStoresEntities context = new bikeStoresEntities())
            {
                var brand_query = from b in context.brands
                                  select new { b.brand_id, b.brand_name };



                if (searched_text.Length >= 3)
                {
                    brand_query = brand_query.Where(x => x.brand_name.Contains(searched_text));
                }

                var db_data = brand_query
                    .ToList()
                    .Select(x => new Brands()
                    {
                        brand_id = x.brand_id,
                        brand_name = x.brand_name
                    })
                .ToList();
                return db_data;
            }

        }
        
        public string InsertBrand(string brandName)
        {
            using (bikeStoresEntities context = new bikeStoresEntities())
            {
                var newBrand = new brand
                {
                    brand_name = brandName
                };
                context.brands.Add(newBrand);
                context.SaveChanges();
                return brandName;
            }
        }
    }
    [Serializable]
    public class OriginalData
    {
        public string ProductName { get; set; }
        public string ModelYear { get; set; }
        public string Price { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
    }
    public class DbCategorii
    {
        public class Categorii
        {
            public int category_id { get; set; }
            public string category_name { get; set; }

        }

        public List<Categorii> GetCategories(string searched_text)
        {
            using (bikeStoresEntities context = new bikeStoresEntities())
            {
                var query = from c in context.categories
                            select new
                            {
                                c.category_id,
                                c.category_name,
                            };
                if (searched_text.Length >= 3)
                {
                    query = query.Where(x => x.category_name.Contains(searched_text));
                }

                query = query.OrderBy(x => x.category_name);


                var data_db = query
                    .ToList()
                    .Select(x => new Categorii()
                    {
                        category_id = x.category_id,
                        category_name = x.category_name
                    })
                    .ToList();
                return data_db;
            }


        }
        public string InsertCategory(string categoryName)
        {
            using (bikeStoresEntities context = new bikeStoresEntities())
            {
                var newCategory = new category
                {
                    category_name = categoryName
                };

                context.categories.Add(newCategory);
                context.SaveChanges();
                return categoryName;
            }
        }

    }
}


