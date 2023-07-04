using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace ST10065470_PROG6221_POE
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

        private void button_Click_createRecipe(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CreateRecipe registerPage = new CreateRecipe();
            registerPage.Show();
        }

        private void button_Click_viewRecipe(object sender, RoutedEventArgs e)
        {
            if (App.recipes.Count == 0)
            {
                MessageBox.Show("No Recipes Added!");
            }
            else
            {
                this.Hide();
                ViewRecipeSelection registerPage = new ViewRecipeSelection();
                registerPage.Show();
            }
        }

        private void button_Click_deleteRecipe(object sender, RoutedEventArgs e)
        {
            if (App.recipes.Count == 0)
            {
                MessageBox.Show("No Recipes Added!");
            }
            else
            {
                this.Hide();
                Delete registerPage = new Delete();
                registerPage.Show();
            }
        }

        private void button_Click_foodInfo(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FoodInfo foodInfo = new FoodInfo();
            foodInfo.Show();
        }

        private void button_Click_exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
