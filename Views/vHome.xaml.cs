using emoralesS5.Models;

namespace emoralesS5.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        App.personRepo.AddNewPersona(txtNombre.Text);
        status.Text = App.personRepo.StatusMessage;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        List<Personas> people= App.personRepo.GetAllPeople();
        ListaPersonas.ItemsSource = people;
    }
}