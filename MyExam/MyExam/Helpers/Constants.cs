using Realms;

namespace MyExam.Helpers
{
    /// <summary>
    /// Constants used in the app
    /// </summary>
    public static class Constants
    {
        public static string EmailRegexValidator = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z_-])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        public static string ApiUrl = "https://randomuser.me";
    }
}
