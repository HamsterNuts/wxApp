using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxAppModel
{
    /// <summary>
    /// 联系人表
    /// </summary>

    public class HandContact
    {
        //id
        public int Id { get; set; }
        //名称
        public string Name { get; set; }
        //头像路径
        public string Image { get; set; }
        //性别
        public int Sex { get; set; }
        //个性签名
        public string Signature { get; set; }
        //备注
        public string  Note { get; set; }
        //微信号
        public string WxNumber { get; set; }
        //来源
        public string Source { get; set; }
        //地址
        public string Address { get; set; }

    }
}
