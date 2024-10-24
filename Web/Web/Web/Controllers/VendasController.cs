﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers
{
    public class VendasController : Controller
    {
        private readonly MeuDbContext _context;

        public VendasController(MeuDbContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var meuDbContext = _context.tb_Venda.Include(v => v.Cliente).Include(v => v.Estoque);
            return View(await meuDbContext.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.tb_Venda
                .Include(v => v.Cliente)
                .Include(v => v.Estoque)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.tb_Cliente, "Id", "Id");
            ViewData["EstoqueId"] = new SelectList(_context.tb_Estoque, "Id", "Id");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,EstoqueId,Nome,Quantidade,DRegistro,Valor")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["pk_idCliente"] = new SelectList(_context.tb_Cliente, "Id", "Id", venda.pk_idCliente);
            ViewData["pk_idEstoque"] = new SelectList(_context.tb_Estoque, "Id", "Id", venda.pk_idEstoque);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.tb_Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["pk_idCliente"] = new SelectList(_context.tb_Cliente, "Id", "Id", venda.pk_idCliente);
            ViewData["pk_idEstoque"] = new SelectList(_context.tb_Estoque, "Id", "Id", venda.pk_idEstoque);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,EstoqueId,Nome,Quantidade,DRegistro,Valor")] Venda venda)
        {
            if (id != venda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.Id))
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
            ViewData["pk_idCliente"] = new SelectList(_context.tb_Cliente, "Id", "Id", venda.pk_idCliente);
            ViewData["pk_idEstoque"] = new SelectList(_context.tb_Estoque, "Id", "Id", venda.pk_idEstoque);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.tb_Venda
                .Include(v => v.Cliente)
                .Include(v => v.Estoque)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.tb_Venda.FindAsync(id);
            if (venda != null)
            {
                _context.tb_Venda.Remove(venda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.tb_Venda.Any(e => e.Id == id);
        }
    }
}
