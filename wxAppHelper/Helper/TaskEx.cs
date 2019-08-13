using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxAppHelper.Helper
{
    public static class TaskEx
    {
        public static Task Delay(int dueTime)
        {
            return Task.Delay(dueTime);
        }
    }
}
