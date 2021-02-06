using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NordwindContext>, IProductDal
    {
        List<ProductDetailDto> IProductDal.GetProductDetails()
        {
            using (NordwindContext context = new NordwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryID equals c.CategoryID
                             select new ProductDetailDto 
                             {
                                 ProductId=p.ProductID,
                                 CategoryName=c.CategoryName,
                                 ProductName=p.ProductName,
                                 UnitsInStock=p.UnitsInStock
                             };
                return result.ToList();
            }
        }
    }
}
