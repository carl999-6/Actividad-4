using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Models; // Asegúrate de usar el espacio de nombres correcto para tu modelo

namespace ApiEmpresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly Conexiones _context;

        public ProductosController(Conexiones context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<productos>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<productos>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, productos producto)
        {
            if (id != producto.id_producto)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<productos>> PostProducto(productos producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducto), new { id = producto.id_producto }, producto);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.id_producto == id);
        }
    }
}
