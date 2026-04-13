using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Proyec_Tienda_musica.Modelos
{
    public class Tienda
    {
        // Clase que representa la entidad Instrumento en la base de datos.
        // Cada propiedad corresponde a una columna en la tabla Instrumentos de SQL Server.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // Nombre del instrumento musical. El signo ? indica que acepta valores nulos.
        public string? Instrumento_Nombre { get; set; }
        // Marca o fabricante del instrumento. Ej: Fender, Yamaha, Pearl.
        public string? Marca { get; set; }
        // Descripción breve del instrumento. Ej: "Guitarra telecaster color rojo".
        public string? Descripcion { get; set; }
        // Precio de venta en pesos mexicanos (MXN).
        // Se configura como decimal(18,2) en DBContext para mayor precisión.
        public decimal? Precio { get; set; }
        // Número de unidades disponibles en el inventario de la tienda.
        public int? Existencia { get; set; }
    }
}
