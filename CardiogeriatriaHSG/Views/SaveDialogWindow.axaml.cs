using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CardiogeriatriaHSG.Views;

public partial class SaveDialogWindow : Window
{
    public SaveDialogWindow() { InitializeComponent(); }
    public SaveDialogWindow(string message)
    {
        InitializeComponent();
        Message.Text = message;
    }
    
    private void OnCloseClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}