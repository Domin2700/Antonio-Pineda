using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domingo_Ant._Pineda.Context;
using Domingo_Ant._Pineda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Domingo_Ant._Pineda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController (ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpPost("InsertUsuario")]
        public async Task<IActionResult> InsertUsuario ([FromBody] Usuario usuarioInfo)
        {
            if (ModelState.IsValid)
            {
                var usuarioExiste = await _context.Usuario.AnyAsync(a => a.Cedula == usuarioInfo.Cedula);
                if (usuarioExiste)
                {
                    ModelState.AddModelError("Mensaje", "Esta cedula ya existe");
                    return BadRequest(ModelState);
                }
                await _context.Usuario.AddAsync(usuarioInfo);
                int x = await _context.SaveChangesAsync();

                if (x > 0)
                {
                    return Ok();
                }
                else
                {
                    ModelState.AddModelError("Mensaje", "Error al guardar los datos");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                ModelState.AddModelError("Mensaje", ModelState.ToString());
                return BadRequest(ModelState);
            }
        }


        [HttpGet("GetDepartamentos")]
        public async Task<ActionResult<Departamento>> GetDepartamentos ()
        {
            var departamentos = await _context.Departamento.ToListAsync();
            return Ok(departamentos);
        }

    }
}
