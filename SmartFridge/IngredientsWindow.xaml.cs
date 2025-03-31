using SmartFridge.Database;
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
/// Interaction logic for IngredientsWindow.xaml
/// </summary>
public partial class IngredientsWindow : Window
{
    private UserIngredientsDbContext _db;

    public IngredientsWindow()
    {
        InitializeComponent();

        var dbFactory = new HubDbContextFactory();
        _db = dbFactory.CreateUserIngredientsDbContext();

        LoadIngredients();
    }

    private void LoadIngredients()
    {
        lstUserIngredients.ItemsSource = _db.Ingrediente
            .Select(i => $"{i.Nume} - Expiră la: {i.DataExpirare.ToShortDateString()}")
            .ToList();
    }

    private void CloseWindow_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
