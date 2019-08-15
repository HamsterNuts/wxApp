﻿using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using wxApp.Views;
using Prism.Ioc;
using wxAppModules;

namespace wxApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {
            wxAppHelper.Helper.InitializeData.Initialize();
        }
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<WxAppModule>();
        }
    }
}
