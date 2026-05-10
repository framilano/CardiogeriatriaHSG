using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;

namespace CardiogeriatriaHSG.Views;

public partial class SidebarUserControl : UserControl
{
    public SidebarUserControl()
    {
        InitializeComponent();
        Loaded += (_, _) =>
        {
            // At this point, ItemsControl has created all item containers
            AddHighlight(this
                .GetVisualDescendants()
                .OfType<Button>().First(b => Equals(b.Tag, "MenuEntry")));
        };
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
        AddHighlight(btn!);
        //Log.Debug("I clicked on " + btn.Content);
    }
}