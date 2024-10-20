using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactContext context;

        public ContactsController(ContactContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            ViewBag.Categories = context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(new Contact());
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.DateAdded = DateTime.Now;
                context.Contacts.Add(contact);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Action = "Create";
            ViewBag.Categories = context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(contact);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                context.Contacts.Update(contact);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(contact);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact != null)
            {
                context.Contacts.Remove(contact);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(m => m.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            context.Contacts.Remove(contact);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
