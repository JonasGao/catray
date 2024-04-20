namespace WinFormsApp1
{
    internal static class Program
    {
        const string AppId = "ClashTray/8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if DEBUG
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
#else
            using Mutex mutex = new(false, AppId);
            if (mutex.WaitOne(0, false))
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("Application already running.");
            }
#endif
        }
    }
}