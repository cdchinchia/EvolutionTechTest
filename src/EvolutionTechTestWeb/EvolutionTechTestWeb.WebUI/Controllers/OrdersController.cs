using EvolutionTechTestWeb.Core.DTO;
using EvolutionTechTestWeb.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EvolutionTechTestWeb.WebUI.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IRepositoryAsync<OrderDTO> _order;
        public OrdersController(IRepositoryAsync<OrderDTO> order)
        {
            _order = order;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _order.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderDTO itemOrder)
        {
            if (ModelState.IsValid) await _order.CreateAsync(itemOrder);

            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            OrderDTO itemOrder = new OrderDTO();

            if (id == null) return NotFound();

            itemOrder = await _order.GetByIdAsync(id.GetValueOrDefault());

            if (itemOrder == null) return NotFound();

            return View(itemOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, OrderDTO itemOrder)
        {
            if (ModelState.IsValid)
            {
                await _order.UpdateAsync(id, itemOrder);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            OrderDTO itemOrder = new OrderDTO();

            if (id == null) return NotFound();

            itemOrder = await _order.GetByIdAsync(id.GetValueOrDefault());

            if (itemOrder == null) return NotFound();

            return View(itemOrder);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _order.RemoveAsync(id);

            return Json(new { success = true, message = "Borrado correctamente" });

        }
    }
}
