using EvolutionTechTestWeb.Core.DTO;
using EvolutionTechTestWeb.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EvolutionTechTestWeb.WebUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRepositoryAsync<UserDTO> _user;

        public UsersController(IRepositoryAsync<UserDTO> user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
        }

        public async Task<IActionResult> Index()
        {
            return View(await _user.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDTO itemUser)
        {
            if(ModelState.IsValid) await _user.CreateAsync(itemUser);

            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            UserDTO itemUser = new UserDTO();

            if (id == null) return NotFound();

            itemUser = await _user.GetByIdAsync(id.GetValueOrDefault());

            if(itemUser == null) return NotFound();

            return View(itemUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UserDTO itemUser)
        {
            if (ModelState.IsValid)
            {
                await _user.UpdateAsync(id, itemUser);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            UserDTO itemUser = new UserDTO();

            if (id == null) return NotFound();

            itemUser = await _user.GetByIdAsync(id.GetValueOrDefault());

            if (itemUser == null) return NotFound();

            return View(itemUser);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
             await _user.RemoveAsync(id);

             return Json(new { success = true, message = "Borrado correctamente" });
            
        }
    }
}
