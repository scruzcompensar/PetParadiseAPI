using System;
using System.Collections.Generic;

namespace PetParadiseAPI.DataAccess.Data;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public string PrecioProducto { get; set; } = null!;

    public string FotoProducto { get; set; } = null!;

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();
}
