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
	public partial class ViewMateria : ContentPage
	{
        Materia materia;
        IMateriaManager materiaManager;
        bool nuevo;
        public int contar=0;
        public int contar2;
        decimal calif;
        decimal calif2;
        public ViewMateria (Materia m, bool n)
		{
            materia = m;
            nuevo = n;
			InitializeComponent ();

            materiaManager = new MateriaManager(new GenericRepository<Materia>());
            contenedor.BindingContext = materia;
            Appearing += ViewMateria_Appering;

            btnAgregarTarea.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ViewTarea(new Tarea
                {
                    IdTarea = materia.Id
                },true));
            };

            btnGuardar.Clicked += (sender, e) =>
            {
                if (nuevo)
                {
                    materia = materiaManager.Agregar(contenedor.BindingContext as Materia);
                }
                else
                {
                    materia = materiaManager.Modificar(contenedor.BindingContext as Materia);
                }
                if (materia != null)
                {
                    DisplayAlert("Mi Escuela", "Materia Guardada", "OK");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Mi Escuela", "Error al Guardar", "OK");
                }

            };

            btnEliminar.Clicked += (sender, e) =>
            {
                if (materiaManager.Eliminar(materia.Id))
                {
                    DisplayAlert("Mi Escuela", "Materia Eliminada Correctamente", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Mi Escuela", "No se pudo eliminar la materia", "Ok");
                }
            };

            lstTareas.ItemTapped += (sender, e) =>
            {
                if (lstTareas.SelectedItem != null)
                {
                   
                    Navigation.PushAsync(new ViewTarea(lstTareas.SelectedItem as Tarea, false));
                }
            };
        }



private void ViewMateria_Appering(object sender, EventArgs e)
        {
            ITareaManager tareaManager = new TareaManager(new GenericRepository<Tarea>());
            lstTareas.ItemsSource = null;
            var datos= tareaManager.BuscarTareasDeMateria(materia.Id);
            lstTareas.ItemsSource = datos;
            contar = datos.Count(p=>!p.Entregada);
            contar2 = datos.Count(); //d => !d.Entregada && d.Entregada
            calif = datos.Sum(d => d.Calificacion);
            //calif2 = (calif2 * 100) / contar2;
            materia.CalificacionMateria = calif2;
            materia.contador = contar;
            if (contar >= 1)
            {
                DisplayAlert("Mi Escuela", "Tareas por entregar: " + contar , "OK");
            }
            if (contar2 >=1)
            {
                calif2 = calif / contar2;
            }
            else
            {
                calif2 = calif / 1;
            }
            materia.CalificacionMateria = calif2;


        }
    }
}