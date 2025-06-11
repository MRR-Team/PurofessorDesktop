using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purofessor.Localization
{
    public static class Messages
    {
        public static Func<string, string?> ResourceLookup { get; set; } = key =>
        {
            return Application.Current?.TryFindResource(key) as string;
        };
        private static string? DefaultResourceLookup(string key)
        {
            return (ResourceLookup ?? DefaultResourceLookup)(key) ?? $"[{key}]";
        }


        public static string Error => Get("Error");
        public static string Warning => Get("Warning");
        public static string Success => Get("Success");
        public static string NoConnection => Get("NoConnection");


        public static string LogoutFailed => Get("LogoutFailed");
        public static string LoginFailed => Get("LoginFailed");
        public static string LoginFailedGoogle => Get("LoginFailedGoogle");
        public static string ShowChampionsError => Get("ShowChampionsError");
        public static string UpdateRotationError => Get("UpdateRotationError");
        public static string SaveSuccess => Get("SaveSuccess");
        public static string DownloadStatsError => Get("DownloadStatsError");
        public static string DownloadChampionsError => Get("DownloadChampionsError");
        public static string ChampionDoesntExist => Get("ChampionDoesntExist");
        public static string NoRecommendedItems => Get("NoRecommendedItems");
        public static string BuildError => Get("BuildError");
        public static string YoureNotloggedin => Get("YoureNotloggedin");
        public static string DataUpdated => Get("DataUpdated");
        public static string DataUpdatedFailed => Get("DataUpdatedFailed");
        public static string DataUpdatedError => Get("DataUpdatedError");
        public static string RotationShowError => Get("RotationShowError");
        public static string LoadingLogsError => Get("RotationShowError");
        public static string NotificationSent => Get("NotificationSent");
        public static string NotificationError => Get("NotificationError");
        public static string EnterVaildEmail => Get("EnterVaildEmail");
        public static string PasswordResetMail => Get("PasswordResetMail");
        public static string PasswordResetMailError => Get("PasswordResetMailError");
        public static string EnterChampionAndPosition => Get("EnterChampionAndPosition");
        public static string ChampionNotFound => Get("ChampionNotFound");
        public static string CounterGetError => Get("CounterGetError");

        public static string FailedLoadingUsers => Get("FailedLoadingUsers");
        public static string FailedRefreshingList => Get("FailedRefreshingList");
        public static string DeleteUserWarning => Get("DeleteUserWarning");
        public static string DeleteUserError => Get("DeleteUserError");
        public static string ConnectionLost => Get("ConnectionLost");

        public static string FillAllError => Get("FillAllError");
        public static string PasswordMismatchError => Get("PasswordMismatchError");
        public static string RegisterComplete => Get("RegisterComplete");
        public static string RegisterFailed => Get("RegisterFailed");
        public static string RegisterError => Get("RegisterError");



        private static string Get(string key)
        {
            return ResourceLookup?.Invoke(key) ?? $"[{key}]";
        }
    }
}
