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

        public static Task<dynamic> OpenAddEditWindow<T>(this DialogService dialogService, string title, Dictionary<string, object> parameters, string width = "300px") where T : ComponentBase => dialogService
            .OpenAsync<T>(title, parameters, new DialogOptions() { Width = width });

        public static async Task<T> ParseResponseAsync<T>(this HttpResponseMessage responseMessage, [CallerMemberName] string callerName = "")
        {
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Error occurred calling {callerName}: {responseMessage.ReasonPhrase}");
            }
            var responseData = await responseMessage.Content.ReadFromJsonAsync<T>();
            if (responseData == null)
            {
                throw new ApplicationException($"No data returned from {callerName}");
            }
            return responseData;
        }

    }
}
