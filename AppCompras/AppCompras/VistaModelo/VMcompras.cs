using AppCompras.Datos;
using AppCompras.Modelo;
using AppCompras.VistaModelo;
using AppCompras.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppCompras.VistaModelo
{
    public class VMcompras : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        int _index;
        
       
        List<Mproductos> _listaproductos; // Variable lista de productos.
        List<MDetallecompras> _listaVistapreviaDc;
        #endregion
        #region CONSTRUCTOR
        public VMcompras(INavigation navigation , StackLayout Carrilderecha, StackLayout Carrilizquierda)
        {
            Navigation = navigation;
            Mostrarproducto(Carrilderecha,Carrilizquierda);

        }
        #endregion
        #region OBJETOS

        public List<MDetallecompras> ListaVistapreviaDc
        {
            get { return _listaVistapreviaDc; }
            set { SetValue(ref _listaVistapreviaDc, value); }
        }
        public List<Mproductos>Listaproductos
        {
            get { return _listaproductos; }
            set { SetValue(ref _listaproductos, value); }
        }

        #endregion
        #region PROCESOS

        // Método async para mostrar productos.
        public async Task Mostrarproducto(StackLayout Carrilderecha , StackLayout Carrilizquierda)
        {
            var funcion = new Dproductos();
            Listaproductos = await funcion.Mostrarproductos();
            
            var box = new BoxView
            {
                HeightRequest = 60
            };

            Carrilizquierda.Children.Clear();
            Carrilderecha.Children.Clear();
            Carrilderecha.Children.Add(box);

            foreach (var item in Listaproductos)
            {
                Dibujarproductos(item, _index, Carrilderecha, Carrilizquierda);
                _index++; // Llenar de datos el bucle en cada iteración. 
            }
        }

        // Distribuir productos en ambas columnas.
        public void Dibujarproductos(Mproductos item, int index, StackLayout Carrilderecha, StackLayout Carrilizquierda)
        {
            var _ubicacion = Convert.ToBoolean(index % 2);
            var carril = _ubicacion ? Carrilderecha : Carrilizquierda;

            var frame = new Frame
            {
                HeightRequest = 300,
                CornerRadius = 10,
                Margin = 8,
                HasShadow = false,
                BackgroundColor = Color.White,
                Padding = 22,
            };

            var stack = new StackLayout
            {

            };

            var image = new Image
            {
                Source = item.Icono,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 10)
            };

            var labelprecio = new Label
            {
                Text = "$" + item.Precio,
                FontAttributes = FontAttributes.Bold,
                FontSize = 22,
                Margin = new Thickness(0, 10),
                TextColor = Color.Black,
            };

            var labeldescripcion = new Label
            {
                Text = item.Descripcion,
                FontSize = 16,
                TextColor = Color.Black,
                CharacterSpacing = 1,
            };

            var labelpeso = new Label
            {
                Text = item.Peso,
                FontSize = 12,
                TextColor = Color.Black,
                CharacterSpacing = 1,
            };

            // Contener en el stack.
            stack.Children.Add(image);
            stack.Children.Add(labelprecio);
            stack.Children.Add(labeldescripcion);
            stack.Children.Add(labelpeso);
            frame.Content = stack;

            // Tap para la navegación a otras páginas.
            var tap = new TapGestureRecognizer();
            tap.Tapped += async (object sender, EventArgs e) =>
            {
                await Navigation.PushAsync(new Agregarcompra(item));
            };

            carril.Children.Add(frame);
            stack.GestureRecognizers.Add(tap);
        }

        
        public async Task ProcesoAsyncrono()
        {
            
        }   
        public void ProcesoSimple()
        {
            
        }
        public async Task MostrarVistapreviaDc()
        {
            var funcion = new Ddetallecompras();
            ListaVistapreviaDc = await funcion.MostrarVistapreviaDc();
        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
