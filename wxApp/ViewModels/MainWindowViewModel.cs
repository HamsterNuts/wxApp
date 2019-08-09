using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wxApp.ViewModels
{
  public class MainWindowViewModel:BindableBase
{
        public MainWindowViewModel()
        {
            IsLoginFailed = true;
            WindowStateProperty = WindowState.Normal;
            Title = "WXApp";
            SndmsgDelegateCommand = new DelegateCommand(Execute, CanExecute);
            CloseDelegateCommand = new DelegateCommand(CloseExecute, CanExecute);
            MinimizedDelegateCommand = new DelegateCommand(MinimizedExecute, CanExecute);
            MaximizedDelegateCommand = new DelegateCommand(MaximizedExecute, CanExecute);
        }
        #region method
        //关闭窗口
        public void CloseExecute()
        {
            //一般关闭当前窗体使用:
            //this.Close();
            //关闭全部窗体并退出程序使用：
            Application.Current.Shutdown();
           // IsLoginFailed = false;
        }
        /// <summary>
        /// 最小化窗口
        /// </summary>
        public void MinimizedExecute()
        {
            WindowStateProperty = WindowState.Minimized;
        }
        /// <summary>
        /// 最大化窗口
        /// </summary>
        public void MaximizedExecute()
        {
            if (WindowStateProperty == WindowState.Normal)
            {
                WindowStateProperty = WindowState.Maximized;
            }
            else if (WindowStateProperty == WindowState.Maximized)
            {
                WindowStateProperty = WindowState.Normal;
            }
        }
        public void Execute()
        {
            Title = "change";
            MessageBox.Show(Title);
        }

        public bool CanExecute()
        {
            return true;
        }
        #endregion
        #region command
        /// <summary>
        /// 发送消息
        /// </summary>
        public DelegateCommand SndmsgDelegateCommand { get; private set; }
        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        public DelegateCommand CloseDelegateCommand { get; private set; }
        /// <summary>
        /// 最小化当前窗口
        /// </summary>
        public DelegateCommand MinimizedDelegateCommand { get; private set; }
        /// <summary>
        /// 最大化当前窗口
        /// </summary>
        public DelegateCommand MaximizedDelegateCommand { get; private set; }
        #endregion
        #region file
        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isLoginFailed;
        public bool IsLoginFailed
        {
            get { return _isLoginFailed; }
            set { SetProperty(ref _isLoginFailed, value); }
        }

        private WindowState _windowStateProperty;
        public WindowState WindowStateProperty
        {
            get { return _windowStateProperty; }
            set { SetProperty(ref _windowStateProperty, value); }
        }
        #endregion
    }
}
