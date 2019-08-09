using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wxAppModules.Views;

namespace wxAppModules
{
    public class WxAppModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegionOfCenter", typeof(MainOfCenterViewUserControl));
            regionManager.RegisterViewWithRegion("ContentRegionOfLeft", typeof(MainOfLeftViewUserControl));
            regionManager.RegisterViewWithRegion("ContentRegionOfRight", typeof(MainOfRightViewUserControl));
            regionManager.RegisterViewWithRegion("ContentRegionOfSearch", typeof(SearchUserControl));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
