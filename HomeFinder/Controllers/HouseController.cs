using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeFinder.Data;
using HomeFinder.Models;
//using AutoMapper;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace HomeFinder.Controllers
{
    public class HouseController : Controller
    {
        private readonly HomeFinderContext _context;
       // private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ILogger<HouseController> _logger;

        public HouseController(HomeFinderContext context, IWebHostEnvironment hostEnvironment, ILogger<HouseController> logger)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _logger = logger;
            // _mapper = mapper;
        }

        // GET: House/Create
        public IActionResult NewHouse()
        {
          HouseDetailsViewModel houseDetailsViewModel = new HouseDetailsViewModel();

            return View();
        }
        
       
        

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> NewHouse(HouseDetailsViewModel houseDetailsViewModel)
        //{
        //    //HouseDetails houseDetails = _mapper.Map<HouseDetails>(houseDetailsViewModel);


        //    if (ModelState.IsValid)
        //    {
        //        try 
        //        {
        //        string uniqueFileName = HouseImageUpload(houseDetailsViewModel);


        //        HouseDetails houseDetails = new HouseDetails
        //        {
        //            HouseName = houseDetailsViewModel.HouseName,
        //            HouseDescription = houseDetailsViewModel.HouseDescription,
        //            HouseLocation = houseDetailsViewModel.HouseLocation,
        //                HousePrice = houseDetailsViewModel.HousePrice,
        //                HouseType = houseDetailsViewModel.HouseType,
        //               HouseImage = uniqueFileName,
        //        };

        //            _context.Add(houseDetails);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError($"Error saving to the database: {ex.Message}\nStackTrace: {ex.StackTrace}");

        //            return View(houseDetailsViewModel);

        //        }
        //    }
        //    foreach (var modelState in ModelState.Values)
        //    {
        //        foreach (var error in modelState.Errors)
        //        {
        //            _logger.LogError($"Model error: {error.ErrorMessage}");
        //        }
        //    }

        //    return View(houseDetailsViewModel);
        //}


        private string HouseImageUpload(HouseDetailsViewModel houseDetailsViewModel)
        {
            string uniqueFileName = null;

            if (houseDetailsViewModel.HouseImage != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "UploadedImages");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + houseDetailsViewModel.HouseImage.FileName;
                string filepath = Path.Combine(uploadsFolder, uniqueFileName);
                _logger.LogInformation($"Uploading file: {uniqueFileName}, Size: {houseDetailsViewModel.HouseImage.Length} bytes");

                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    houseDetailsViewModel.HouseImage.CopyTo(fileStream);
                }
              
            }
            return uniqueFileName;
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewHouse(HouseDetailsViewModel houseDetailsViewModel)
        {
            if (ModelState.IsValid)
            {

                using (var memoryStream = new MemoryStream())
                {
                    await houseDetailsViewModel.HouseImage.CopyToAsync(memoryStream);


                    if (memoryStream.Length < 2097152)
                    {
                        var houseDetails = new HouseDetails()
                        {
                            ImageName = houseDetailsViewModel.HouseImage.FileName,
                            ImageContent = memoryStream.ToArray(),
                            HouseName = houseDetailsViewModel.HouseName,
                            HouseDescription = houseDetailsViewModel.HouseDescription,
                            HouseLocation = houseDetailsViewModel.HouseLocation,
                            HousePrice = houseDetailsViewModel.HousePrice,
                            HouseType = houseDetailsViewModel.HouseType
                        };

                        _context.Add(houseDetails);
                        await _context.SaveChangesAsync();

                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large");
                    }
                }
                return RedirectToAction(nameof(NewHouse));

            }
            return View();
        
        }


        public IActionResult HouseDatatable()
        {
            return View();
        }
        public JsonResult DisplayHouseDT()
        {
            List<HouseDetails> houseDetails = new List<HouseDetails>();
            try
            {
                houseDetails = _context.HouseDetails.ToList<HouseDetails>();
            }
            catch (Exception ex)
            {

            }
            return Json(houseDetails);
        }



        // GET: House
        public async Task<IActionResult> Index()
        {
            return _context.HouseDetails != null ?
                        View(await _context.HouseDetails.ToListAsync()) :
                        Problem("Entity set 'HomeFinderContext.HouseDetails'  is null.");
        }

        // GET: House/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HouseDetails == null)
            {
                return NotFound();
            }

            var houseDetails = await _context.HouseDetails
                .FirstOrDefaultAsync(m => m.HouseId == id);
            if (houseDetails == null)
            {
                return NotFound();
            }

            return View(houseDetails);
        }


        // POST: House/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("HouseId,HouseName,HouseDescription,HouseType,HouseLocation,HousePrice")] HouseDetails houseDetails)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(houseDetails);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(houseDetails);
        //}

        // GET: House/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HouseDetails == null)
            {
                return NotFound();
            }

            var houseDetails = await _context.HouseDetails.FindAsync(id);
            if (houseDetails == null)
            {
                return NotFound();
            }
            return View(houseDetails);
        }

        // POST: House/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HouseId,HouseName,HouseDescription,HouseType,HouseLocation,HousePrice")] HouseDetails houseDetails)
        {
            if (id != houseDetails.HouseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(houseDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseDetailsExists(houseDetails.HouseId))
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
            return View(houseDetails);
        }

        // GET: House/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HouseDetails == null)
            {
                return NotFound();
            }

            var houseDetails = await _context.HouseDetails
                .FirstOrDefaultAsync(m => m.HouseId == id);
            if (houseDetails == null)
            {
                return NotFound();
            }

            return View(houseDetails);
        }

        // POST: House/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HouseDetails == null)
            {
                return Problem("Entity set 'HomeFinderContext.HouseDetails'  is null.");
            }
            var houseDetails = await _context.HouseDetails.FindAsync(id);
            if (houseDetails != null)
            {
                _context.HouseDetails.Remove(houseDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseDetailsExists(int id)
        {
            return (_context.HouseDetails?.Any(e => e.HouseId == id)).GetValueOrDefault();
        }
    }
}

