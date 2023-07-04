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
    /// Interaction logic for FoodInfo.xaml
    /// </summary>
    public partial class FoodInfo : Window
    {
        public FoodInfo()
        {
            InitializeComponent();

            string fruits = "Fruits: Sweet and refreshing plant-based foods that provide essential vitamins, minerals, fiber, and antioxidants. Examples include apples, oranges, berries, and melons.";
            string vegetables = "Vegetables: Nourishing and diverse plant-based foods that offer a wide range of vitamins, minerals, fiber, and beneficial plant compounds. Examples include leafy greens, broccoli, carrots, and peppers.";
            string grains = "Grains: Staple foods made from cereal crops such as wheat, rice, oats, and corn. Grains are a significant source of carbohydrates, fiber, and various nutrients like B vitamins and minerals. Examples include bread, rice, pasta, and cereals.";
            string protein = "Protein: Foods that are rich in protein, necessary for building and repairing body tissues. This group includes animal sources like meat, poultry, fish, eggs, and dairy, as well as plant-based sources like legumes (beans, lentils), tofu, nuts, and seeds.";
            string dairy = "Dairy: Dairy products, such as milk, cheese, and yogurt, are excellent sources of calcium, protein, and other essential nutrients. Dairy provides bone-strengthening minerals and can be part of a healthy diet. Plant-based alternatives like soy or almond milk are also available for those who avoid dairy.";
            string fatsAndOils = "Fats or Oils: This group includes fats and oils that provide energy and essential fatty acids. While it's important to consume them in moderation, healthy fats from sources like avocados, nuts, seeds, and olive oil can be part of a balanced diet.";

            lv_info.Items.Add(fruits);
            lv_info.Items.Add(vegetables);
            lv_info.Items.Add(grains);
            lv_info.Items.Add(protein);
            lv_info.Items.Add(dairy);
            lv_info.Items.Add(fatsAndOils);
        }

        private void btn_mainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
