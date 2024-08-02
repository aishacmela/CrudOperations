namespace CrudOperations
{
    public partial class MainPage : ContentPage
    { 
        private readonly LocalDBServices _dbServices;
        private int _editContactId;

        public MainPage(LocalDBServices dbServices)
        {
            InitializeComponent();
            _dbServices = dbServices;
            Task.Run(async () => listView.ItemsSource = await _dbServices.GetContact());
        }

        /*private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }*/

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            if ( _editContactId == 0)
            {
                //add contacts
                await _dbServices.Create(new Contact
                {
                    Name = nameEntryField.Text,
                    Email = emailEntryField.Text,
                    PhoneNumber = mobileEntryField.Text,
                });
            } else
            {
                //edit contacts
                await _dbServices.Update(new Contact
                {
                    Id = _editContactId,
                    Name = nameEntryField.Text,
                    Email = emailEntryField.Text,
                    PhoneNumber = mobileEntryField.Text,
                });
                _editContactId = 0;
            }

            nameEntryField.Text = string.Empty;
            emailEntryField.Text = string.Empty;
            mobileEntryField.Text = string.Empty;

            listView.ItemsSource = await _dbServices.GetContact();
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = (Contact)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Ëdit", "Delete");

            switch(action)
            {
                case "Edit":
                    _editContactId = contact.Id;
                    nameEntryField.Text = contact.Name;
                    emailEntryField.Text = contact.Email;
                    mobileEntryField.Text = contact.PhoneNumber;
                    break;

                case "delete":
                    await _dbServices.Delete(contact);
                    listView.ItemsSource = await _dbServices.GetContact();

                    break;
            }



        }
    }

}
