﻿using Messenger.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Messenger.ViewModels
{
    public class RegisterViewModel 
    {
        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string TruePassword { get; set; }

        public ICommand RegisterCommand { get; set; }

        private Page _page;

        public RegisterViewModel(Page page)
        {
            _page = page;
            RegisterCommand = new Command(OpenLogin);
        }


        private async void OpenLogin()
        {
            Debug.WriteLine($"UserName:{UserName}, Password:{Password}");
            await _page.Navigation.PushAsync(new LoginPage());
        }

       
    }

    

   

}
