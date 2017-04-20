using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;


namespace SchoolManagementPortal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VHIOITK; Initial Catalog=School; Integrated Security=True");
        string userName, password;
        static int userID;
        public static int UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }

        MainMenu start_page;

        public MainWindow()
        {
            InitializeComponent();
            start_page = new MainMenu();
        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("Select * from Users where userName='"+txt_username.Text+"'", connection);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            if (dr.HasRows)
            {
                //MessageBox.Show(String.Format("{0}", dr["userName"]));
                password = String.Format("{0}", dr["userPassword"]);
            }

            

            if (txt_password.Password == password) {
                //MessageBox.Show(String.Format("Welcome {0}", dr["userName"]),  "Login");
                //MessageBox.Show("Welcome User", "Login");
                MainWindow.UserID = Int32.Parse(dr["userID"].ToString());
                this.Close();
                start_page.Show();
            }

            dr.Close();
            connection.Close();
        }
    }
}
