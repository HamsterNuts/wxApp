using MahApps.Metro.Controls.Dialogs;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxAppHelper.Helper
{
   public static class ShowDialog
    {
        public static async Task<MessageDialogResult> ShowMessageButtonDialog(BindableBase thisContent,IDialogCoordinator dialogCoordinator, string header, string message)
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "确定",
                NegativeButtonText = "取消",
                ColorScheme = MetroDialogColorScheme.Accented
            };

            var result = await dialogCoordinator.ShowMessageAsync(thisContent, header, message, MessageDialogStyle.AffirmativeAndNegative, mySettings);
            return result;

        }
        /// <summary>
        /// 显示弹框
        /// </summary>
        public static async void ShowMessageDialog(BindableBase thisContent, IDialogCoordinator dialogCoordinator, string header, string message)
        {
            await dialogCoordinator.ShowMessageAsync(thisContent, header, message);
        }

        public static async void ShowRunProgress(BindableBase thisContent, IDialogCoordinator dialogCoordinator, string header, string message,int value)
        {
            var controller = await dialogCoordinator.ShowProgressAsync(thisContent, header, message);
            controller.SetIndeterminate();

            await TaskEx.Delay(value);

            await controller.CloseAsync();
        }
    }
}
