using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoundSharp_I9AO.Models;
using SoundSharp_I9AO.Models.ViewModels;

namespace SoundSharp_I9AO.Controllers
{
    public class Mp3Controller : Controller
    {
        private readonly SoundSharpContext _context;

        public Mp3Controller(SoundSharpContext context)
        {
            _context = context;
        }

        // GET: Mp3
        public async Task<IActionResult> Index()
        {

            List<Mp3ViewModel> mp3Players = new List<Mp3ViewModel>();
            foreach (var mp3 in await _context.Mp3players.Include(m => m.AudioDevice).ToListAsync())
            {
                var model = new Mp3ViewModel
                {
                    Id = mp3.AudioDevice.Id,
                    Btw = mp3.AudioDevice.Btw,
                    Make = mp3.AudioDevice.Make,
                    Model = mp3.AudioDevice.Model,
                    Displayheight = mp3.Displayheight,
                    Displaywidth = mp3.Displaywidth,
                    Mbsize = mp3.Mbsize,
                    OwnerId = mp3.AudioDevice.OwnerId,
                    PriceExBtw = mp3.AudioDevice.PriceExBtw

                };
                mp3Players.Add(model);
            }
            return View(mp3Players);
        }

        // GET: Mp3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mp3 = await _context.Mp3players.Include(m => m.AudioDevice)
                .FirstOrDefaultAsync(m => m.Serialid == id);
            if (mp3 == null)
            {
                return NotFound();
            }
            var model = new Mp3ViewModel
            {
                Id = mp3.AudioDevice.Id,
                Btw = mp3.AudioDevice.Btw,
                Make = mp3.AudioDevice.Make,
                Model = mp3.AudioDevice.Model,
                Displayheight = mp3.Displayheight,
                Displaywidth = mp3.Displaywidth,
                Mbsize = mp3.Mbsize,
                OwnerId = mp3.AudioDevice.OwnerId,
                PriceExBtw = mp3.AudioDevice.PriceExBtw

            };
            return View(model);
        }

        // GET: Mp3/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Lastname");
            return View(new Mp3ViewModel());
        }

        // POST: Mp3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Model,Make,PriceExBtw,Btw,OwnerId,Mbsize,Displaywidth,Displayheight")] Mp3ViewModel mp3ViewModel)
        {
            if (ModelState.IsValid)
            {
                var device = new Audiodevice();
                device.Make = mp3ViewModel.Make;
                device.Model = mp3ViewModel.Model;
                device.PriceExBtw = mp3ViewModel.PriceExBtw;
                device.OwnerId = mp3ViewModel.OwnerId;
                device.Btw = mp3ViewModel.Btw;
                

                await _context.Audiodevices.AddAsync(device);


                var mp3 = new Mp3player()
                {
                    Displayheight = mp3ViewModel.Displayheight,
                    Displaywidth = mp3ViewModel.Displaywidth,
                    Mbsize = mp3ViewModel.Mbsize,
                    AudioDevice = device
                };

                await _context.Mp3players.AddAsync(mp3);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            return View(mp3ViewModel);
        }

        // GET: Mp3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mp3 = await _context.Mp3players.Include(m => m.AudioDevice)
                .FirstOrDefaultAsync(m => m.Serialid == id);
            if (mp3 == null)
            {
                return NotFound();
            }
            var model = new Mp3ViewModel
            {
                Id = mp3.AudioDevice.Id,
                Btw = mp3.AudioDevice.Btw,
                Make = mp3.AudioDevice.Make,
                Model = mp3.AudioDevice.Model,
                Displayheight = mp3.Displayheight,
                Displaywidth = mp3.Displaywidth,
                Mbsize = mp3.Mbsize,
                OwnerId = mp3.AudioDevice.OwnerId,
                PriceExBtw = mp3.AudioDevice.PriceExBtw

            };
            return View(model);
        }

        // POST: Mp3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SerialId,Model,Make,PriceExBtw,Btw,OwnerId,Mbsize,Displaywidth,Displayheight")] Mp3ViewModel mp3ViewModel)
        {
            if (id != mp3ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var device = _context.Audiodevices.FirstOrDefault(d => d.Id == id);

                    device.Make = mp3ViewModel.Make;
                    device.Model = mp3ViewModel.Model;
                    device.Btw = mp3ViewModel.Btw;
                    device.OwnerId = mp3ViewModel.OwnerId;
                    device.PriceExBtw = mp3ViewModel.PriceExBtw;

                    var mp3 = _context.Mp3players.FirstOrDefault(m => m.Serialid == id);
                    mp3.Displayheight = mp3ViewModel.Displayheight;
                    mp3.Displaywidth = mp3ViewModel.Displaywidth;
                    mp3.Mbsize = mp3ViewModel.Mbsize;

                    _context.Update(mp3);
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mp3ViewModelExists(mp3ViewModel.Id))
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
            return View(mp3ViewModel);
        }

        // GET: Mp3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mp3 = await _context.Mp3players.Include(m => m.AudioDevice)
                .FirstOrDefaultAsync(m => m.Serialid == id);
            if (mp3 == null)
            {
                return NotFound();
            }
            var model = new Mp3ViewModel
            {
                Id = mp3.AudioDevice.Id,
                Btw = mp3.AudioDevice.Btw,
                Make = mp3.AudioDevice.Make,
                Model = mp3.AudioDevice.Model,
                Displayheight = mp3.Displayheight,
                Displaywidth = mp3.Displaywidth,
                Mbsize = mp3.Mbsize,
                OwnerId = mp3.AudioDevice.OwnerId,
                PriceExBtw = mp3.AudioDevice.PriceExBtw

            };

            return View(model);
        }

        // POST: Mp3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = await _context.Audiodevices.FindAsync(id);
            _context.Audiodevices.Remove(device);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mp3ViewModelExists(int id)
        {
            return _context.Mp3players.Any(e => e.Serialid == id);
        }
    }
}
