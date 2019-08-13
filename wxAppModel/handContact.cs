using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxAppModel
{
    public class HandContact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public int Sex { get; set; }

        public string Signature { get; set; }

        public string  Note { get; set; }

        public string WxNumber { get; set; }

        public string Source { get; set; }

        public string Address { get; set; }

    }
}
