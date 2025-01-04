using Microsoft.AspNetCore.Mvc;
using QHRMTest.Data;
using QHRMTest.Models;

namespace QHRMTest.Controllers
{
    public class QHRMProductsController : Controller
    {
        private readonly QHRMProductRepository _repository;

        public QHRMProductsController(IConfiguration configuration)
        {
            _repository = new QHRMProductRepository(configuration.GetConnectionString("DefaultConnection"));
        }

        public IActionResult Index()
        {
            var products = _repository.GetAllProducts();
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(QHRMProducts product)
        {
            if (ModelState.IsValid)
            {
                _repository.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _repository.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(QHRMProducts product)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public IActionResult Details(int id)
        {
            var product = _repository.GetProductById(id);
            return View(product);
        }
            public IActionResult Delete(int id)
                
        {
            var product = _repository.GetProductById(id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
