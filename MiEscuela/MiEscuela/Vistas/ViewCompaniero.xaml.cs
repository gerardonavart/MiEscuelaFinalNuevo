using MiEscuela.COMMON.Entidades;
using MiEscuela.COMMON.Interfaces;
using MiEscuela.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiEscuela.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewCompaniero : ContentPage
	{
        ICompanieroManager manager;
		public ViewCompaniero (Companiero companiero, bool nuevo)
		{
			InitializeComponent ();
            manager = new MiEscuela.BIZ.CompanieroManager(new GenericRepository<Companiero>());
            Contenedor.BindingContext = companiero;
            btnGuardar.Clicked += (sender, e) =>
            {
                Companiero resultado;
                if (nuevo)
                {
                    resultado = manager.Agregar(Contenedor.BindingContext as Companiero);
                }
                else
                {
                    resultado = manager.Modificar(Contenedor.BindingContext as Companiero);
                }
                if (resultado != null)
                {
                    DisplayAlert("Mi Escuela", "Compañero Guardado", "OK");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Mi Escuela", "Error al Guardar", "OK");
                }
            };

            btnEliminar.Clicked += (sender, e) =>
            {
                if (manager.Eliminar(companiero.Id))
                {
                    DisplayAlert("Mi Escuela", "Compañero Eliminado", "OK");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Mi Escuela", "Error al Elminar", "OK");
                }
            };
        }
	}
}