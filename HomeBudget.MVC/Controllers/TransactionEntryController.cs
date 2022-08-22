using HomeBudget.Contracts;
using HomeBudget.Models.Place;
using HomeBudget.Models.Transaction;
using HomeBudget.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudget.MVC.Controllers
{
    public class TransactionEntryController : Controller
    {
        private readonly ITransactionEntryService _transactionEntryService;

        public TransactionEntryController(ITransactionEntryService transactionEntryService)
        {
            _transactionEntryService = transactionEntryService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var transactions = await _transactionEntryService.GetAllTransactionEntriesBySourceAccountId(id);
            return View(transactions);
        }

        // GET: TransactionEntryController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: TransactionEntryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransactionCreate transactionCreate)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrMsg"] = "Model State is Invalid";
                return View(transactionCreate);
            }
            else
            {
                if (await _transactionEntryService.CreateTransactionEntryAsync(transactionCreate))
                    return RedirectToAction("Index");
            }
            TempData["ErrMsg"] = "Unable to Create the Place. Please try again later.";
            return View(transactionCreate);
        }
    }
}
