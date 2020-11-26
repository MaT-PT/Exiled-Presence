using log4net;
using System;
using System.Windows.Forms;

namespace Program {
    internal static class Program {
        /// <summary>
        /// Entry point for the application
        /// </summary>
 
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args) {
            AppDomain currentDomain = default(AppDomain);
            currentDomain = AppDomain.CurrentDomain;
            // Handler for unhandled exceptions.
            currentDomain.UnhandledException += GlobalUnhandledExceptionHandler;
            // Handler for exceptions in threads behind forms.
            System.Windows.Forms.Application.ThreadException += GlobalThreadExceptionHandler;

            // We use Windows Forms to run the application as a tray app
            log.Info("Starting app...");
            Application.Run(new TrayAppContext());
            log.Info("Exited.");
        }

        private static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            //log.Error(ex.Message + "\n" + ex.StackTrace);
            log.Error(ex.Message, ex);
        }

        private static void GlobalThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            //log.Error(ex.Message + "\n" + ex.StackTrace);
            log.Error(ex.Message, ex);
        }
    }
}