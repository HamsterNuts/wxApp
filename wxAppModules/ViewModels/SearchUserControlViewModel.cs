using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wxAppHelper.UsingEventAggregator;

namespace wxAppModules.ViewModels
{
    public class SearchUserControlViewModel : BindableBase
    {
        IEventAggregator _ea;
        public SearchUserControlViewModel(IEventAggregator ea)
        {
            _ea = ea;
        }
        #region Property
        private string _searchProperty;
        public string SearchProperty
        {
            get { return _searchProperty; }
            set
            {
                SetProperty(ref _searchProperty, value);
                SendSearchMethod();
            }
        }


        #endregion
        #region Method
        /// <summary>
        /// 
        /// </summary>
        private void SendSearchMethod()
        {
            _ea.GetEvent<SearcchSentEvent>().Publish(SearchProperty);
        }

        #endregion
    }
}
