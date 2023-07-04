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
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        string[] recipeNames;
        public Delete()
        {
            InitializeComponent();
            recipeNames = new string[App.recipes.Count];
            lb_recipes.ItemsSource = recipeNames;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            lbl_error.Visibility = Visibility.Hidden;
            if (lb_recipes.SelectedItem == null)
            {
                lbl_error.Visibility = Visibility.Visible;
            }
            else
            {
                foreach (Recipe recipe in App.recipes)
                {
                    if (recipe.RecipeName.Equals(lb_recipes.SelectedItem))
                    {
                        App.recipes.Remove(recipe);
                        break;
                    }
                }
            }
        }
    }
}
