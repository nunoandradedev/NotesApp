﻿using NotesApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NotesApp.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginVM VM { get; set; }
        public LoginCommand(LoginVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            User user = parameter as User;

            if (user == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(user.Username))
            {
                return false;
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                return false;
            }

            return true;
        }

        public void Execute(object parameter)
        {
            VM.Login();
        }

    }
}
