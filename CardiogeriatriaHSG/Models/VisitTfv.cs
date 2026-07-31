using System.ComponentModel.DataAnnotations;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitTfv(string visitCode): VisitTh
{
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    [ObservableProperty] public partial string? TfvText { get; set; } = "";

    public VisitTfv(VisitTh visitTh, string visitCode) : this(visitCode)
    {
        var props = typeof(VisitTh).GetProperties().Where(p => p.GetIndexParameters().Length == 0);
        foreach (var prop in props)
        {
            if (prop.CanWrite)
                prop.SetValue(this, prop.GetValue(visitTh));
        }
    }

    partial void OnTfvTextChanged(string? value)
    {
        if (value == null) return;
        TfvText = value.Trim().Length == 0 ? null : value.Trim();
    }
}