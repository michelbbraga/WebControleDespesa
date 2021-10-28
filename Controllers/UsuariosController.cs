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

        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public void Logar([Bind ("Login,Senha")]Usuarios usuarios)
        {
            try
            {
                usuariorespository.Busca_Usuario(usuarios.Login, usuarios.Senha);
                //return View("LoginApp");
                
            }
            catch (DbUpdateException)
            {
                throw;
            }
            //Busca_Usuario
            //return View("LoginApp");
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
        //[httppost]
        //[validateantiforgerytoken]
        //public iactionresult create([bind("nome_usuario,sobrenome,login,email,senha,perfil,id")] usuarios usuarios)
        //{
        //    if (modelstate.isvalid)
        //    {
        //        _context.add(usuarios);
        //        _context.savechangesasync();
        //        return redirecttoaction(nameof(index));
        //    }
        //    return view(usuarios);
        //}

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
                    _context.SaveChangesAsync();
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
