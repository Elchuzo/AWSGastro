using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GastroAvancesWeb.Models;
using System.Security.Claims;

namespace GastroAvancesWeb.Controllers
{
    public class productosController : Controller
    {
        private readonly base_pruebaContext _context;

        public productosController(base_pruebaContext context)
        {
            _context = context;
        }

        // GET: productos
        public async Task<IActionResult> Index()
        {
            return View(await _context.producto.ToListAsync());
        }

        // GET: productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.producto
                .FirstOrDefaultAsync(m => m.id_producto == id);
            producto.codigo_qr = producto.generarQR();
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        public async Task<IActionResult> Retiro(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Retiro(int id, [Bind("id_producto,nombre,precio_unitario,cantidad,retirado")] producto producto)
        {
            if (id != producto.id_producto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //UserManager<usuario> manager ;
                    retiro ret = new retiro();
                    ret.id_producto = producto.id_producto;
                    var id_usuar = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    ret.id_usuario = int.Parse(id_usuar.ToString());
                    ret.cantidad_retirada = producto.retirado;
                    ret.fecha = DateTime.Now;
                    ret.cantidad_inicial = producto.cantidad;
                    ret.cantidad_final = producto.cantidad - producto.retirado;
                    Console.WriteLine("ACA EL ID DEL USUARIO:" + id_usuar);
                    //ret.id_usuario = await new AccountController(manager).GetCurrentUserId();
                    //_context.retiro.Add();
                    producto.cantidad -= producto.retirado;
                    //_context.Add(retiro)
                    _context.Update(ret);
                    _context.Entry<retiro>(ret).Property(_ => _.id_retiro).IsModified = false;
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!productoExists(producto.id_producto))
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
            return View(producto);
        }

        // GET: productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_producto,nombre,precio_unitario,cantidad")] producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_producto,nombre,precio_unitario,cantidad")] producto producto)
        {
            if (id != producto.id_producto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!productoExists(producto.id_producto))
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
            return View(producto);
        }

        // GET: productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.producto
                .FirstOrDefaultAsync(m => m.id_producto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.producto.FindAsync(id);
            _context.producto.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool productoExists(int id)
        {
            return _context.producto.Any(e => e.id_producto == id);
        }
    }
}
