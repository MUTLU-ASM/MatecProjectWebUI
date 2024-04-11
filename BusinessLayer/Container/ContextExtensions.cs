using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class ContextExtensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<ICompanyDal, EfCompanyDal>();
            services.AddScoped<ICompanyService, CompanyManager>();

            services.AddScoped<IProductStockDal, EfProductStockDal>();
            services.AddScoped<IProductStockService, ProductStockManager>();  
            
            services.AddScoped<IProductPriceDal, EfProductPriceDal>();
            services.AddScoped<IProductPriceService, ProductPriceManager>();    
            
            services.AddScoped<IUnitTypeDal, EfUnitTypeDal>();
            services.AddScoped<IUnitTypeService, UnitTypeManager>();
        }
    }
}
