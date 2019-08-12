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
            HandContactData = new List<HandContactViewModel>();
            InitializeData();
            _ea.GetEvent<SearcchSentEvent>().Subscribe(SearcchReceived);
        }
        public void InitializeData()
        {
            var handContact0 = new HandContactViewModel()
            {
                NameProperty = "阿芷",
                ImageProperty = "/Images/head7.jpg"
            };
            var handContact1 = new HandContactViewModel()
            {
                NameProperty = "张三",
                ImageProperty = "/Images/head6.jpg"
            };
            HandContactData.Add(handContact0);
            HandContactData.Add(handContact1);
        }

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
                InitializeData();
            }
            
        }
        #region Property
        private List<HandContactViewModel> _handContactData;

        public List<HandContactViewModel> HandContactData
        {
            get { return _handContactData; }
            set { SetProperty(ref _handContactData, value); }
        }

        #endregion
    }
}
