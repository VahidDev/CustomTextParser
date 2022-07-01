using CustomTxtParser.Services.Abstraction;
using DomainModels.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CustomTxtParser.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionServices _transactionServices;

        public TransactionController(ITransactionServices transactionServices)
        {
            _transactionServices = transactionServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _transactionServices.GetAllTransactionsAsync());
        }

        [HttpGet]
        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportAsync(TransactionImportViewModel model)
        {
            await _transactionServices.ImportTransactionsAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
