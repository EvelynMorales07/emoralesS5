using emoralesS5.Utils;

namespace emoralesS5
{
    public partial class App : Application
    {
        public static PersonaRepositorio personRepo {  get; set; }

        public App(PersonaRepositorio person)
        {
            InitializeComponent();

            MainPage = new Views.vHome();
            personRepo = person;
        }
    }
}
