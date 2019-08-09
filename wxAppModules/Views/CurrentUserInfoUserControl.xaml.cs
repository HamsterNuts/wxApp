using System.Windows;

namespace wxAppModules.Views
{
    /// <summary>
    /// CurrentUserInfoUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class CurrentUserInfoUserControl : Window
    {
        public CurrentUserInfoUserControl()
        {
            InitializeComponent();
            this.IsEnabledChanged += ShowWindow_IsEnabledChanged;
        }

        private void ShowWindow_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == false)
            {
                this.Close();
            }
        }
    }
}
