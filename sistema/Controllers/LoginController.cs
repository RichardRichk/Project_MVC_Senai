using Microsoft.AspNetCore.Mvc;
using sistema.Contexts;

namespace sistema.Controllers
{
    public class LoginController : Controller
    {
        private readonly SistemaContext _context;

        public LoginController(SistemaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //ViewBag.NomeProfessor = HttpContext.Session.GetString("NomeProfessor");
            return View();
        }

        [HttpPost]
        public IActionResult Logar(string email, string senha)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Email == email && p.Senha == senha);

            if (professor != null)
            {
                HttpContext.Session.SetInt32("ProfessorId", professor.ProfessorId);
                HttpContext.Session.SetString("NomeProfessor", professor.Nome!);

                return RedirectToAction("Index", "Professor");
            }

            TempData["Mensagem"] = "Email ou senha incorretos, tente novamente!";

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}
