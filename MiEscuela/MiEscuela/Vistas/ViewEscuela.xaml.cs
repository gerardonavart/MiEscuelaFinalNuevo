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
	public partial class ViewEscuela : ContentPage
	{
        //Materia materia;
        Usuario usuario;
		public ViewEscuela (Usuario u)
		{
            
			InitializeComponent ();
            usuario = u;
            
            
            btnAgregarMateria.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ViewMateria(new Materia
                {
                    IdUsuario = usuario.Id
                }, true));
            };
            btnAgregarCompaniero.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ViewCompaniero(new Companiero()
                {
                    IdUsuario = usuario.Id
                }, true));
            };
            lstCompanieros.ItemTapped += (sender, e) =>
            {
                if (lstCompanieros.SelectedItem != null)
                {
                    Navigation.PushAsync(new ViewCompaniero(lstCompanieros.SelectedItem as Companiero, false));

                }
            };
            lstMaterias.ItemTapped += (sender, e) =>
            {
                if (lstMaterias.SelectedItem != null)
                {
                   
                    Navigation.PushAsync(new ViewMateria(lstMaterias.SelectedItem as Materia, false));
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ICompanieroManager manager = new CompanieroManager(new GenericRepository<Companiero>());
            lstCompanieros.ItemsSource = manager.CompanieroDeUsuario(usuario.Id);
            IMateriaManager materiasManager = new MateriaManager(new GenericRepository<Materia>());
            lstMaterias.ItemsSource = materiasManager.BuscarMateriasDeUsuario(usuario.Id);
        }
    }
}