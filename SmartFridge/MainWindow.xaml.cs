using Microsoft.Extensions.Configuration;
using SmartFridge.Database;
using SmartFridge.Service;
using System.Net.Http;
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
    private readonly UserIngredientsDbContext _userDb;

    private readonly RecipeRecommendationService _recipeService;

    public MainWindow()
    {
        InitializeComponent();

        _dbFactory = new HubDbContextFactory();

        _recipeService = new RecipeRecommendationService(new HttpClient());

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

    private async void SearchRecipes_Click(object sender, RoutedEventArgs e)
    {
        var userIngredients = _userDb.Ingrediente.Select(i => i.Nume.ToLower()).ToList();
        string recipes = await _recipeService.GetRecipeRecommendations(userIngredients);

        var recipesWindow = new RecipesWindow(recipes);
        recipesWindow.ShowDialog();
    }
}