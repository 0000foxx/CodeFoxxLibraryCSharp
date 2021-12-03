using System;
using System.DirectoryServices;

namespace CodeFoxxLibrary.AuthorizationLibrary
{
    class AuthorizationManager
    {
        //取得當前類別名稱
        private static string CLASS_NAME = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private ILogger mLogger;

        private static string _path { get; set; }

        private static string _filterAttribute { get; set; }

        public AuthorizationManager(ILogger logger)
        {
            mLogger = logger;
        }

        /// <summary>
        /// 透過 Windows AD 驗證
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="username"></param>
        /// <param name="userPassword"></param>
        /// <param name="authorizedResultMessage"></param>
        /// <returns></returns>
        public bool AuthorizedByWindowsAD(string domain, string username, string userPassword, out string authorizedResultMessage)
        {
            authorizedResultMessage = string.Empty;

            string domainAndUsername = domain + "\\" + username;
            DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, userPassword);
            try
            {

                object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if ((result == null))
                {
                    authorizedResultMessage = "找不到使用者";
                    return false;
                }

                _path = result.Path;
                _filterAttribute = result.Properties["cn"][0].ToString();

                mLogger.Debug($"{CLASS_NAME}, domain = {domain}");
                mLogger.Debug($"{CLASS_NAME}, username = {username}");
                mLogger.Debug($"{CLASS_NAME}, userPassword = {userPassword}");
                mLogger.Debug($"{CLASS_NAME}, _path = {_path}");
                mLogger.Debug($"{CLASS_NAME}, _filterAttribute = {_filterAttribute}");

            }
            catch (Exception ex)
            {
                mLogger.Debug($"{CLASS_NAME}, Login by Windows AD exception = {ex}");
                authorizedResultMessage = ex.Message+", 請檢查使用者名稱或密碼是否輸入正確";
                return false;
            }

            authorizedResultMessage = "驗證成功";
            return true;
        }
    }

    interface ILogger
    {
       void Debug(string logMessage);
    }
}
