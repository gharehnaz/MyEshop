using Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyEshop.Controllers
{
    public class ProductCategoryController : Controller
    {
        public ProductCategorySearchModel SearchModel;
        public List<ProductCategoryViewModel> ProductCategories;

        private readonly IProductCategoryApplication _productCategoryApplication;

        public ProductCategoryController(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;

            //ProductCategories=new List<ProductCategoryViewModel>();

        }
        //public void OnGet(ProductCategorySearchModel searchModel)
        //{
        //    ProductCategories = _productCategoryApplication.Search(searchModel);
        //}
        public IActionResult Index(ProductCategorySearchModel searchModel)
        {
            ProductCategories = _productCategoryApplication.Search(searchModel);

            ProductCategories = _productCategoryApplication.GetProductCategories();

            return View(ProductCategories);
        }

        public IActionResult Create()
        {
            return PartialView(new CreateProductCategory());
        }

        [HttpPost]
        public JsonResult Create(CreateProductCategory command)
        {
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
        }
    }
}
