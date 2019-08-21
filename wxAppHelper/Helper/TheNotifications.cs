using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxAppHelper.Helper
{
   public class TheNotifications
    {
        public int SourceId { get; set; }
        //目标联系人id
        public int TargetId { get; set; }
        //内容
        public string Content { get; set; }
        //聊天记录时间
        public DateTime RecordDateTime { get; set; }
    }
}
