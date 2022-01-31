using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize]
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;
        public CinemasController(ICinemasService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        //GET Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await this._service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get Cienmas/Details/Id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }


        //Get Cinemas/Edit/Id
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await this._service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");

            }
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await this._service.UpdateAsync(id,cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get Cinemas/Delete/Id
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await this._service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");

            }
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await this._service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
