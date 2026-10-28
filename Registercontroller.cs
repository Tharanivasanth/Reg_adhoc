using Microsoft.AspNetCore.Mvc;
using Registration.Models;
using Registration.Service;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace Registration.Controllers
{
    public class Registercontroller : Controller
    {
        private readonly IRegisterService _registerservice;
            public Registercontroller(IRegisterService Registerservice)
        {
            _registerservice=Registerservice;
        }

        
        public async Task<ActionResult> Index()
        {
            var dept = await _registerservice.GetAllSync();
            return View(dept);
        }
        public async Task<ActionResult> Create()
        {

            return View(new Reg());
        }
        public async Task<IActionResult> Edit(int deptID)
        {
            var model = await _registerservice.GetById(deptID);
            if (model == null)
            {
                return NotFound();
            }
            return View("Create", model);  
        }
        public async Task<ActionResult> save(Reg model)
        {
            if (model.Id == null)
            {
                await _registerservice.InsertAsync(model);
            }
            else
            {
                await _registerservice.UpdateAsync(model);
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete(int deptID)
        {
            await _registerservice.DeleteAsync(deptID);
            return RedirectToAction("Index");
        }
    }
}

