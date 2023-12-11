using asp_net_parcijalni_ispit_Ivan_Blazun.Data;
using asp_net_parcijalni_ispit_Ivan_Blazun.Models;
using asp_net_parcijalni_ispit_Ivan_Blazun.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Ispit.Todo.Controllers
{
    [Authorize]

    public class ProfilController : Controller
    {
        private readonly UserManager<AspNetUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ProfilController(UserManager<AspNetUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new UpdateViewModel();
            var user = await _userManager.GetUserAsync(User);
            var tasks = await _context.TaskItems.Where(t => t.UserId == user.Id).ToListAsync();

            model.Ime = user.FirstName;
            model.Prezime = user.LastName ;
            model.Adresa = user.Address;
            model.TaskItems = tasks;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateData(UpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                user.FirstName = model.Ime;
                user.LastName = model.Prezime;
                user.Address= model.Adresa;
               var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return View("UpgradeData");
                }
            }
            return View("Error");
        }
    }
}