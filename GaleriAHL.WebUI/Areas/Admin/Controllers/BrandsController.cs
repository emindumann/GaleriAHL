using GaleriAHL.Business.Abstract;
using GaleriAHL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GaleriAHL.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy ="AdminPolicy")]// sadece admin olmak yetmicek adminpolicy'deki rol'de istenecek
    public class BrandsController : Controller
    {
        private readonly IService<Marka> _service;

        public BrandsController(IService<Marka> service)
        {
            _service = service;//dependecy injection
        }

        // GET: BrandsController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync(); //_service listeyi çektik
            return View(model);//model'i view içerisine gönderdik.
        }

        // GET: BrandsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BrandsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Marka marka)
        {
            try
            {
                await _service.AddAsync(marka);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(marka);
        }

        // GET: BrandsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View();
        }

        // POST: BrandsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Marka marka)
        {
            try
            {
                _service.Update(marka);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(marka);
        }

        // GET: BrandsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: BrandsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Marka marka)
        {
            try
            {
                _service.Delete(marka);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
