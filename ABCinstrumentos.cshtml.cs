using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyec_Tienda_musica.Modelos;
using System.Diagnostics.Metrics;

namespace Proyec_Tienda_musica.Pages
{
    // PageModel de la página ABCinstrumentos.
    // Gestiona las operaciones CRUD sobre la tabla Instrumentos:
    // Alta, Consulta, Actualización y Baja de registros.
    public class ABCinstrumentosModel : PageModel
    {
        // Instancia del contexto de base de datos inyectada por el constructor.
        // Se declara como readonly para evitar reasignaciones accidentales.
        private readonly DBContext _context;

        // CORRECTO: List<Tienda>, no List<ABCinstrumentosModel>
        public List<Tienda> Instrumentos { get; set; } = new List<Tienda>();

        // Propiedad enlazada al formulario de Alta.
        // [BindProperty] vincula automáticamente los campos del formulario HTML
        // con las propiedades del objeto al recibir una solicitud POST.
        [BindProperty]
        public Tienda NuevoInstrumento { get; set; }

        // Propiedad enlazada al formulario de Edición.
        // Recibe los datos del instrumento que se desea actualizar.
        [BindProperty]
        public Tienda InstrumentoEditar { get; set; }

        // Constructor que recibe el DBContext mediante Inyección de Dependencias.
        // ASP.NET Core resuelve automáticamente esta dependencia gracias
        // al registro realizado en Program.cs con AddDbContext.
        public ABCinstrumentosModel(DBContext context)
        {
            _context = context;
        }

        // Método que se ejecuta en cada solicitud GET a la página.
        // Recupera todos los registros de la tabla Instrumentos en SQL Server
        // y los asigna a la propiedad Instrumentos para mostrarlos en la vista.
        public void OnGet()
        {
            Instrumentos = _context.Instrumentos.ToList();
        }

        // Handler POST para el Alta de un nuevo instrumento.
        // Se activa cuando el formulario con asp-page-handler="Agregar" es enviado.
        // Agrega el objeto NuevoInstrumento a la tabla y guarda los cambios en la BD.
        public IActionResult OnPostAgregar()
        {
            _context.Instrumentos.Add(NuevoInstrumento);
            _context.SaveChanges();
            return RedirectToPage();
        }

        // Handler POST para la Actualización de un instrumento existente.
        // Se activa cuando el formulario con asp-page-handler="Editar" es enviado.
        // Busca el registro por Id y actualiza únicamente sus campos editables.
        public IActionResult OnPostEditar()
        {
            var item = _context.Instrumentos.Find(InstrumentoEditar.Id);
            if (item != null)
            {
                item.Instrumento_Nombre = InstrumentoEditar.Instrumento_Nombre;
                item.Marca = InstrumentoEditar.Marca;
                item.Descripcion = InstrumentoEditar.Descripcion;
                item.Precio = InstrumentoEditar.Precio;
                item.Existencia = InstrumentoEditar.Existencia;
                _context.SaveChanges();
            }
            return RedirectToPage();
        }

        // Handler POST para la Baja de un instrumento.
        // Se activa cuando el formulario con asp-page-handler="Eliminar" es enviado.
        // Recibe el Id del registro a eliminar como parámetro de ruta (asp-route-id).
        public IActionResult OnPostEliminar(int id)
        {
            var item = _context.Instrumentos.Find(id);
            if (item != null)
            {
                _context.Instrumentos.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }

    }
}
