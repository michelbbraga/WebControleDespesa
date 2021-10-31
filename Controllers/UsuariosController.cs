using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleDespesa5.Models;
using ControleDespesa5.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ControleDespesa5.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AplicationContext _context;
        private readonly IUsuarioRespository usuariorespository;

        public UsuariosController(AplicationContext context, IUsuarioRespository usuariorespository)
        {
            _context = context;
            this.usuariorespository = usuariorespository;
        }

        // GET: Usuarios
        public IActionResult Index()
        {
            return View( _context.Usuarios.ToList());
            
        }

        public IActionResult LoginApp()
        {
            return View("LoginApp");
        }

        
        [HttpPost, ActionName("Logar")]
        //[ValidateAntiForgeryToken]
        public IActionResult Logar([Bind ("Login,Senha")]Usuarios usuarios)
        {
            try
            {
                var ValidLogi = usuariorespository.Busca_Usuario2(usuarios.Login, usuarios.Senha);
                if (ValidLogi == true)
                {
                    return View("../Home/Index");
                }


            }
            catch (DbUpdateException)
            {
                throw;
                return View("401");
            }
            //Busca_Usuario
            return View ("Home");
        }

        // GET: Usuarios/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome_Usuario,Sobrenome,Login,Email,Senha,Perfil,Id")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                usuariorespository.Grava_Usuarios(usuarios);
            }
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Nome_Usuario,Sobrenome,Login,Email,Senha,Perfil,Id")] Usuarios usuarios)
        {
            if (id != usuarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.Id))
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
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var usuarios = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuarios);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
