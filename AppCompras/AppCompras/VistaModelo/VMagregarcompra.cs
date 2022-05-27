using System;
using System.Collections.Generic;
using System.Text;
using AppCompras.VistaModelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using AppCompras.Modelo;
using AppCompras.Datos;

namespace AppCompras.VistaModelo
{
    class VMagregarcompra : BaseViewModel
    {
        #region VARIABLES
        int _Cantidad;
        string _Preciotexto;

        public Mproductos Parametrosrecibe { get; set; }
        #endregion


        #region CONSTRUCTOR
        public VMagregarcompra(INavigation navigation, Mproductos parametrosTrae)
        {
            Navigation = navigation;
            Parametrosrecibe = parametrosTrae;
            Preciotexto = "$" + Parametrosrecibe.Precio;
        }
        #endregion


        #region OBJETOS
        public string Preciotexto
        {
            get { return _Preciotexto; }
            set { SetValue(ref _Preciotexto, value); }
        }

        public int Cantidad
        {
            get { return _Cantidad; }
            set { SetValue(ref _Cantidad, value); }
        }
        #endregion


        #region PROCESOS
        public async Task InsertarDcompra()
        {
            if(Cantidad == 0) 
            {
                Cantidad = 1;
            }

            var funcion = new Ddetallecompras();
            var parametros = new MDetallecompras();
            parametros.Cantidad = Cantidad.ToString();
            parametros.Idproducto = parametros.Idproducto;
            parametros.Preciocompra = Parametrosrecibe.Precio;
            double total = 0;
            double preciocompra = Convert.ToDouble(Parametrosrecibe.Precio);
            double cantidad = Convert.ToDouble(Cantidad);
            total = cantidad * preciocompra;
            parametros.Total = total.ToString();

            await funcion.InsertarDcompra(parametros);
            await Volver();
        }

        // Volver para la pantalla anterior.
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }

        // Sumar y restar cantidad de productos.
        public void Aumentar()
        {
            Cantidad += 1;
        }

        public void Disminuir()
        {
            if (Cantidad > 0)
            {
                Cantidad -= 1;
            }
        }
        #endregion


        #region COMANDOS
        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand Aumentarcommand => new Command(Aumentar);
        public ICommand Disminuircommand => new Command(Disminuir);
        public ICommand Insertarcommand => new Command(async () => await InsertarDcompra());
        #endregion
    }
}
