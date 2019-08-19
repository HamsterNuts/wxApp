using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wxAppHelper.ViewModel;

namespace wxAppHelper.Helper
{
   public static class InitializeData
    {
        public static int TheCurrentUserId = 1;
        public static List<HandContactViewModel> HandContactData;

        public static List<HandChatRecordViewModel> HandChatRecordData;
        public static List<HandContactViewModel> HandContactInitializeData()
        {
           var HandContactData = new List<HandContactViewModel>();
            var handContact0 = new HandContactViewModel()
            {
                IdProperty = 1,
                NameProperty = "阿芷",
                ImageProperty = "/Images/head7.jpg",
                SexProperty = 1,
                SignatureProperty = "一场好大的雨",
                NoteProperty = "朋友",
                WxNumberProperty = "wxid_l7csinw4yqjn21",
                SourceProperty = "通过群聊添加",
                AddressProperty = "江苏 南通"
            };
            var handContact1 = new HandContactViewModel()
            {
                IdProperty = 2,
                NameProperty = "张三",
                ImageProperty = "/Images/head3.jpg",
                SexProperty = 1,
                SignatureProperty = "昨天又挂大风了",
                NoteProperty = "亲人",
                WxNumberProperty = "wxid_l123w4yqjn21",
                SourceProperty = "通过群聊添加",
                AddressProperty = "上海 青浦"
            };
            var handContact2 = new HandContactViewModel()
            {
                IdProperty = 3,
                NameProperty = "张四",
                ImageProperty = "/Images/head4.jpg",
                SexProperty = 1,
                SignatureProperty = "昨天又挂大风了",
                NoteProperty = "亲人",
                WxNumberProperty = "wxid_l123w4yqjn21",
                SourceProperty = "通过群聊添加",
                AddressProperty = "上海 青浦"
            };
            HandContactData.Add(handContact0);
            HandContactData.Add(handContact1);
            HandContactData.Add(handContact2);
            return HandContactData;
        }

        public static List<HandChatRecordViewModel> HandChatRecordInitializeData()
        {
            var HandChatRecordData = new List<HandChatRecordViewModel>();
            var handChatRecord0 = new HandChatRecordViewModel()
            {
                IdProperty = 1,
                SourceIdProperty = 1,
                TargetIdProperty = 2,
                ContentProperty = "你好啊",
                RecordDateTime = DateTime.Now
            };
            var handChatRecord1 = new HandChatRecordViewModel()
            {
                IdProperty = 2,
                SourceIdProperty = 2,
                TargetIdProperty = 1,
                ContentProperty = "我很好",
                RecordDateTime = DateTime.Now
            };
            var handChatRecord2 = new HandChatRecordViewModel()
            {
                IdProperty = 1,
                SourceIdProperty = 1,
                TargetIdProperty = 3,
                ContentProperty = "你好啊",
                RecordDateTime = DateTime.Now
            };
            HandChatRecordData.Add(handChatRecord0);
            HandChatRecordData.Add(handChatRecord1);
            HandChatRecordData.Add(handChatRecord2);
            return HandChatRecordData;
        }

        public static void Initialize()
        {
            HandContactData = HandContactInitializeData();
            HandChatRecordData = HandChatRecordInitializeData();
        }
    }
}
