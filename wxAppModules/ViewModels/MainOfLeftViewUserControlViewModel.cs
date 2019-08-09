using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wxAppModules.Views;

namespace wxAppModules.ViewModels
{
   public class MainOfLeftViewUserControlViewModel:BindableBase
    {
        public MainOfLeftViewUserControlViewModel()
        {
            CurrentUserInfoCommand = new DelegateCommand(CurrentUserInfoMethod, ()=>true);
        }

        #region method
        /// <summary>
        /// 打开当前用户信息
        /// </summary>
        public void CurrentUserInfoMethod()
        {
          var view =  new CurrentUserInfoUserControl();
            view.Show();
        }
        #endregion

        #region command
        /// <summary>
        /// 当前用户信息
        /// </summary>
        public DelegateCommand CurrentUserInfoCommand { get; private set; }

        #endregion
    }
}
