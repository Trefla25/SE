using SmartFridge.Database;
using SmartFridge.Service;
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

namespace SmartFridge;

/// <summary>
/// Interaction logic for RecipesWindow.xaml
/// </summary>
public partial class RecipesWindow : Window
{
    public RecipesWindow(string recipeResponse)
    {
        InitializeComponent();
        LoadRecipes(recipeResponse);
    }

    private void LoadRecipes(string recipeResponse)
    {
        var recipes = recipeResponse.Split('\n')
            .Select(r => FormatText(r.Trim()))
            .Where(r => !string.IsNullOrEmpty(r))
            .ToList();

        lstRecipes.ItemsSource = recipes;
    }

    private string FormatText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;

        // Capitalize the first letter of the sentence
        text = char.ToUpper(text[0]) + text.Substring(1);

        // Ensure proper punctuation at the end
        if (!text.EndsWith(".") && !text.EndsWith("!") && !text.EndsWith("?"))
            text += ".";

        return text;
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
