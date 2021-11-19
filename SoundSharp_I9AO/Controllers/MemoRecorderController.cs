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
    public class MemoRecorderController : Controller
    {
        private readonly SoundSharpContext _context;

        public MemoRecorderController(SoundSharpContext context)
        {
            _context = context;
        }

        // GET: MemoRecorder
        public async Task<IActionResult> Index()
        {
            List<MemoRecorderViewModel> memoRecords = new List<MemoRecorderViewModel>();
            foreach (var memo in await _context.Memorecorders.Include(m => m.AudioDevice).ToListAsync())
            {
                var model = new MemoRecorderViewModel
                {
                    Id = memo.AudioDevice.Id,
                    Btw = memo.AudioDevice.Btw,
                    Make = memo.AudioDevice.Make,
                    Model = memo.AudioDevice.Model,
                    OwnerId = memo.AudioDevice.OwnerId,
                    PriceExBtw = memo.AudioDevice.PriceExBtw,
                    MaxCartridgeType = memo.MaxCartridgeType
                    
                };
                memoRecords.Add(model);
            }
            return View(memoRecords);
        }

        // GET: MemoRecorder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memo = await _context.Memorecorders.Include(m => m.AudioDevice)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memo == null)
            {
                return NotFound();
            }
            var model = new MemoRecorderViewModel
            {
                Id = memo.AudioDevice.Id,
                Btw = memo.AudioDevice.Btw,
                Make = memo.AudioDevice.Make,
                Model = memo.AudioDevice.Model,
                OwnerId = memo.AudioDevice.OwnerId,
                PriceExBtw = memo.AudioDevice.PriceExBtw,
                MaxCartridgeType = memo.MaxCartridgeType

            };
            return View(model);
        }

        // GET: MemoRecorder/Create
        public IActionResult Create()
        {
            List<string> cartridges = new List<string>
            {
                "C60", "C90" , "C120"
            };
            ViewData["MaxCartridgeType"] = new SelectList(cartridges);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Lastname");

            return View();
        }

        // POST: MemoRecorder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Make,PriceExBtw,Btw,OwnerId,MaxCartridgeType")] MemoRecorderViewModel memoRecorderViewModel)
        {
            if (ModelState.IsValid)
            {
                var device = new Audiodevice();
                device.Make = memoRecorderViewModel.Make;
                device.Model = memoRecorderViewModel.Model;
                device.PriceExBtw = memoRecorderViewModel.PriceExBtw;
                device.OwnerId = memoRecorderViewModel.OwnerId;
                device.Btw = memoRecorderViewModel.Btw;


                await _context.Audiodevices.AddAsync(device);


                var memo = new Memorecorder()
                {
                    MaxCartridgeType = memoRecorderViewModel.MaxCartridgeType,
                    AudioDevice = device
                };

                await _context.Memorecorders.AddAsync(memo);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            return View(memoRecorderViewModel);
        }

        // GET: MemoRecorder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memo = await _context.Memorecorders.Include(m => m.AudioDevice)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memo == null)
            {
                return NotFound();
            }
            var model = new MemoRecorderViewModel
            {
                Id = memo.AudioDevice.Id,
                Btw = memo.AudioDevice.Btw,
                Make = memo.AudioDevice.Make,
                Model = memo.AudioDevice.Model,
                OwnerId = memo.AudioDevice.OwnerId,
                PriceExBtw = memo.AudioDevice.PriceExBtw,
                MaxCartridgeType = memo.MaxCartridgeType

            };
            return View(model);
        }

        // POST: MemoRecorder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Make,PriceExBtw,Btw,OwnerId,MaxCartridgeType")] MemoRecorderViewModel memoRecorderViewModel)
        {
            if (id != memoRecorderViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var device = _context.Audiodevices.FirstOrDefault(d => d.Id == id);

                    device.Make = memoRecorderViewModel.Make;
                    device.Model = memoRecorderViewModel.Model;
                    device.Btw = memoRecorderViewModel.Btw;
                    device.OwnerId = memoRecorderViewModel.OwnerId;
                    device.PriceExBtw = memoRecorderViewModel.PriceExBtw;

                    var memo = _context.Memorecorders.FirstOrDefault(m => m.Id == id);
                    memo.MaxCartridgeType = memoRecorderViewModel.MaxCartridgeType;


                    _context.Update(memo);
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemoRecorderViewModelExists(memoRecorderViewModel.Id))
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
            return View(memoRecorderViewModel);
        }

        // GET: MemoRecorder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memo = await _context.Memorecorders.Include(m => m.AudioDevice)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memo == null)
            {
                return NotFound();
            }
            var model = new MemoRecorderViewModel
            {
                Id = memo.AudioDevice.Id,
                Btw = memo.AudioDevice.Btw,
                Make = memo.AudioDevice.Make,
                Model = memo.AudioDevice.Model,
                OwnerId = memo.AudioDevice.OwnerId,
                PriceExBtw = memo.AudioDevice.PriceExBtw,
                MaxCartridgeType = memo.MaxCartridgeType

            };
            return View(model);
        }

        // POST: MemoRecorder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = await _context.Audiodevices.FindAsync(id);
            _context.Audiodevices.Remove(device);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemoRecorderViewModelExists(int id)
        {
            return _context.Memorecorders.Any(e => e.Id == id);
        }
    }
}
