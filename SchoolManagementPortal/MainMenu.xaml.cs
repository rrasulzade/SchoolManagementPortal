using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchoolManagementPortal
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void mainMenuAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser user = new AddUser();
            user.Show();
        }

        private void mainMenuAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            AddTeacher prof = new AddTeacher();
            prof.Show();
        }
    }
}
