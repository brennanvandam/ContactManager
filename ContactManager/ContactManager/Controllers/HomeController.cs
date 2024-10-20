using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactContext _context;

        public HomeController(ContactContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contacts = _context.Contacts
                .Include(c => c.Category) 
                .OrderBy(c => c.Firstname) 
                .ToList();

            return View(contacts); 
        }
    }
}
