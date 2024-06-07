using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SeaGo.Models;
using SeaGo.Repositories;

namespace SeaGo.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _companyRepository.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _companyRepository.Get(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {
                await _companyRepository.Add(company);
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _companyRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Company company)
        {
            if (id != company.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _companyRepository.Update(company);
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _companyRepository.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _companyRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
