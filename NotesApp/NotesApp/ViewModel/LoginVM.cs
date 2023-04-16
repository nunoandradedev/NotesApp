using NotesApp.Model;
using NotesApp.ViewModel.Commands;
using NotesApp.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotesApp.ViewModel
{
    public class LoginVM : INotifyPropertyChanged
    {
        private bool isShowingRegister = false;

        private User user;

        public User User
        {
            get { return user; }
            set
            { 
                user = value;
                OnPropertyChanged("User");
            }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set
            { 
                username = value;
                User = new User
                {
                    Username = username,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword,
                    Name = this.Name,
                    Lastname = this.Lastname
                };

                OnPropertyChanged("Username");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new User
                {
                    Username = this.Username,
                    Password = password,
                    ConfirmPassword = this.ConfirmPassword,
                    Name = this.Name,
                    Lastname = this.Lastname
                };
                OnPropertyChanged("Password");
            }
        }

        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                User = new User
                {
                    Username = this.Username,
                    Password = this.password,
                    ConfirmPassword = confirmPassword,
                    Name = this.Name,
                    Lastname = this.Lastname
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                User = new User
                {
                    Username = this.Username,
                    Password = this.password,
                    ConfirmPassword = this.confirmPassword,
                    Name = name,
                    Lastname = this.Lastname
                };
                OnPropertyChanged("Name");
            }
        }

        private string lastname;

        public string Lastname
        {
            get { return lastname; }
            set
            {
                lastname = value;
                User = new User
                {
                    Username = this.Username,
                    Password = this.password,
                    ConfirmPassword = this.confirmPassword,
                    Name = this.name,
                    Lastname = lastname
                };
                OnPropertyChanged("Lastname");
            }
        }

        private Visibility loginVis;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler Authenticated;

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

            User = new User();
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

        public async void Login()
        {
            bool result = await FirebaseAuthHelper.Login(User);
            if (result)
            {
                Authenticated?.Invoke(this, new EventArgs());
            }
        }

        public async void Register()
        {
            bool result = await FirebaseAuthHelper.Register(User);
            if (result)
            {
                Authenticated?.Invoke(this, new EventArgs());
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
