using MiEscuela.BIZ;
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
	public partial class ViewTarea : ContentPage
	{
        Tarea tarea;
        bool nuevo;
		public ViewTarea (Tarea t, bool n)
		{
            ITareaManager tareaManager = new TareaManager(new GenericRepository<Tarea>());
            tarea = t;
            nuevo = n;
			InitializeComponent ();

            contenedor.BindingContext = tarea;

            btnGuardar.Clicked += (sender, e) =>
            {
                if (nuevo)
                {
                    tarea = tareaManager.Agregar(contenedor.BindingContext as Tarea);
                }
                else
                {
                    tarea = tareaManager.Modificar(contenedor.BindingContext as Tarea);
                }
                if (tarea != null)
                {
                    DisplayAlert("Mi Escuela", "Tarea Guardada", "OK");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Mi Escuela", "Error al Guardar", "OK");
                }
            };

            btnEliminar.Clicked += (sender, e) =>
             {
                 if (tareaManager.Eliminar(tarea.Id))
                 {
                     DisplayAlert("Mi Escuela", "Tarea Eliminada Correctamente", "Ok");
                     Navigation.PopAsync();
                 }
                 else
                 {
                     DisplayAlert("Mi Escuela", "No se pudo eliminar la materia", "Ok");
                 }
             };

		}
	}
}