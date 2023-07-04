using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10065470_PROG6221_POE
{
    public class Recipe
    {
        // Variables
        private string recipeName;
        private List<Step> steps;
        private List<Ingredient> ingredients;

        public Recipe(string recipeName, List<Step> steps, List<Ingredient> ingredients)
        {
            this.recipeName = recipeName;
            this.steps = steps;
            this.ingredients = ingredients;
        }

        // Getters And Setters
        public string RecipeName { get => recipeName; set => recipeName = value; }
        internal List<Step> Steps { get => steps; set => steps = value; }
        internal List<Ingredient> Ingredients { get => ingredients; set => ingredients = value; }
    }
}
