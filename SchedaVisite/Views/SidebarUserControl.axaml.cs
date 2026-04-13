using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;

namespace SchedaVisite.Views;

public partial class SidebarUserControl : UserControl
{
    public SidebarUserControl()
    {
        InitializeComponent();
    }
    
    private void AddHighlight(Button buttonToHighlight)
    {
        var buttons = this
            .GetVisualDescendants()
            .OfType<Button>()
            .Where(b => Equals(b.Tag, "MenuEntry"));

        foreach (var buttonToRemoveHighlight in buttons)
        {
            buttonToRemoveHighlight.Classes.Remove("SelectedMenuButton");
            buttonToRemoveHighlight.Classes.Add("NotSelectedMenuButton");
        }
        
        buttonToHighlight.Classes.Remove("NotSelectedMenuButton");
        buttonToHighlight.Classes.Add("SelectedMenuButton");
    }

    public void OnButtonClick(object? sender, RoutedEventArgs routedEventArgs)
    {
        var btn = sender as Button;
        AddHighlight(btn);
        //Console.WriteLine("I clicked on " + btn.Content);
    }
}