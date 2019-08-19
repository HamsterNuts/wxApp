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
   public class MainOfRightViewUserControlViewModel:BindableBase
    {
        IEventAggregator _ea;
        public MainOfRightViewUserControlViewModel(IEventAggregator ea)
        {
            _ea = ea;
            _ea.GetEvent<TheContactChatRecordSentEvent>().Subscribe(TheContactChatRecordReceived);
            TheContactChatRecordReceived(1);
            HandChatRecordData.Add(new HandChatRecordViewModel() { IdProperty = 10, SourceIdProperty = 1, TargetIdProperty = 2, ContentProperty = "132" });
        }
        #region method
        public void TheContactChatRecordReceived(int? contactId)
        {
           var contact = wxAppHelper.Helper.InitializeData.HandContactData.Where(x => x.IdProperty == contactId).FirstOrDefault();
           NameProperty =contact!=null? contact.NameProperty:null;
            //获取当前用户和联系人的聊天记录
           HandChatRecordData = wxAppHelper.Helper.InitializeData.HandChatRecordData.Where(x => (x.SourceIdProperty == contactId && x.TargetIdProperty == wxAppHelper.Helper.InitializeData.TheCurrentUserId) || (x.TargetIdProperty == contactId && x.SourceIdProperty == wxAppHelper.Helper.InitializeData.TheCurrentUserId)).ToList();

        }
        #endregion
        #region Property
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

        #endregion
    }
}
