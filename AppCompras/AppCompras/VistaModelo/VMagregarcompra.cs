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

namespace AppCompras.VistaModelo
{
    class VMagregarcompra : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public Mproductos Parametrosrecibe { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMagregarcompra(INavigation navigation , Mproductos parametrosTrae)
        {
            Navigation = navigation;
            Parametrosrecibe = parametrosTrae;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
