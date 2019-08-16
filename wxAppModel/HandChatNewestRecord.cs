using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxAppModel
{
   public class HandChatNewestRecord
    {
        //主键
        public int Id { get; set; }
        //联系人Id
        public int ContactId { get; set; }

        public string ContactName { get; set; }
        //联系人Image地址
        public string ContactImage { get; set; }
        
        //内容
        public string Content { get; set; }
        //聊天记录时间
        public DateTime RecordDateTime { get; set; }
    }
}
