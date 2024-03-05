using AoE4GameBox.Common;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AoE4GameBox.Tools
{
    internal class NetCheck
    {
        /// <summary>
        /// 测试ping结果
        /// </summary>
        /// <param name="host">远程地址</param>
        /// <returns>PingResult类</returns>
        internal static async Task<PingResult> CheckPing(string host)
        {
            try
            {
                var ping = new Ping();
                PingReply reply = await ping.SendPingAsync(host);
                return new PingResult
                {
                    PingSuccess = reply.Status == IPStatus.Success,
                    RoundtripTime = reply.RoundtripTime
                };
            } catch (PingException)
            {
                return new PingResult { PingSuccess = false };
            }
        }

        /// <summary>
        /// 检测远程地址是否可达
        /// </summary>
        /// <param name="host">远程地址</param>
        /// <returns>string</returns>
        internal static async Task<string> CheckHostReachable(string host)
        {
            PingResult pingResult = await CheckPing(host);
            if (pingResult.PingSuccess)
            {
                var msg = string.Format("Properties.i18n.Resources.host_reachable", host, pingResult.RoundtripTime);
                Logger.Log(msg);
                return msg;
            } else
            {
                var msg = string.Format("Properties.i18n.Resources.host_not_reachable", host);
                Logger.Log(msg);
                return msg;
            }
        }

        /// <summary>
        /// 检测本地网络接口
        /// </summary>
        /// <returns>string</returns>
        internal static string CheckLocalNic()
        {
            var msg = new StringBuilder();
            msg.AppendLine("Properties.i18n.Resources.msg_local_nic" + "\n");

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface nic in interfaces)
            {
                msg.AppendLine($"Interface Name: {nic.Name}");
                msg.AppendLine($"   Description: {nic.Description}");
                msg.AppendLine($"   Status: {nic.OperationalStatus}");
                msg.AppendLine($"   Speed: {nic.Speed} bps");

                IPInterfaceProperties ipProps = nic.GetIPProperties();
                foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
                {
                    msg.AppendLine($"   IP Address: {ip.Address}");
                    msg.AppendLine($"   Subnet Mask: {ip.IPv4Mask}");
                }
            }
            return msg.ToString();
        }

        internal static async Task<string> GetIPAddress()
        {
            try
            {
                // 获取本机的主机名
                string hostName = Dns.GetHostName();
                string msg = $"Host Name: {hostName}\n";

                // 获取本机的IP地址列表
                IPAddress[] localIPs = Dns.GetHostAddresses(hostName);
                msg += "Local IP Addresses:\n";
                foreach (IPAddress ip in localIPs)
                {
                    msg += ip.ToString() + "\n";
                }

                // 使用 HttpClient 获取公网IP地址
                using var client = new HttpClient();
                string publicIPAddress = await client.GetStringAsync("http://ipinfo.io/ip");
                //msg += "Public IP Address: " + publicIPAddress.Trim();
                msg += "公网IP地址: " + publicIPAddress.Trim();
                client.Dispose();

                return msg;
            } catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
            }
        }

        /// <summary>
        /// 清理DNS缓存
        /// </summary>
        /// <returns>string 执行结果</returns>
        internal static string FlushDNSCache()
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C ipconfig /flushdns", // 执行ipconfig /flushdns命令
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd(); // 获取命令输出
            string error = process.StandardError.ReadToEnd();   // 获取错误信息
            process.WaitForExit();
            process.Dispose();

            // 将输出和错误信息显示在 TextBox 中
            var msg = new StringBuilder();
            //msg.AppendLine("Command Output:");
            msg.Append(output);
            //msg.AppendLine("Error:");
            msg.AppendLine(error);

            return msg.ToString();
        }
    }
}
