using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SeaGo.Models;
using SeaGo.Repositories;

namespace SeaGo.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _personRepository.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            var person = await _personRepository.Get(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                await _personRepository.Add(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var person = await _personRepository.Get(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Person person)
        {
            if (id != person.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _personRepository.Update(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var person = await _personRepository.Get(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _personRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
