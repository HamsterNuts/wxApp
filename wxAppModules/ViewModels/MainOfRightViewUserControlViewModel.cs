using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wxAppHelper.UsingEventAggregator;
using wxAppHelper.ViewModel;

namespace wxAppModules.ViewModels
{
    public class MainOfRightViewUserControlViewModel : BindableBase
    {
        IEventAggregator _ea;
        int _contactId;
        public MainOfRightViewUserControlViewModel(IEventAggregator ea)
        {
            _ea = ea;
            _ea.GetEvent<TheContactChatRecordSentEvent>().Subscribe(TheContactChatRecordReceived);
            TheContactChatRecordReceived(1);
            HandChatRecordData.Add(new HandChatRecordViewModel() { IdProperty = 10, SourceIdProperty = 1, TargetIdProperty = 2, ContentProperty = "132" });
            PublishMessageDelegateCommand = new DelegateCommand(PublishMessageMethod, () => true);
        }
        #region Method
        public void PublishMessageMethod()
        {
            wxAppHelper.Helper.InitializeData.HandChatRecordData.Add(new HandChatRecordViewModel()
            {
                IdProperty = wxAppHelper.Helper.InitializeData.HandChatRecordData.OrderByDescending(x => x.IdProperty).FirstOrDefault().IdProperty + 1,
                SourceIdProperty = wxAppHelper.Helper.InitializeData.TheCurrentUserId,
                TargetIdProperty = _contactId,
                ContentProperty = MessageProperty,
                RecordDateTime = DateTime.Now

            });
  
            HandChatRecordData = wxAppHelper.Helper.InitializeData.HandChatRecordData.Where(x => (x.SourceIdProperty == _contactId && x.TargetIdProperty == wxAppHelper.Helper.InitializeData.TheCurrentUserId) || (x.TargetIdProperty == _contactId && x.SourceIdProperty == wxAppHelper.Helper.InitializeData.TheCurrentUserId)).ToList();
            var subscribe = "Subscription" + "_" + wxAppHelper.Helper.InitializeData.TheCurrentUserId + "_" + ContactIdProperty;
            //订阅A
            if (!wxAppHelper.Helper.MqttNetInitializeData.SUBSCRIBENO.Contains(subscribe))
            {
                Task.Run(async () =>
                {
                    await new wxAppHelper.Helper.MqttNetInitialize(_ea).Subscribe(subscribe);
                    wxAppHelper.Helper.MqttNetInitializeData.SUBSCRIBENO.Add(subscribe);
                });
                //发送X
                Task.Run(async () =>
                {
                    await new wxAppHelper.Helper.MqttNetInitialize(_ea).Publish(wxAppHelper.Helper.MqttNetInitializeData.SUBSCRIBE, subscribe + "|" + ContactIdProperty);
                });
            }
            
            
            //发送A
            Task.Run(async () =>
            {
                await new wxAppHelper.Helper.MqttNetInitialize(_ea).Publish(subscribe, MessageProperty);
                MessageProperty = null;
            });

            
        }
        public void TheContactChatRecordReceived(int? contactId)
        {
            _contactId = Convert.ToInt32(contactId);
            var contact = wxAppHelper.Helper.InitializeData.HandContactData.Where(x => x.IdProperty == contactId).FirstOrDefault();
            ContactIdProperty = contactId;
            NameProperty = contact != null ? contact.NameProperty : null;
            //获取当前用户和联系人的聊天记录
            HandChatRecordData = wxAppHelper.Helper.InitializeData.HandChatRecordData.Where(x => (x.SourceIdProperty == contactId && x.TargetIdProperty == wxAppHelper.Helper.InitializeData.TheCurrentUserId) || (x.TargetIdProperty == contactId && x.SourceIdProperty == wxAppHelper.Helper.InitializeData.TheCurrentUserId)).ToList();

        }

        
        #endregion
        #region Command
        /// <summary>
        /// 设置窗口在最上方
        /// </summary>
        public DelegateCommand PublishMessageDelegateCommand { get; private set; }
        #endregion
        #region Property
        private int? _contactIdProperty;

        public int? ContactIdProperty
        {
            get { return _contactIdProperty; }
            set { SetProperty(ref _contactIdProperty, value); }
        }
        /// <summary>
        /// 右 内容框
        /// </summary>
        private string _nameProperty;

        public string NameProperty
        {
            get { return _nameProperty; }
            set { SetProperty(ref _nameProperty, value); }
        }

        private List<HandChatRecordViewModel> _handChatRecordData;
        public List<HandChatRecordViewModel> HandChatRecordData
        {
            get { return _handChatRecordData; }
            set { SetProperty(ref _handChatRecordData, value); }
        }

        private string _messageProperty;

        public string MessageProperty
        {
            get { return _messageProperty; }
            set { SetProperty(ref _messageProperty, value); }
        }
        #endregion
    }
}
