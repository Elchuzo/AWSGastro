using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GastroAvancesWeb.Models;
using System.Collections;
using GastroAvancesWeb.Data;

namespace GastroAvancesWeb.Controllers
{
    public class retirosController : Controller
    {
        private readonly base_pruebaContext _context;
        private readonly ApplicationDbContext _context2;
        public retirosController(base_pruebaContext context, ApplicationDbContext context2)
        {
            _context = context;
            _context2 = context2;
        }

        // GET: retiros
        public async Task<IActionResult> Index()
        {
            var base_pruebaContext = _context.retiro.Include(r => r.id_productoNavigation).Include(r => r.id_usuarioNavigation);
            IEnumerable rets = base_pruebaContext.ToList();
            foreach (retiro ret in rets)
            {
                ret.nombre_usuario = _context2.Users.Find(ret.id_usuario).UserName;
            }
            return View(rets);
        }

        // GET: retiros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retiro = await _context.retiro
                .Include(r => r.id_productoNavigation)
                .Include(r => r.id_usuarioNavigation)
                .FirstOrDefaultAsync(m => m.id_retiro == id);
            if (retiro == null)
            {
                return NotFound();
            }

            return View(retiro);
        }

        // GET: retiros/Create
        public IActionResult Create()
        {
            ViewData["id_producto"] = new SelectList(_context.producto, "id_producto", "id_producto");
            ViewData["id_usuario"] = new SelectList(_context.AspNetUser, "Id", "Id");
            return View();
        }

        // POST: retiros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_retiro,id_usuario,id_producto,fecha,cantidad_inicial,cantidad_retirada,cantidad_final")] retiro retiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_producto"] = new SelectList(_context.producto, "id_producto", "id_producto", retiro.id_producto);
            ViewData["id_usuario"] = new SelectList(_context.AspNetUser, "Id", "Id", retiro.id_usuario);
            return View(retiro);
        }

        // GET: retiros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retiro = await _context.retiro.FindAsync(id);
            if (retiro == null)
            {
                return NotFound();
            }
            ViewData["id_producto"] = new SelectList(_context.producto, "id_producto", "id_producto", retiro.id_producto);
            ViewData["id_usuario"] = new SelectList(_context.AspNetUser, "Id", "Id", retiro.id_usuario);
            return View(retiro);
        }

        // POST: retiros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_retiro,id_usuario,id_producto,fecha,cantidad_inicial,cantidad_retirada,cantidad_final")] retiro retiro)
        {
            if (id != retiro.id_retiro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!retiroExists(retiro.id_retiro))
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
            ViewData["id_producto"] = new SelectList(_context.producto, "id_producto", "id_producto", retiro.id_producto);
            ViewData["id_usuario"] = new SelectList(_context.AspNetUser, "Id", "Id", retiro.id_usuario);
            return View(retiro);
        }

        // GET: retiros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retiro = await _context.retiro
                .Include(r => r.id_productoNavigation)
                .Include(r => r.id_usuarioNavigation)
                .FirstOrDefaultAsync(m => m.id_retiro == id);
            if (retiro == null)
            {
                return NotFound();
            }

            return View(retiro);
        }

        // POST: retiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var retiro = await _context.retiro.FindAsync(id);
            _context.retiro.Remove(retiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool retiroExists(int id)
        {
            return _context.retiro.Any(e => e.id_retiro == id);
        }
    }
}
