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
        Opened += (_, _) =>
        {
            //If the user press Enter key the dialog closes, we need to put the focus on the OK button
            ConfirmButton.Focus();
        };
    }
    
    private void OnCloseClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}