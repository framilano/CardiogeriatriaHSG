using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SchedaVisite.ViewModels;

namespace SchedaVisite.Views;

public partial class SidebarUserControl : UserControl
{
    public SidebarUserControl()
    {
        InitializeComponent();
        this.DataContext = new SidebarUserControlViewModel();
    }
}