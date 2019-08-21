using MahApps.Metro.Controls.Dialogs;
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
using wxAppHelper.Helper;
using wxAppHelper.UsingEventAggregator;

namespace wxApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        IEventAggregator _ea;
        IRegionManager _regionManager;
        // Variable
        private IDialogCoordinator dialogCoordinator;
        public MainWindowViewModel(IEventAggregator ea, IRegionManager regionManager)
        {
            
            dialogCoordinator = DialogCoordinator.Instance;
            _ea = ea;
            new wxAppHelper.Helper.MqttNetInitialize(_ea).InitializeAsync();
            _regionManager = regionManager;
            IsLoginFailed = true;
            MessageReceived("message");
            DetailsReceived("chat");
            WindowStateProperty = WindowState.Normal;
            TitleProperty = "WXApp";

            ContentRegionOfLeftProperty = "ContentRegionOfLeft";
            ContentRegionOfSearchProperty = "ContentRegionOfSearch";
            ContentRegionOfCenterProperty = "ContentRegionOfCenter";
            //ContentRegionOfRightProperty = "ContentRegionOfRight";
            ContentRegionOfRightProperty = "ContentRegionOfContactDetails";
            SndmsgDelegateCommand = new DelegateCommand(Execute, CanExecute);
            CloseDelegateCommand = new DelegateCommand(CloseExecute, CanExecute);
            MinimizedDelegateCommand = new DelegateCommand(MinimizedExecute, CanExecute);
            MaximizedDelegateCommand = new DelegateCommand(MaximizedExecute, CanExecute);
            TopmostDelegateCommand = new DelegateCommand(TopmostExecute, CanExecute);

            _ea.GetEvent<MessageSentEvent>().Subscribe(MessageReceived);
            _ea.GetEvent<SearcchSentEvent>().Subscribe(SearcchReceived);
            _ea.GetEvent<DetailsSentEvent>().Subscribe(DetailsReceived);
            _ea.GetEvent<TheContactDetailsSentEvent>().Subscribe(TheContactDetailsReceived);
        }
        #region method
        public void TheContactDetailsReceived(int? value)
        {
            if (value > 0)
            {
                ContactDetailsVisibilityProperty = Visibility.Visible;
                RightVisibilityProperty = Visibility.Hidden;
            }
        }
        //public async Task<MessageDialogResult>  ShowMessageButtonDialog(string header, string message)
        //{
        //    var mySettings = new MetroDialogSettings()
        //    {
        //        AffirmativeButtonText = "确定",
        //        NegativeButtonText = "取消",
        //        ColorScheme = MetroDialogColorScheme.Accented
        //    };

        //    var result =  await dialogCoordinator.ShowMessageAsync(this,header, message, MessageDialogStyle.AffirmativeAndNegative, mySettings);
        //    return result;

        //}
        ///// <summary>
        ///// 显示弹框
        ///// </summary>
        //public async void ShowMessageDialog(string header,string message)
        //{
        //    await dialogCoordinator.ShowMessageAsync(this, header, message);
        //}

        //private async void RunProgressFromVm(string header, string message)
        //{
        //    var controller = await dialogCoordinator.ShowProgressAsync(this, header, message);
        //    controller.SetIndeterminate();

        //    await TaskEx.Delay(3000);

        //    await controller.CloseAsync();
        //}

        public void DetailsReceived(string details)
        {
            switch (details)
            {
                case "chat":
                    RightVisibilityProperty = Visibility.Visible;
                    ContactDetailsVisibilityProperty = Visibility.Hidden;
                    break;
                case "details":
                    RightVisibilityProperty = Visibility.Hidden;
                    ContactDetailsVisibilityProperty = Visibility.Visible;
                    break;

            }


        }
        public void SearcchReceived(string search)
        {
            ContentRegionOfCenterProperty = "ContentRegionOfContact";
            CenterVisibilityProperty = Visibility.Hidden;
            ContactVisibilityProperty = Visibility.Visible;
            DynamicVisibilityProperty = Visibility.Hidden;
        }
        private void MessageReceived(string message)
        {
            switch (message)
            {
                case "message":
                    ContentRegionOfCenterProperty = "ContentRegionOfCenter";
                    CenterVisibilityProperty = Visibility.Visible;
                    ContactVisibilityProperty = Visibility.Hidden;
                    DynamicVisibilityProperty = Visibility.Hidden;
                    RightVisibilityProperty = Visibility.Visible;
                    ContactDetailsVisibilityProperty = Visibility.Hidden;
                    break;
                case "contact":
                    ContentRegionOfCenterProperty = "ContentRegionOfContact";
                    CenterVisibilityProperty = Visibility.Hidden;
                    ContactVisibilityProperty = Visibility.Visible;
                    DynamicVisibilityProperty = Visibility.Hidden;
                    RightVisibilityProperty = Visibility.Hidden;
                    ContactDetailsVisibilityProperty = Visibility.Visible;
                    break;
                case "dynamic":
                    ContentRegionOfCenterProperty = "ContentRegionOfDynamic";
                    CenterVisibilityProperty = Visibility.Hidden;
                    ContactVisibilityProperty = Visibility.Hidden;
                    DynamicVisibilityProperty = Visibility.Visible;
                    break;
            }

            //RegionManager.SetRegionManager("ContentRegionOfCenterControl", ContentRegionOfCenterProperty);
        }

        /// <summary>
        /// 窗口置顶
        /// </summary>
        public void TopmostExecute()
        {
            string message = TopmostProperty ? "取消置顶成功！" : "置顶成功！";
            wxAppHelper.Helper.ShowDialog.ShowRunProgress(this, dialogCoordinator, "置顶提示", message, 3000);
            // ShowMessageDialog("置顶提示", message);
            TopmostProperty = TopmostProperty ? false : true;
        }
        //关闭窗口
        public async void CloseExecute()
        {

            var result = await wxAppHelper.Helper.ShowDialog.ShowMessageButtonDialog(this, dialogCoordinator, "提示", "是否关闭当前窗口");
            if (result == MessageDialogResult.Affirmative)
                IsLoginFailed = false;
            //一般关闭当前窗体使用:
            //this.Close();
            //关闭全部窗体并退出程序使用：
            //Application.Current.Shutdown();
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
            TitleProperty = "change";
            MessageBox.Show(TitleProperty);
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

        /// <summary>
        /// 设置窗口在最上方
        /// </summary>
        public DelegateCommand TopmostDelegateCommand { get; private set; }
        #endregion
        #region file
        private string _titleProperty;

        public string TitleProperty
        {
            get { return _titleProperty; }
            set { SetProperty(ref _titleProperty, value); }
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

        private Visibility _contactVisibilityProperty;

        public Visibility ContactVisibilityProperty
        {
            get { return _contactVisibilityProperty; }
            set { SetProperty(ref _contactVisibilityProperty, value); }
        }

        private Visibility _centerVisibilityProperty;

        public Visibility CenterVisibilityProperty
        {
            get { return _centerVisibilityProperty; }
            set { SetProperty(ref _centerVisibilityProperty, value); }
        }

        private Visibility _dynamicVisibilityProperty;

        public Visibility DynamicVisibilityProperty
        {
            get { return _dynamicVisibilityProperty; }
            set { SetProperty(ref _dynamicVisibilityProperty, value); }
        }

        private Visibility _rightVisibilityProperty;

        public Visibility RightVisibilityProperty
        {
            get { return _rightVisibilityProperty; }
            set { SetProperty(ref _rightVisibilityProperty, value); }
        }
        private Visibility _contactDetailsVisibilityProperty;

        public Visibility ContactDetailsVisibilityProperty
        {
            get { return _contactDetailsVisibilityProperty; }
            set { SetProperty(ref _contactDetailsVisibilityProperty, value); }
        }
        private bool _topmostProperty;
        //设置窗口在最上方
        public bool TopmostProperty
        {
            get { return _topmostProperty; }
            set { SetProperty(ref _topmostProperty, value); }
        }

        #endregion
    }
}
