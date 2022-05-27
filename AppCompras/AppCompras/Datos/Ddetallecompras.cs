using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database.Query;
using System.Linq;
using Firebase.Database;
using System.Threading.Tasks;
using AppCompras.Modelo;
using AppCompras.Conexiones;


namespace AppCompras.Datos
{
    public class Ddetallecompras
    {
        public async Task InsertarDcompra(MDetallecompras parametros)
        {
            await Cconexion.firebase
                .Child("Detallecompra")
                .PostAsync(new MDetallecompras()
                {
                    Cantidad = parametros.Cantidad,
                    Idproducto = parametros.Idproducto,
                    Preciocompra = parametros.Preciocompra,
                    Total = parametros.Total
                });
        }

        // Detalle de Compra.
        public async Task<List<MDetallecompras>> MostrarVistapreviaDc()
        {
            var ListaDc = new List<MDetallecompras>();
            var parametrosProductos = new Mproductos();
            var funcionproductos = new Dproductos();
            var data = await Cconexion.firebase
                .Child("Detallecompra")
                .OnceAsync<MDetallecompras>();
            data.Where(a => a.Key != "Modelo");
            foreach(var hobit in data)
            {
                var parametros = new MDetallecompras();
                parametros.Idproducto = hobit.Object.Idproducto;
                parametrosProductos.Idproducto = hobit.Object.Idproducto;
                var listaproductos = await funcionproductos.MostrarproductosPorid(parametrosProductos);
                parametros.Imagen = listaproductos[0].Icono;
                ListaDc.Add(parametros);
            }
            return ListaDc;
        }
    }
}
