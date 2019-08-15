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
  public  class MainOfContactViewUserControlViewModel: BindableBase
    {
        IEventAggregator _ea;
        public MainOfContactViewUserControlViewModel(IEventAggregator ea)
        {
            _ea = ea;
            HandContactData = wxAppHelper.Helper.InitializeData.HandContactData;
            TheContactDetailsCommand = new DelegateCommand<int?>(TheContactDetailsMethod);
            //TheContactDetailsCommand = new DelegateCommand<int?>(TheContactDetailsMethod).ObservesCanExecute(() => true);
            //InitializeData();
            _ea.GetEvent<SearcchSentEvent>().Subscribe(SearcchReceived);
        }
        public void TheContactDetailsMethod(int? value)
        {
            throw new ArgumentNullException("这是故意抛出的异常");
            _ea.GetEvent<TheContactDetailsSentEvent>().Publish(value);
        }
        //public void InitializeData()
        //{
        //    HandContactData = new List<HandContactViewModel>();
        //    var handContact0 = new HandContactViewModel()
        //    {
        //        IdProperty = 1,
        //        NameProperty = "阿芷",
        //        ImageProperty = "/Images/head7.jpg",
        //        SexProperty=1,
        //        SignatureProperty="一场好大的雨",
        //        NoteProperty="朋友",
        //        WxNumberProperty= "wxid_l7csinw4yqjn21",
        //        SourceProperty="通过群聊添加",
        //        AddressProperty="江苏 南通"
        //    };
        //    var handContact1 = new HandContactViewModel()
        //    {
        //        IdProperty = 2,
        //        NameProperty = "张三",
        //        ImageProperty = "/Images/head6.jpg",
        //        SexProperty = 1,
        //        SignatureProperty = "一场好大的雨",
        //        NoteProperty = "朋友",
        //        WxNumberProperty = "wxid_l7csinw4yqjn21",
        //        SourceProperty = "通过群聊添加",
        //        AddressProperty = "江苏 南通"
        //    };
        //    HandContactData.Add(handContact0);
        //    HandContactData.Add(handContact1);
        //}

        /// <summary>
        /// 筛选字段
        /// </summary>
        public void SearcchReceived(string search)
        {
            if (search != null)
            {
                HandContactData = HandContactData.Where(x => x.NameProperty.Contains(search)).ToList();
            }
            else
            {
                HandContactData = wxAppHelper.Helper.InitializeData.HandContactData;
            }
            
        }
        #region Property
        private List<HandContactViewModel> _handContactData;

        public List<HandContactViewModel> HandContactData
        {
            get { return _handContactData; }
            set { SetProperty(ref _handContactData, value); }
        }

        private HandContactViewModel _selectedHandContact;

        public HandContactViewModel SelectedHandContact
        {
            get  { return _selectedHandContact; }
            set { SetProperty(ref _selectedHandContact, value);
                TheContactDetailsMethod(_selectedHandContact.IdProperty);
            }
        }

        private int _selectIndexProperty;
        public int SelectIndexProperty
        {
            get { return _selectIndexProperty; }
            set { SetProperty(ref _selectIndexProperty, value); }
        }
        #endregion

        #region Command
        public DelegateCommand<int?> TheContactDetailsCommand { get; private set; }
        #endregion
    }
}
