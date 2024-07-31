namespace CrudOperations
{
    public partial class App : Application
    {
        public App(MainPage mainPage)
        {
            InitializeComponent();
            //designate mainpage and the intial page for our application
            MainPage = mainPage;
        }
    }
}
