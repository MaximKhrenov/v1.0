using Messenger.Models;
using Messenger.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Messenger.Services;

namespace Messenger.ViewModels
{
    public class ContactsViewModel
    {

        public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();
           public async Task LoadContactsAsync()
        {
            var dataService = DataService.GetInstance();
            var contacts = await dataService.LoadContactsAsync();

            foreach(var contact in contacts)
            {
                contact.Photo = "http://192.168.43.147:9000/" + contact.Photo;
                Contacts.Add(contact);
            }
        }

      

        public ICommand ProfileCommand { get; set; }

        public ICommand ExitCommand { get; set; }


        

        private Page _page;

        public ContactsViewModel(Page page)
        {
            _page = page;

            ExitCommand = new Command(OpenExit);
            ProfileCommand = new Command(OpenProfile);
        }


        private async void OpenProfile()
        {
            await _page.Navigation.PushAsync(new ProfilePage());
        }

        public async Task OpenChat()
        {
            await _page.Navigation.PushAsync(new ChatPage());
        }

        private async void OpenExit()
        {
            await _page.Navigation.PushAsync(new LoginPage());
        }
    }
}
