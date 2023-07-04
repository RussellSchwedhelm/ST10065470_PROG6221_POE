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
    /// Interaction logic for ViewRecipeSelection.xaml
    /// </summary>
    public partial class ViewRecipeSelection : Window
    {
        private string[] foodGroup = new string[] { "Fruits", "Vegetables", "Grains", "Protein", "Dairy", "Fats Or Oils", "" };
        public ViewRecipeSelection()
        {
            InitializeComponent();
            foreach (Recipe recipe in App.recipes)
            {
                lb_recipes.Items.Add(recipe.RecipeName);
            }

            for (int food = 0; food < foodGroup.Length; food++)
            {
                cmb_foodGroup.Items.Add(foodGroup[food]);

            }
        }

        private void btn_View_Click(object sender, RoutedEventArgs e)
        {
            lbl_recipeError.Visibility = Visibility.Hidden;

            if (!lb_recipes.SelectedItem.Equals(null))
            {
                ViewRecipe viewRecipe = new ViewRecipe(lb_recipes.SelectedItem.ToString());
                this.Hide();
                viewRecipe.Show();
            }
            else
            {
                lbl_recipeError.Visibility = Visibility.Visible;
            }
        }

        private void btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            lbl_numberError.Visibility = Visibility.Hidden;

            string ingredientFilter = tb_ingredient.Text;
            string foodGroupFilter = cmb_foodGroup.SelectedIndex + "";
            double calorieFilter = 0;

            if (ErrorChecking.CheckForPositiveNumber(tb_maxCalories.Text) == -1)
            {
                if (string.IsNullOrEmpty(tb_maxCalories.Text))
                {
                }
                else
                {
                    lbl_numberError.Visibility = Visibility.Visible;
                    tb_maxCalories.Clear();
                }
            }
            else
            {
                calorieFilter = Double.Parse(tb_maxCalories.Text);
            }

            lb_recipes.Items.Clear();

            if (string.IsNullOrEmpty(tb_maxCalories.Text) && string.IsNullOrEmpty(tb_ingredient.Text) && (cmb_foodGroup.SelectedItem + "").Equals(""))
            {
                foreach (Recipe recipe in App.recipes)
                {
                    lb_recipes.Items.Add(recipe.RecipeName);
                }
            }
            else
            {
                List<Recipe> filterList = CreateMasterFilterList(CheckIngredient(ingredientFilter), CheckFoodGroup(foodGroupFilter), CheckMaxCalories(calorieFilter));

                foreach (Recipe recipe in filterList)
                {
                    lb_recipes.Items.Add(recipe.RecipeName);
                }
            }
        }

        public List<Recipe> CheckIngredient(string searchedIngredient)
        {
            List<Recipe> hasIngredients = new List<Recipe>();

            if (!searchedIngredient.Equals(""))
            {
                foreach (Recipe recipe in App.recipes)
                {
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        if (ingredient.Name.ToLower().Equals(searchedIngredient.ToLower()))
                        {
                            hasIngredients.Add(recipe);
                            break;
                        }
                    }
                }
            }

            return hasIngredients;
        }

        public List<Recipe> CheckFoodGroup(string searchedFoodGroup)
        {
            List<Recipe> hasIngredients = new List<Recipe>();

            if (!string.IsNullOrEmpty(searchedFoodGroup))
            {
                foreach (Recipe recipe in App.recipes)
                {
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        if (ingredient.FoodGroup.Equals(searchedFoodGroup))
                        {
                            hasIngredients.Add(recipe);
                            break;
                        }
                    }
                }
            }
            return hasIngredients;
        }

        public List<Recipe> CheckMaxCalories(double searchCalories)
        {
            List<Recipe> hasIngredients = new List<Recipe>();
            double totalCalories = 0;

            foreach (Recipe recipe in App.recipes)
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    totalCalories += ingredient.Calories;
                }
                if (totalCalories <= searchCalories)
                {
                    hasIngredients.Add(recipe);
                }
            }
            return hasIngredients;
        }

        public List<Recipe> CreateMasterFilterList (List<Recipe> list1, List<Recipe> list2, List<Recipe> list3)
        {
            List<Recipe> masterList = list1;

            foreach (Recipe recipe in list2)
            {
                if (!masterList.Contains(recipe))
                {
                    masterList.Add(recipe);
                }
            }
            foreach (Recipe recipe in list3)
            {
                if (!masterList.Contains(recipe))
                {
                    masterList.Add(recipe);
                }
            }
            return masterList;
        }

        private void brn_mainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
