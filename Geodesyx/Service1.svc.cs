using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Geodesyx
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.

    /// <summary>
    /// Сервис взаимодействия с БД
    /// </summary>
    public class Service1 : IService1
    {

        private static string CONNECTION_STRING = "User Id=is_user;Password=is_user;Data Source=(DESCRIPTION=" +
            "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
            "(CONNECT_DATA=(SID=XE)));";

        public string DoWork()
        {
            string fullName = "";
            using (OracleConnection connection = new OracleConnection(CONNECTION_STRING))
            {
                DataSet ds = new DataSet();
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.service ", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                {
                    while (oraReader.Read())
                    {
                        fullName += oraReader.GetValue(0);
                        fullName += oraReader.GetValue(1);
                        fullName += oraReader.GetValue(2);
                        fullName += oraReader.GetValue(3);
                    }
                }
                else
                {
                    fullName = "No Rows Found";
                }
            }
            return fullName;
        }

        public string GetHello()
        {
            DoWork();
            return "Go to hell";
        }
        public int GetSummm(int a, int b)
        {
            return a + b;
        }
    }
}
