namespace ApiEmpresa.Models;

public class productos
{
    public long id_producto { get; set; }
    public string? codigo { get; set; }
    public String? producto { get; set; }
    public string? descripcion { get; set; }
    public string? presentacion { get; set; }
    public double? precio_costo { get; set; }
    public DateTime? fecha_vencimiento { get; set; }

}