using AppCompras.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCompras.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Compras : ContentPage
    {
        public Compras()
        {
            InitializeComponent();
            BindingContext = new VMcompras(Navigation, Carrilderecha, Carrilizquierda);
        }
    }
}