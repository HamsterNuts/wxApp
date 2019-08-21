using Newtonsoft.Json;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wxAppHelper.Helper;
using wxAppHelper.UsingEventAggregator;
using wxAppHelper.ViewModel;

namespace wxAppModules.ViewModels
{
    public class MainOfCenterViewUserControlViewModel : BindableBase
    {
        IEventAggregator _ea;
        public MainOfCenterViewUserControlViewModel(IEventAggregator ea)
        {
            _ea = ea;
            Initialize();
            // SelectedChatNewestRecord = HandChatNewestRecordData.FirstOrDefault();
            _ea.GetEvent<TheNotificationsSentEvent>().Subscribe(RefreshMessages);


        }
        #region method
        public void RefreshMessages(string message)
        {
            var model = JsonConvert.DeserializeObject<TheNotifications>(message);
            var HandChatRecord = new HandChatRecordViewModel()
            {
                IdProperty = InitializeData.HandChatRecordData.Max(x => x.IdProperty) + 1,
                SourceIdProperty = model.SourceId,
                TargetIdProperty = model.TargetId,
                ContentProperty = model.Content,
                RecordDateTime = DateTime.Now
            };
            InitializeData.HandChatRecordData.Add(HandChatRecord);
            Initialize();
        }

        public void Initialize()
        {
            var chatRecord = wxAppHelper.Helper.InitializeData.HandChatRecordData.Where(x => x.SourceIdProperty == InitializeData.TheCurrentUserId|| x.TargetIdProperty == InitializeData.TheCurrentUserId).OrderByDescending(x => x.RecordDateTime).GroupBy(x => x.TargetIdProperty, (key, group) => group.First()).ToList();

            HandChatNewestRecordData = chatRecord.Select(x => new HandChatNewestRecordViewModel()
            {
                IdProperty = 1,
                ContactIdProperty = x.SourceIdProperty,
                ContentProperty = x.ContentProperty,
                RecordDateTimeProperty = x.RecordDateTime
            }).Where(x=>x.ContactIdProperty!=wxAppHelper.Helper.InitializeData.TheCurrentUserId).ToList();
            if (SelectedChatNewestRecord == null&& HandChatNewestRecordData.Count>0)
            {
                SelectedChatNewestRecord = HandChatNewestRecordData.FirstOrDefault();
            }
        }
        public void PublishChatNewestRecordmethod(bool isPublish = true)
        {

        }
        #endregion
        #region Property
        private List<HandChatNewestRecordViewModel> _handChatNewestRecordData;
        public List<HandChatNewestRecordViewModel> HandChatNewestRecordData
        {
            get { return _handChatNewestRecordData; }
            set { SetProperty(ref _handChatNewestRecordData, value); }
        }

        private HandChatNewestRecordViewModel _selectedChatNewestRecord;
        public HandChatNewestRecordViewModel SelectedChatNewestRecord
        {
            get { return _selectedChatNewestRecord; }
            set
            {
                SetProperty(ref _selectedChatNewestRecord, value);
                if(_selectedChatNewestRecord!=null)
                _ea.GetEvent<TheContactChatRecordSentEvent>().Publish(_selectedChatNewestRecord.ContactIdProperty);
            }
        }
        #endregion
    }
}
