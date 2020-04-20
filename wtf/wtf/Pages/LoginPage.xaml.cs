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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;


namespace wtf.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            // NavigationService.Navigate(new Uri("Pages/MainPage.xaml"), UriKind.Relative);
            NavigationService.Navigate(new Uri("Pages/MainPage.xaml", UriKind.Relative));
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlGetUser = new SqlCommand("Select * FROM [user] where email ='" + tbEmail.Text + "'", sqlConnection);
                SqlDataReader reader = sqlGetUser.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string password = reader.GetString(1);
                    if (password == tbPassword.Password)
                    {
                        char roleId = Convert.ToChar(reader.GetValue(4));
                        switch (roleId)
                        {
                            case 'R':
                                {
                                    NavigationService.Navigate(new Uri("Pages/RunnerMenuPage.xaml", UriKind.Relative));

                                    break;
                                }
                            case 'A':
                                {
                                    NavigationService.Navigate(new Uri("Pages/AdministratorMenuPage.xaml", UriKind.Relative));

                                    break;
                                }
                            case 'C':
                                {
                                    NavigationService.Navigate(new Uri("Pages/CoordinatorMenuPage.xaml", UriKind.Relative));
                                    break;
                                }
                        }
                    }
                    else
                        MessageBox.Show("Не верный логин или пароль");

                }
                else
                    MessageBox.Show("Не верный логин или пароль");
            }
        }
    }
}
