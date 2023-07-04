using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10065470_PROG6221_POE
{
    public class Ingredient
    {
        // Variables
        private string name; // Private field representing the ingredient's name
        private string unitOfMeasurement; // Private field representing the ingredient's unit of measurement
        private double quantity; // Private field representing the ingredient's quantity
        private double calories; // Private field representing the ingredient's calories
        private string foodGroup; // Private field representing the ingredient's food group

        public Ingredient(string name, string unitOfMeasurement, double quantity, double calories, string foodGroup)
        {
            this.name = name;
            this.unitOfMeasurement = unitOfMeasurement;
            this.quantity = quantity;
            this.calories = calories;
            this.foodGroup = foodGroup;
        }

        // Getters And Setters
        public string Name { get => name; set => name = value; }
        public string UnitOfMeasurement { get => unitOfMeasurement; set => unitOfMeasurement = value; }
        public double Quantity { get => quantity; set => quantity = value; }
        public double Calories { get => calories; set => calories = value; }
        public string FoodGroup { get => foodGroup; set => foodGroup = value; }
    }
}
