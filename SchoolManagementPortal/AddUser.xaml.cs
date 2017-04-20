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
using System.Data.SqlClient;
using System.Data;


namespace SchoolManagementPortal
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VHIOITK; Initial Catalog=School; Integrated Security=True");

        public AddUser()
        {
            InitializeComponent();
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            try
            {
                var check = 0;
                string commandString = String.Format("insert into Users (userName, userPassword) values ('{0}', '{1}')", textBoxUserName.Text, textBoxPassword.Password);
                SqlCommand cmd = new SqlCommand(commandString, connection);
                check = cmd.ExecuteNonQuery();
                if(check> 0)
                {
                    MessageBox.Show("Successfully added!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Operation failed!");
                }
            }
            catch(SqlException exp)
            {
                MessageBox.Show(exp.ToString());
            }

            connection.Close();
        }

        private void button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
