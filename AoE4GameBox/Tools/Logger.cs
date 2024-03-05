using System;
using System.Diagnostics;
using System.IO;
using Windows.Storage;

namespace AoE4GameBox.Tools
{
    /// <summary>
    /// 自定义日志记录器
    /// </summary>
    public class Logger
    {

        private static readonly string logsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AoE4GameBoxLogs");
        //private static readonly string logsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "logs");
        //private static readonly string logsDirectory = Path.Combine(ApplicationData.Current.LocalFolder.Path, "AoE4GameBoxLogs");
        private static readonly int processId = Environment.ProcessId;

        private static void AppendLog(string message)
        {
            // 记录信息到输出窗口
            Debug.WriteLine(message);

            // 打印日志存放地址
            Debug.WriteLine($"Logs directory: {logsDirectory}");

            // 如果logs文件夹不存在，则创建它
            if (!Directory.Exists(logsDirectory))
            {
                Directory.CreateDirectory(logsDirectory);
            }

            // 构造文件路径，使用日期作为文件名
            string logFileName = $"{DateTime.Now:yyyy-MM-dd}.log";
            string logFilePath = Path.Combine(logsDirectory, logFileName);

            // 将日志信息追加到文件中
            File.AppendAllText(logFilePath, $"{message}\n");
        }

        public static void Log()
        {
            Log("无参Log");
        }

        public static void Log<T>(string key, T message)
        {
            string logMsg = $"[{DateTime.Now}] [{key}] [thread: {processId}] {message}";
            AppendLog(logMsg);
        }

        public static void Log<T>(T message)
        {
            Log("default", message);
        }

        public static void Info<T>(T message)
        {
            string logMsg = $"[{DateTime.Now}] [info] [thread: {processId}] {message}";
            AppendLog(logMsg);
        }

        public static void Info<T>(string key, T message)
        {
            Info($"==>> {key}");
            Info(message);
        }

        public static void Warning<T>(T message)
        {
            string logMsg = $"[{DateTime.Now}] [warning] [thread: {processId}] {message}";
            AppendLog(logMsg);
        }

        public static void Warning<T>(string key, T message)
        {
            Warning($"==>> {key}");
            Warning(message);
        }

        public static void Error<T>(T message)
        {
            string logMsg = $"[{DateTime.Now}] [error] [thread: {processId}] {message}";
            AppendLog(logMsg);
        }

        public static void Error<T>(string key, T message)
        {
            Error($"==>> {key}");
            Error(message);
        }
    }
}
