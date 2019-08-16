using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wxAppHelper.ViewModel;

namespace wxAppModules.ViewModels
{
   public class MainOfCenterViewUserControlViewModel:BindableBase
    {
        public MainOfCenterViewUserControlViewModel()
        {
            var userId = 1;
            var chatRecord = wxAppHelper.Helper.InitializeData.HandChatRecordData.Where(x=>x.SourceIdProperty==userId).OrderByDescending(x=>x.RecordDateTime).GroupBy(x=>x.TargetIdProperty, (key, group) => group.First()).ToList();

            HandChatNewestRecordData = chatRecord.Select(x => new HandChatNewestRecordViewModel()
            {
                IdProperty=1,
                ContactIdProperty=x.TargetIdProperty,
                ContentProperty=x.ContentProperty,
                RecordDateTimeProperty =x.RecordDateTime
            }).ToList();
        }
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
            set { SetProperty(ref _selectedChatNewestRecord, value); }
        }
        #endregion
    }
}
