using Microsoft.AspNetCore.Mvc;
using FinanceApp.Models;
using FinanceApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers
{
  public class ExpensesController : Controller
  {
    private readonly FinanceAppContext _context;
    public ExpensesController(FinanceAppContext context)
    {
      _context = context;
    }

    public async Task<IActionResult> Index()
    {
      var expenses = await _context.Expenses.ToListAsync();
      return View(expenses);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Expense expense)
    {
      if (ModelState.IsValid)
      {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(expense);
    }
  }
}