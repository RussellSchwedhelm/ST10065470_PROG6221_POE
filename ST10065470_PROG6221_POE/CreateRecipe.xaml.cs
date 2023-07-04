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
    /// Interaction logic for CreateRecipe.xaml
    /// </summary>
    public partial class CreateRecipe : Window
    {
        // Variables
        private List<Step> steps = new List<Step>();
        private List<Ingredient> ingredients = new List<Ingredient>();
        private string[] foodGroup = new string[] { "Fruits", "Vegetables", "Grains", "Protein", "Dairy", "Fats Or Oils" };

        // Getters And Setters
        internal List<Step> Steps { get => steps; set => steps = value; }
        internal List<Ingredient> Ingredients { get => ingredients; set => ingredients = value; }
        public string[] FoodGroup { get => foodGroup; set => foodGroup = value; }

        public CreateRecipe()
        {
            InitializeComponent();
            cmb_foodGroup.ItemsSource = foodGroup;
        }

        public CreateRecipe(string name)
        {
            this.Name = name;
            Steps = steps;
            Ingredients = ingredients;
            cmb_foodGroup.ItemsSource = foodGroup;
        }

        public void IngredientClear()
        {
            tb_calories.Clear();
            tb_ingredientName.Clear();
            tb_measurementSingular.Clear();
            tb_measurementPlural.Clear();
            tb_quantity.Clear();
        }

        public Boolean CheckIngredientFilled()
        {
            if (!tb_calories.Equals("") && !tb_ingredientName.Equals("") && !tb_measurementPlural.Equals("") && !tb_measurementSingular.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean CheckStepsFilled()
        {
            if (!tb_steps.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StepClear()
        {
            tb_steps.Clear();
        }

        private void btn_addIngredient_Click(object sender, RoutedEventArgs e)
        {
            lbl_ingredientError.Visibility = Visibility.Hidden;

            if (CheckIngredientFilled() == true)
            {
                double calories = ErrorChecking.CheckForPositiveNumber(tb_calories.Text);
                double quantity = ErrorChecking.CheckForPositiveNumber(tb_quantity.Text);
                if (calories < 0 || calories < 0)
                {
                    lbl_ingredientError.Visibility = Visibility.Visible;
                }
                else
                {
                    Ingredient ingredient = new Ingredient(tb_ingredientName.Text, (tb_measurementSingular.Text + "/" + tb_measurementPlural.Text), quantity, calories, cmb_foodGroup.SelectedIndex.ToString());
                    ingredients.Add(ingredient);

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

                    lv_ingredients.Items.Add(info);
                    IngredientClear();
                }
            }
            else
            {
                lbl_ingredientError.Visibility = Visibility.Visible;
            }
        }

        private void btn_saveRecipe_Click(object sender, RoutedEventArgs e)
        {
            lbl_recipeError.Visibility = Visibility.Hidden;
            lbl_recipeNameError.Visibility = Visibility.Hidden;

            if (ingredients.Count == 0 || steps.Count == 0)
            {
                lbl_recipeError.Visibility = Visibility.Visible;
            }
            else
            {
                if (tb_recipeName.Text.Equals(""))
                {
                    lbl_recipeError.Visibility= Visibility.Visible;
                }
                else if(RecipeCheck(tb_recipeName.Text) == true)
                {
                    lbl_recipeNameError.Visibility = Visibility.Visible;
                }
                else
                {
                    Recipe newRecipe = new Recipe(tb_recipeName.Text, steps, ingredients);
                    App.recipes.Add(newRecipe);
                    this.Hide();
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                }
            }
        }

        public Boolean RecipeCheck(string name)
        {
            foreach (Recipe recipe in App.recipes)
            {
                if (recipe.RecipeName.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }

        private void btn_addStep_Click(object sender, RoutedEventArgs e)
        {
            lbl_stepError.Visibility = Visibility.Hidden;
            if (CheckStepsFilled() == true)
            {
                Step newStep = new Step(tb_steps.Text);
                steps.Add(newStep);
                lv_steps.Items.Add(steps.Count + ". " + tb_steps.Text);
                StepClear();
            }
            else
            {
                lbl_stepError.Visibility = Visibility.Visible;
            }
        }
    }
}
