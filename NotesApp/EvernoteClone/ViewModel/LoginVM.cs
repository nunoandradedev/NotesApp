﻿using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace EvernoteClone.ViewModel
{
    public class LoginVM : INotifyPropertyChanged
    {
        private bool isShowingRegister = false;

        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        private Visibility loginVis;

        public event PropertyChangedEventHandler PropertyChanged;

        public Visibility LoginVis
        {
            get { return loginVis; }
            set 
            { 
                loginVis = value;
                OnPropertyChanged("LoginVis");
            }
        }

        private Visibility registerVis;
        public Visibility RegisterVis
        {
            get { return registerVis; }
            set
            {
                registerVis = value;
                OnPropertyChanged("RegisterVis");
            }
        }

        public RegisterCommand RegisterCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }
        public ShowRegisterCommand ShowRegisterCommand { get; set; }
        public LoginVM()
        {
            LoginVis = Visibility.Visible;
            RegisterVis = Visibility.Collapsed;

            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
            ShowRegisterCommand = new ShowRegisterCommand(this);
        }
        public void SwitchViews()
        {
            isShowingRegister = !isShowingRegister;
            if (isShowingRegister)
            {
                RegisterVis = Visibility.Visible;
                LoginVis = Visibility.Collapsed;
            }
            else
            {
                RegisterVis = Visibility.Collapsed;
                LoginVis = Visibility.Visible;
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
