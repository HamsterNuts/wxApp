using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using wxApp.Views;
using Prism.Ioc;
using wxAppModules;
using System;
using System.Windows.Threading;

namespace wxApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {
            wxAppHelper.Helper.InitializeData.Initialize();
            Current.DispatcherUnhandledException += App_OnDispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

        }
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<WxAppModule>();
        }
        //void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //{
        //    if (e.ExceptionObject is System.Exception)
        //    {
        //        LogHelper.ErrorLog(null, (System.Exception)e.ExceptionObject);
        //    }
        //}

        //public static void HandleException(Exception ex)
        //{
        //    LogHelper.ErrorLog(null, ex);
        //}

        //void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        //{
        //    e.Handled = true;
        //    LogHelper.ErrorLog(null, e.Exception);
        //}
        /// <summary>
        /// UI线程抛出全局异常事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                var showlog = string.Format("UI线程全局异常。摘要信息：{0}", e.Exception.Message);
                var log = string.Format("UI线程全局异常。摘要信息：{0}，堆栈信息：{1}", e.Exception.Message, e.Exception.StackTrace);
                LogHelper.ErrorLog(null, e.Exception);
                MessageBox.Show(showlog);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("应用程序发生不可恢复的异常，将要退出！");
                var log = string.Format("应用程序发生不可恢复的UI线程全局异常。摘要信息：{0}，堆栈信息：{1}", ex.Message, ex.StackTrace);
                LogHelper.ErrorLog(null, e.Exception);
            }
        }

        /// <summary>
        /// 非UI线程抛出全局异常事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var exception = e.ExceptionObject as Exception;
                if (exception != null)
                {
                    var showlog = string.Format("非UI线程全局异常。摘要信息：{0}", exception.Message);
                    var log = string.Format("非UI线程全局异常。摘要信息：{0}，堆栈信息：{1}", exception.Message, exception.StackTrace);
                    LogHelper.ErrorLog(null, (System.Exception)e.ExceptionObject);
                    MessageBox.Show(showlog);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("应用程序发生不可恢复的异常，将要退出！");
                var log = string.Format("应用程序发生不可恢复的非UI线程全局异常。摘要信息：{0}，堆栈信息：{1}", ex.Message, ex.StackTrace);
                LogHelper.ErrorLog(null, ex);
            }
        }
    }
}
