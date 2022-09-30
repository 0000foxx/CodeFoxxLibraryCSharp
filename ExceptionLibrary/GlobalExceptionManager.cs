using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CodeFoxxLibrary.ExceptionLibrary
{
    /// <summary>
    /// 捕捉全域異常
    /// </summary>
    class GlobalExceptionManager
    {
        private static string CLASS_NAME = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static ILogger sLogger;

        /// <summary>
        /// 在呼叫Application.Run()前呼叫本方法
        /// </summary>
        public static void CatchGlobalException(ILogger logger)
        {
            sLogger = logger;

            //設定應用程式處理異常方式：ThreadException處理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.ThreadExit += ApplicationThreadExit;
            Application.ApplicationExit += ApplicationExit;

            //處理UI執行緒異常
            Application.ThreadException += CatchUIThreadException;

            //處理非UI執行緒異常
            AppDomain.CurrentDomain.UnhandledException += CatchNonUIThreadException;
        }

        private static void ApplicationExit(object sender, EventArgs e)
        {
            sLogger.Debug($"{CLASS_NAME}, Application Exit");
        }

        private static void ApplicationThreadExit(object sender, EventArgs e)
        {
            sLogger.Debug($"{CLASS_NAME}, Application Thread Exit");
        }

        /// <summary>
        /// this method will be called frequent(4~5 per Second) when application idle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ApplicationIdle(object sender, EventArgs e)
        {
            sLogger.Debug($"{CLASS_NAME}, Application IDLE");
        }

        private static void CatchUIThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string processedExceptionMessage = ProcessExceptionMessage(e.Exception, e.ToString());
            MessageBox.Show(processedExceptionMessage, "UI執行緒異常-系統錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            sLogger.Debug($"{CLASS_NAME}, {e.Exception}");
        }

        private static void CatchNonUIThreadException(object sender, UnhandledExceptionEventArgs e)
        {
            string processedExceptionMessage = ProcessExceptionMessage(e.ExceptionObject as Exception, e.ToString());
            MessageBox.Show(processedExceptionMessage, "非UI執行緒異常-系統錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            sLogger.Debug($"{CLASS_NAME}, {e.ExceptionObject as Exception}");
        }

        /// <summary>
        /// 處理自訂異常訊息
        /// </summary>
        /// <param name="catchedException">異常物件</param>
        /// <param name="backStr">備用異常訊息：當異常為null時有效</param>
        /// <returns>異常字串文字</returns>
        private static string ProcessExceptionMessage(Exception catchedException, string backStr)
        {
            StringBuilder processedExceptionMessage = new StringBuilder();
            processedExceptionMessage.AppendLine("****************************異常文字****************************");
            processedExceptionMessage.AppendLine("【出現時間】：" + DateTime.Now.ToString());
            if (catchedException != null)
            {
                processedExceptionMessage.AppendLine("【異常型別】：" + catchedException.GetType().Name);
                processedExceptionMessage.AppendLine("【異常資訊】：" + catchedException.Message);
                processedExceptionMessage.AppendLine("【堆疊呼叫】：" + catchedException.StackTrace);
            }
            else
            {
                processedExceptionMessage.AppendLine("【未處理異常】：" + backStr);
            }
            processedExceptionMessage.AppendLine("***************************************************************");
            return processedExceptionMessage.ToString();
        }

    }

    interface ILogger
    {
        void Debug(String logMessage);
    }
}
