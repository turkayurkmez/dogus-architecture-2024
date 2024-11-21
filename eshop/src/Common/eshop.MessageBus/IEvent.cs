using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.MessageBus
{
    public interface IEvent
    {
        Guid Guid { get; set; }
        DateTime FireDate { get; set; }
    }
}
