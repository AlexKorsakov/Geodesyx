using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Geodesyx.Connected_Services
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IOracleWcfService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IOracleWcfService
    {
        [OperationContract]
        void DoWork();
    }
}
