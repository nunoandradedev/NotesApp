using NotesApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotesApp.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        LoginVM vm;
        public LoginWindow()
        {
            InitializeComponent();

            vm = Resources["vm"] as LoginVM;
            vm.Authenticated += ViewModel_Authenticated;
        }

        private void ViewModel_Authenticated(object sender, EventArgs e)
        {
            Close();
        }
    }
}
