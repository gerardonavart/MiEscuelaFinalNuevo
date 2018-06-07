using MiEscuela.BIZ;
using MiEscuela.COMMON.Entidades;
using MiEscuela.COMMON.Interfaces;
using MiEscuela.DAL;
using MiEscuela.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MiEscuela
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            IUsuarioManager manager = new UsuarioManager(new GenericRepository<Usuario>());
            btnIniciarSesion.Clicked += (sender, e) =>
            {
                Usuario usuario = manager.Login(txbUsuario.Text, pssClave.Text);
                if (usuario != null)
                {
                    Navigation.PushAsync(new ViewEscuela(usuario));
                }
                else
                {
                    DisplayAlert("Mi Escuela", "Usuario o contraseña incorrectos", "Ok");
                }

            };
            btnCrearCuenta.Clicked += (sender, e) =>
            {
                Usuario usuario = manager.CrearCuenta(txbUsuario.Text, pssClave.Text);
                if (usuario != null)
                {
                    DisplayAlert("Mi escuela", "Cuenta Creada correctamente", "OK");
                    Navigation.PushAsync(new ViewEscuela(usuario));
                }
                else
                {
                    DisplayAlert("Mi escuela", "Error al crear cuenta", "OK");
                }
            };
        }
	}
}
