using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AppCompras.Modelo;
using AppCompras.Conexiones;
using Firebase.Database;
using System.Collections.ObjectModel;

namespace AppCompras.Datos
{
    public class Dproductos
    {
        public async Task<List<Mproductos>> Mostrarproductos()
        {
            return (await Cconexion.firebase
                .Child("Productos")
                .OnceAsync<Mproductos>()).Select(item => new Mproductos
                {
                    Descripcion = item.Object.Descripcion,
                    Icono = item.Object.Icono,
                    Precio = item.Object.Precio,
                    Peso = item.Object.Peso,
                    Idproducto = item.Key,
                }).ToList();
        }
    }
}
