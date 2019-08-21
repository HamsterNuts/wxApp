using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxAppHelper.UsingEventAggregator
{
    public class MessageSentEvent : PubSubEvent<string>
    {
    }

    public class SearcchSentEvent : PubSubEvent<string>
    {
    }
    public class DetailsSentEvent : PubSubEvent<string>
    {
    }

    public class TheContactDetailsSentEvent : PubSubEvent<int?>
    {
    }

    public class TheContactChatRecordSentEvent : PubSubEvent<int?>
    {

    }

    public class TheTheNotificationsSentEvent : PubSubEvent<string>
    {

    }
}
