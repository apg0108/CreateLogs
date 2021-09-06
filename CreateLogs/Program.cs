using System;
using System.IO;
using System.Threading;

namespace CreateLogs
{
    public class Log
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string pathLogs = "D:/Logs/log.json";
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int timeToSleep = 5000;
            string[] typeMessage = { "Info", "Warning", "Error" };
            Random random = new Random();
            Log log = new Log();
            string texto = String.Empty;
            int i = 1;
            while (true)
            {
                log.Message = String.Empty;
                log.Id = i;
                log.Type = typeMessage[random.Next(typeMessage.Length)];
                for (int j = 0; j < 8; j++)
                    log.Message += characters[random.Next(characters.Length)];
                if (File.ReadAllText(pathLogs).Trim().Length == 0 || File.ReadAllText(pathLogs).Trim() == "\n")
                    texto += "{id:" + log.Id + ",type:" + log.Type + ",message:" + log.Message + "}\n";
                else texto += ",{id:" + log.Id + ",type:" + log.Type + ",message:" + log.Message + "}\n";
                File.WriteAllText(pathLogs, texto);
                i++;
                Thread.Sleep(timeToSleep);
            }
        }
    }
}
