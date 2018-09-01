using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Web.NetCoreSwaggerImp.Controllers
{
    public class PersonalInfoesController : Controller
    {
        private readonly AppDBContext _context;
        private readonly string apiURL = "http://localhost:38845/api/personalinfo/";

        public PersonalInfoesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: PersonalInfoes
        public async Task<IActionResult> Index()
        {
            //Using Web API
            var client = new HttpClient();
            var response = client.GetAsync(apiURL + "GetPersonalInfo").Result;
            var personalInfo = response.Content.ReadAsAsync<IEnumerable<PersonalInfo>>().Result;
            return View(personalInfo);


            //Using EF Db repo controller:
            //return View(await _context.PersonalInfo.ToListAsync());
        }

        // GET: PersonalInfoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInfo = await _context.PersonalInfo
                .FirstOrDefaultAsync(m => m.PersonalInfoID == id);
            if (personalInfo == null)
            {
                return NotFound();
            }

            return View(personalInfo);
        }

        // GET: PersonalInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalInfoID,FirstName,LastName,DateOfBirth,City,Country,MobileNo,NID,Email,Status")] PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalInfo);
        }

        // GET: PersonalInfoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInfo = await _context.PersonalInfo.FindAsync(id);
            if (personalInfo == null)
            {
                return NotFound();
            }
            return View(personalInfo);
        }

        // POST: PersonalInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PersonalInfoID,FirstName,LastName,DateOfBirth,City,Country,MobileNo,NID,Email,Status")] PersonalInfo personalInfo)
        {
            if (id != personalInfo.PersonalInfoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalInfoExists(personalInfo.PersonalInfoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personalInfo);
        }

        // GET: PersonalInfoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInfo = await _context.PersonalInfo
                .FirstOrDefaultAsync(m => m.PersonalInfoID == id);
            if (personalInfo == null)
            {
                return NotFound();
            }

            return View(personalInfo);
        }

        // POST: PersonalInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var personalInfo = await _context.PersonalInfo.FindAsync(id);
            _context.PersonalInfo.Remove(personalInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalInfoExists(long id)
        {
            return _context.PersonalInfo.Any(e => e.PersonalInfoID == id);
        }
    }
}
