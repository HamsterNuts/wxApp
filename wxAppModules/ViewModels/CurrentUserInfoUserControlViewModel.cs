using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;

namespace wxAppModules.ViewModels
{
    public class CurrentUserInfoUserControlViewModel : BindableBase
    {
        public CurrentUserInfoUserControlViewModel()
        {
            ColseCommand = new DelegateCommand(ColseMethod, () => true);
            IsShowProperty = true;
        }

        #region command
        public DelegateCommand ColseCommand{ private get;set;}
        #endregion

        #region method
        public void ColseMethod()
        {
            IsShowProperty = false;
        }
        #endregion
        #region property
        private bool _isShowProperty;
        public bool IsShowProperty
        {
            get { return _isShowProperty; }
            set { SetProperty(ref _isShowProperty, value); }
        }
        #endregion
    }
}

