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
    public class TheContactDetailsUserControlViewModel : BindableBase
    {
        IEventAggregator _ea;
        public TheContactDetailsUserControlViewModel(IEventAggregator ea)
        {
            _ea = ea;
            //InitializeData();
            _ea.GetEvent<TheContactDetailsSentEvent>().Subscribe(InitializeData);
            HandContactProperty = wxAppHelper.Helper.InitializeData.HandContactData.FirstOrDefault();
        }

        public void InitializeData(int? value)
        {
            HandContactProperty = wxAppHelper.Helper.InitializeData.HandContactData.Where(x => x.IdProperty == value).FirstOrDefault();
            //var handContact = new HandContactViewModel()
            //{
            //    IdProperty = 1,
            //    NameProperty = "阿芷",
            //    ImageProperty = "/Images/head7.jpg",
            //    SexProperty = 1,
            //    SignatureProperty = "一场好大的雨",
            //    NoteProperty = "朋友",
            //    WxNumberProperty = "wxid_l7csinw4yqjn21",
            //    SourceProperty = "通过群聊添加",
            //    AddressProperty = "江苏 南通"
            //};
            //HandContactProperty = handContact;
        }
        #region  Property
        private HandContactViewModel _handContactProperty;

        public HandContactViewModel HandContactProperty
        {
            get { return _handContactProperty; }
            set { SetProperty(ref _handContactProperty, value); }
        }
        #endregion
    }
}
