using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
using SeaGo.Models;
using SeaGo.Repositories;

namespace SeaGo.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IPersonRepository _personRepository;

        public AccountController(ICompanyRepository companyRepository, IPersonRepository personRepository)
        {
            _companyRepository = companyRepository;
            _personRepository = personRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Account account)
        {
            if (string.IsNullOrEmpty(account.Identifier) || string.IsNullOrEmpty(account.Password))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View();
            }

            var people = await _personRepository.GetAll();
            var person = people.SingleOrDefault(p => p.CPF == account.Identifier && p.Password == account.Password);

            if (person == null)
            {
                var companies = await _companyRepository.GetAll();
                var company = companies.SingleOrDefault(c => c.CNPJ == account.Identifier && c.Sector == account.Password);

                if (company == null)
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View();
                }

                await SignInUser(account.Identifier, "Company");
                return RedirectToAction("Index", "Home");
            }

            await SignInUser(account.Identifier, "Person");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Person person, Company company, bool isCompany)
        {
            if (isCompany)
            {
                if (ModelState.IsValid)
                {
                    await _companyRepository.Add(company);
                    return RedirectToAction("Login");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await _personRepository.Add(person);
                    return RedirectToAction("Login");
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        private async Task SignInUser(string identifier, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, identifier),
                new Claim(ClaimTypes.Role, role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }
    }
}
