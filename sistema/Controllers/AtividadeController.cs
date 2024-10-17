using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistema.Contexts;
using sistema.Models;

namespace sistema.Controllers
{
    public class AtividadeController : Controller
    {
        private readonly SistemaContext _context;

        public AtividadeController(SistemaContext context)
        {
            _context = context;
        }
        public IActionResult Index(int turmaId)
        {
            var atividades = _context.Atividades
                .Include(a => a.Turma)
                .Where(a => a.TurmaId == turmaId)
                .ToList();

            var turma = _context.Turmas.FirstOrDefault(t => t.TurmaId == turmaId);

            ViewBag.TurmaId = turmaId;
            ViewBag.NomeTurma = turma!.Nome;
            ViewBag.NomeProfessor = HttpContext.Session.GetString("NomeProfessor");

            return View(atividades);
        }

        [HttpPost]
        public IActionResult CadastrarAtividade(int turmaId, string descricao)
        {
            var turma = _context.Turmas.FirstOrDefault(t => t.TurmaId == turmaId);

            if (turma == null)
            {
                return View();
            }

            var novaAtividade = new Atividade
            {
                TurmaId = turmaId,
                Descricao = descricao
            };

            _context.Atividades.Add(novaAtividade);

            _context.SaveChanges();

            return RedirectToAction("Index", new {turmaId});
        }

    }
}
