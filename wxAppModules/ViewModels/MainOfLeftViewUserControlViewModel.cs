using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wxAppModules.Views;
using Prism.Events;
using wxAppHelper.UsingEventAggregator;

namespace wxAppModules.ViewModels
{
    public class MainOfLeftViewUserControlViewModel : BindableBase
    {
        IEventAggregator _ea;
        public MainOfLeftViewUserControlViewModel(IEventAggregator ea)
        {
            _ea = ea;
            CurrentUserInfoCommand = new DelegateCommand(CurrentUserInfoMethod, () => true);
            OpenMessageCommand = new DelegateCommand(OpenMessageMethod, () => true);
            OpenContactCommand = new DelegateCommand(OpenContactMethod, () => true);
            OpenDynamicCommand = new DelegateCommand(OpenDynamicMethod, () => true);
        }

        #region method
        /// <summary>
        /// 打开当前用户信息
        /// </summary>
        public void CurrentUserInfoMethod()
        {
            var view = new CurrentUserInfoUserControl();
            view.Show();
        }
        /// <summary>
        /// 打开消息
        /// </summary>
        public void OpenMessageMethod()
        {
            MessageProperty = "message";
            SendMessageMethod();
        }
        /// <summary>
        /// 打开联系人
        /// </summary>
        public void OpenContactMethod()
        {
            MessageProperty = "contact";
            SendMessageMethod();
        }
        /// <summary>
        /// 打开动态
        /// </summary>
        public void OpenDynamicMethod()
        {
            MessageProperty = "dynamic";
            SendMessageMethod();
        }
        /// <summary>
        /// 
        /// </summary>
        private void SendMessageMethod()
        {
            _ea.GetEvent<MessageSentEvent>().Publish(MessageProperty);
        }
        #endregion

        #region command

        public DelegateCommand CurrentUserInfoCommand { get; private set; }
        public DelegateCommand OpenMessageCommand { get; private set; }
        public DelegateCommand OpenContactCommand { get; private set; }
        public DelegateCommand OpenDynamicCommand { get; private set; }
        #endregion

        #region property
        private string _messageProperty;

        public string MessageProperty
        {
            get { return _messageProperty; }
            set { SetProperty(ref _messageProperty, value); }
        }

        #endregion
    }
}
