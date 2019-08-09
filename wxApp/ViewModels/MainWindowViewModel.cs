using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wxAppHelper.UsingEventAggregator;

namespace wxApp.ViewModels
{
  public class MainWindowViewModel:BindableBase
{
        IEventAggregator _ea;
        public MainWindowViewModel(IEventAggregator ea)
        {
            _ea = ea;
            IsLoginFailed = true;
            WindowStateProperty = WindowState.Normal;
            Title = "WXApp";
            ContentRegionOfLeftProperty = "ContentRegionOfLeft";
            ContentRegionOfSearchProperty = "ContentRegionOfSearch";
            ContentRegionOfCenterProperty = "ContentRegionOfCenter";
            ContentRegionOfRightProperty = "ContentRegionOfRight";
            SndmsgDelegateCommand = new DelegateCommand(Execute, CanExecute);
            CloseDelegateCommand = new DelegateCommand(CloseExecute, CanExecute);
            MinimizedDelegateCommand = new DelegateCommand(MinimizedExecute, CanExecute);
            MaximizedDelegateCommand = new DelegateCommand(MaximizedExecute, CanExecute);

            _ea.GetEvent<MessageSentEvent>().Subscribe(MessageReceived);
        }
        #region method
        private void MessageReceived(string message)
        {
            switch (message)
            {
                case "message":
                    ContentRegionOfCenterProperty = "ContentRegionOfCenter";
                    break;
                case "contact":
                    ContentRegionOfCenterProperty = "ContentRegionOfContact";
                    break;
                case "dynamic":
                    ContentRegionOfCenterProperty = "ContentRegionOfDynamic";
                    break;
            }
        }
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

        /// <summary>
        /// 左
        /// </summary>
        private string _contentRegionOfLeftProperty;

        public string ContentRegionOfLeftProperty
        {
            get { return _contentRegionOfLeftProperty; }
            set { SetProperty(ref _contentRegionOfLeftProperty, value); }
        }

        /// <summary>
        /// 中 筛选框
        /// </summary>
        private string _contentRegionOfSearchProperty;

        public string ContentRegionOfSearchProperty
        {
            get { return _contentRegionOfSearchProperty; }
            set { SetProperty(ref _contentRegionOfSearchProperty, value); }
        }

        /// <summary>
        /// 中 内容框
        /// </summary>
        private string _contentRegionOfCenterProperty;

        public string ContentRegionOfCenterProperty
        {
            get { return _contentRegionOfCenterProperty; }
            set { SetProperty(ref _contentRegionOfCenterProperty, value); }
        }

        /// <summary>
        /// 右 内容框
        /// </summary>
        private string _contentRegionOfRightProperty;

        public string ContentRegionOfRightProperty
        {
            get { return _contentRegionOfRightProperty; }
            set { SetProperty(ref _contentRegionOfRightProperty, value); }
        }

        #endregion
    }
}
