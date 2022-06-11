using EvolutionTechTestWeb.Core.DTO;
using EvolutionTechTestWeb.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EvolutionTechTestWeb.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepositoryAsync<ProductDTO> _product;

        public ProductsController(IRepositoryAsync<ProductDTO> product)
        {
            _product = product ?? throw new ArgumentNullException(nameof(product));

        }

        public async Task<IActionResult> Index()
        {
            return View(await _product.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDTO itemProduct)
        {
            if (ModelState.IsValid) await _product.CreateAsync(itemProduct);

            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ProductDTO itemProduct = new ProductDTO();

            if (id == null) return NotFound();

            itemProduct = await _product.GetByIdAsync(id.GetValueOrDefault());

            if (itemProduct == null) return NotFound();

            return View(itemProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ProductDTO itemProduct)
        {
            if (ModelState.IsValid)
            {
                await _product.UpdateAsync(id, itemProduct);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            ProductDTO itemUser = new ProductDTO();

            if (id == null) return NotFound();

            itemUser = await _product.GetByIdAsync(id.GetValueOrDefault());

            if (itemUser == null) return NotFound();

            return View(itemUser);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _product.RemoveAsync(id);

            return Json(new { success = true, message = "Borrado correctamente" });

        }
    }
}
