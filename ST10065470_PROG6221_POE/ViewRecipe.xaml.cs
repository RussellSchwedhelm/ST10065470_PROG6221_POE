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
    /// Interaction logic for ViewRecipe.xaml
    /// </summary>
    public partial class ViewRecipe : Window
    {
        Recipe displayRecipe;
        double scale = 1;

        public ViewRecipe()
        {
            InitializeComponent();
        }

        public ViewRecipe(string recipeName)
        {
            InitializeComponent();

            foreach (Recipe recipe in App.recipes)
            {
                if (recipe.RecipeName.Equals(recipeName))
                {
                    displayRecipe = recipe;
                    break;
                }
            }

            if (displayRecipe != null)
            {
                int count = 1;

                foreach (Step step in displayRecipe.Steps)
                {
                    lb_steps.Items.Add(count + ". " + step.GetStep);
                    count++;
                }

                foreach (Ingredient ingredient in displayRecipe.Ingredients)
                {
                    string info = ingredient.Quantity.ToString() + " ";
                    string[] parts = ingredient.UnitOfMeasurement.Split("/");
                    if (ingredient.Quantity > 1)
                    {
                        info += parts[1];
                    }
                    else
                    {
                        info += parts[0];
                    }
                    info += " Of " + ingredient.Name;

                    lb_ingredients.Items.Add(info);
                }
            }

        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            tb_scale.Text = "1x";
            scale = 1;
        }

        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            tb_scale.Text = "2x";
            scale = 2;
        }

        private void btn_3_Click(object sender, RoutedEventArgs e)
        {
            tb_scale.Text = "3x";
            scale = 3;
        }

        private void btn_0_5_Click(object sender, RoutedEventArgs e)
        {
            tb_scale.Text = "0.5x";
            scale = 0.5;
        }

        private void btn_viewRecipe_Copy_Click(object sender, RoutedEventArgs e)
        {
            lbl_Scale_Error.Visibility = Visibility.Hidden;
            if (tb_scale.Text == null)
            {
                lbl_Scale_Error.Visibility = Visibility.Visible;
            }
            else
            {
                lb_ingredients.Items.Clear();

                foreach (Ingredient ingredient in displayRecipe.Ingredients)
                {
                    string info = (ingredient.Quantity * scale).ToString("0.00") + " ";
                    string[] parts = ingredient.UnitOfMeasurement.Split("/");
                    if (ingredient.Quantity > 1)
                    {
                        info += parts[1];
                    }
                    else
                    {
                        info += parts[0];
                    }
                    info += " Of " + ingredient.Name;

                    lb_ingredients.Items.Add(info);
                }
            }
        }

        private void btn_viewRecipe_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ViewRecipeSelection viewRecipeSelection = new ViewRecipeSelection();
            viewRecipeSelection.Show();
        }

        private void btn_mainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
