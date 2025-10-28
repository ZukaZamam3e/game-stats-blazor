using Microsoft.AspNetCore.Components;
using Radzen;
using System.Runtime.CompilerServices;

namespace GameStats.Web
{
    public static class ExtensionMethods
    {
        public static Task<bool?> DeleteConfirmation(this DialogService dialogService) => dialogService
            .Confirm("Are you sure you want to delete this record?",
                     "Delete Confirmation",
                     new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" });

        public static Task<dynamic> OpenAddEditWindow<T>(this DialogService dialogService, string title, Dictionary<string, object> parameters, string width = "500px") where T : ComponentBase => dialogService
            .OpenAsync<T>(title, parameters, new DialogOptions() { Width = width });

    }
}
