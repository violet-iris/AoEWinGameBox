using System;

namespace AoE4GameBox.Tools
{
    internal class SystemTool
    {
        //public static void GetOperatingSystem()
        //{
        //    var os = Environment.OSVersion;
        //    var platform = os.Platform;
        //    var version = os.Version;
        //    Logger.Log("OS Platform: " + platform.ToString());
        //    Logger.Log("OS Version: " + version.ToString());
        //}

        public static void LogOS()
        {
            var os = Environment.OSVersion;
            var platform = os.Platform;
            var version = os.Version;
            Logger.Log("OS Platform: " + platform.ToString());
            Logger.Log("OS Version: " + version.ToString());
        }
    }
}
