using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MatecProjectWebUI.ViewComponents.Product
{
    public class ProductListConditionComponentPartial : ViewComponent
    {
        IProductService _productService;

        public ProductListConditionComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _productService.TGetListIncludeAndWhere();
            return View(values);
        }
    }
}
