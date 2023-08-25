using GaleriAHL.Business.Abstract;
using GaleriAHL.Business.Concrete;
using GaleriAHL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GaleriAHL.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class UsersController : Controller
    {
        private readonly IService<Kullanici> _service;
        private readonly IService<Rol> _serviceRol;//kullanıcı oluştur sayfasında rol seçeneklerinde viewbag beklediği için veriyi almak üzerine bir servis oluşturduk.

        public UsersController(IService<Kullanici> service, IService<Rol> serviceRol)
        {
            _service = service;
            _serviceRol = serviceRol;
        }

        // GET: UsersController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync(); //_service listeyi çektik
            return View(model);//model'i view içerisine gönderdik.
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsync(),"Id","Ad");//datavalue ve datatextfield. entites rol'deki tabloları yansıttım.
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Kullanici kullanici)
        {
            if (ModelState.IsValid)//model control
            {
                try
                {
                    await _service.AddAsync(kullanici);//kullanıcı eklenmek üzerine işaretlenir
                    await _service.SaveAsync();// kaydedilir.
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!"); //ilk "" proprerty, "" ikinci tırnak genel
                }
            }
            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsync(), "Id", "Ad");
            return View(kullanici);
        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsync(), "Id", "Ad");
            return View(model);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Kullanici kullanici)
        {
            if (ModelState.IsValid)//model control
            {
                try
                {
                    _service.Update(kullanici);//kullanıcı eklenmek üzerine işaretlenir
                    await _service.SaveAsync();// kaydedilir.
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!"); //ilk "" proprerty, "" ikinci tırnak genel
                }
            }
            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsync(), "Id", "Ad");
            return View(kullanici);
        }

        // GET: UsersController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Kullanici kullanici)//ekranda kullanıcı gelir
        {
            try
            {
                _service.Delete(kullanici);
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
