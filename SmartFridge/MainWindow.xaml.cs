using SmartFridge.Database;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartFridge;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly HubDbContextFactory _dbFactory;
    private readonly SmartFridgeDbContext _recipeDb;
    private readonly UserIngredientsDbContext _userDb;

    public MainWindow()
    {
        InitializeComponent();

        _dbFactory = new HubDbContextFactory();
        _recipeDb = _dbFactory.CreateSmartFridgeDbContext();
        _userDb = _dbFactory.CreateUserIngredientsDbContext();
    }

    private void AddIngredient_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIngredient.Text) || string.IsNullOrWhiteSpace(txtCalorii.Text) || dpExpirare.SelectedDate == null)
        {
            MessageBox.Show("Introduceți toate detaliile ingredientului!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var newIngredient = new Ingredient
        {
            Nume = txtIngredient.Text,
            Calorii = int.Parse(txtCalorii.Text),
            DataExpirare = dpExpirare.SelectedDate.Value
        };

        _userDb.Ingrediente.Add(newIngredient);
        _userDb.SaveChanges();

        MessageBox.Show($"Ingredientul '{newIngredient.Nume}' a fost adăugat!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void OpenIngredientsWindow_Click(object sender, RoutedEventArgs e)
    {
        IngredientsWindow ingredientsWindow = new IngredientsWindow();
        ingredientsWindow.ShowDialog();
    }

    private void SearchRecipes_Click(object sender, RoutedEventArgs e)
    {
        var userIngredients = _userDb.Ingrediente.Select(i => i.Nume.ToLower()).ToList();

        var matchingRecipes = _recipeDb.Retete
            .AsEnumerable() // Forces EF to execute the query in-memory
            .Where(recipe =>
                recipe.IngredienteNecesare.Split(',')
                    .All(ingredient => userIngredients.Contains(ingredient.Trim().ToLower())))
            .Select(r => r.Nume)
            .ToList();

        if (matchingRecipes.Any())
        {
            lstRecipes.ItemsSource = matchingRecipes;
        }
        else
        {
            MessageBox.Show("Nu s-au găsit rețete potrivite!", "Informație", MessageBoxButton.OK, MessageBoxImage.Information);
            lstRecipes.ItemsSource = null;
        }
    }
}