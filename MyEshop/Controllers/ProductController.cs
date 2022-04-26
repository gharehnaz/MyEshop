using Application.Contracts.Product;
using Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyEshop.Controllers
{
    public class ProductController : Controller
    {
        [TempData] public string Message { get; set; }
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products;
        public SelectList ProductCategories;

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public ProductController(IProductApplication productApplication,
            IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
            
        }

      
        public IActionResult Index(ProductSearchModel searchModel)
        {
            
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            Products = _productApplication.Search(searchModel);

            return View(Products);
        }

        public IActionResult Create()
        {
            var command = new CreateProduct
            {
                Categories = _productCategoryApplication.GetProductCategories()
            };
            return PartialView(command);
        }

        [HttpPost]
        public IActionResult Create(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult Edit(long id)
        {
            var product = _productApplication.GetDetails(id);
            product.Categories = _productCategoryApplication.GetProductCategories();
            return PartialView("Edit",product);
        }

        [HttpPost]
        public JsonResult Edit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult Remove(long id)
        {
            var result = _productApplication.Remove(id);
            if (result.IsSuccedded)
                return Redirect("Index");

            Message = result.Message;
            return Redirect("Index");
        }

    }
}
