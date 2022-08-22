using HomeBudget.Contracts;
using HomeBudget.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HomeBudget.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        private Guid GetUserId()
        {
            string userIdClaim = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            if (userIdClaim is null) return default;
            return Guid.Parse(userIdClaim);
        }

        private bool SetUserIdInService()
        {
            var userId = GetUserId();
            if (userId == null) return false;

            _accountService.SetUserId(userId);
            return true;
        }

        // GET: AccountController
        public async Task<IActionResult> Index()
        {
            if (!SetUserIdInService()) return Unauthorized();

            var accounts = await _accountService.GetAllAccountsAsync();
            return View(accounts);
        }

        // GET: AccountController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountCreate accountCreate)
        {
            if (!SetUserIdInService()) return Unauthorized();
            else accountCreate.OwnerId = GetUserId();

            if (ModelState.IsValid)
            {
                TempData["ErrMsg"] = "Model State is Invalid";
                return View(accountCreate);
            }
            else
            {
                if (await _accountService.CreateAccountAsync(accountCreate))
                    return RedirectToAction("Index");
            }
            TempData["ErrMsg"] = "Unable to Create the Account. Please try again later.";
            return View(accountCreate);
        }

        // GET: AccountController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            if (id == null) return NotFound();

            var account = await _accountService.GetAccountByIdAsync((int)id);
            if (account == null) return NotFound();

            return View(account);
        }

        // GET: AccountController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            if (!SetUserIdInService()) return Unauthorized();

            var account = await _accountService.GetAccountByIdAsync((int)id);
            if (account is null) return NotFound();


            return View(account);
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AccountEdit model)
        {
            if (!SetUserIdInService()) return Unauthorized();

            if (!ModelState.IsValid || model is null)
            {
                TempData["ErrMsg"] = "Model State is Invalid";
                return View(model);
            }
            if (id != model.Id)
            {
                TempData["ErrMsg"] = "Model Id mismatch";
                return View(model);
            }

            if (await _accountService.UpdateAccountAsync(model))
                return RedirectToAction(nameof(Index));

            TempData["ErrMsg"] = "Unable to update Model to the Database";
            return UnprocessableEntity();
        }

        // GET: AccountController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            if (id == null) return NotFound();

            var account = await _accountService.GetAccountByIdAsync((int)id);
            if (account == null) return NotFound();

            return View(account);
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            if (id <= 0) return NotFound();

            if (await _accountService.DeleteAccountAsync((int)id))
                return RedirectToAction(nameof(Index));
            return UnprocessableEntity(id);
        }
    }
}
