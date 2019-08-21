using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxAppHelper.Helper
{
   public static class  MqttNetInitializeData
    {
        public static string SUBSCRIBE = "TheMostSuperior";
        public static List<string> SUBSCRIBENO = new List<string>();
        public static string ClientId = "client002";
        public static string TcpServer = "192.168.137.1";
        public static int TcpPort = 8222;
        public static string UserName = "username002";
        public static string Pwd = "psw002";
    }
}
