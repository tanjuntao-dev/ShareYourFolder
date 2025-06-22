using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ShareYourFolder
{
    public partial class FolderShare_Connect : Form
    {
        public FolderShare_Connect()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // 把上次保存的值读到界面
            Func1_HostName_Input.Text = Properties.Settings.Default.HostName;
            Func1_ShareName_Input.Text = Properties.Settings.Default.ShareName;
            Func1_UserName_Input.Text = Properties.Settings.Default.UserName;
            Func1_Password_Input.Text = Properties.Settings.Default.Password;
            panel2.BackColor = Color.FromArgb(31, 44, 60);
            panel1.BackColor = Color.FromArgb(227, 236, 247);
        }
        private void Func1_exc_Click(object sender, EventArgs e)
        {
            // 1. 读取用户输入
            string hostName = Func1_HostName_Input.Text.Trim();
            string shareName = Func1_ShareName_Input.Text.Trim();
            string userName = Func1_UserName_Input.Text.Trim();
            string password = Func1_Password_Input.Text;
            bool openRoot = false;

            Properties.Settings.Default.HostName = hostName;
            Properties.Settings.Default.ShareName = shareName;
            Properties.Settings.Default.UserName = userName;
            Properties.Settings.Default.Password = password;
            Properties.Settings.Default.Save();

            // 2. 解析主机名IPv4
            string ip = ResolveHostToIPv4(hostName);
            if (!string.IsNullOrEmpty(ip))
            {
                Func1_IP_Label.Text = $"IP: {ip}";
            }
            else
            {
                Func1_IP_Label.Text = "IP: 未探测到有效地址";
                MessageBox.Show($"无法解析或 Ping 不通：{hostName}",
                                "解析失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string unc = openRoot
                ? $@"\\{ip}"
                : $@"\\{ip}\{shareName}";



            // 3. 登录共享会话
            var login = new ProcessStartInfo("cmd.exe",
                $"/c net use \"{unc}\" \"{password}\" /user:{userName} /persistent:no")
            {
                UseShellExecute = true,
                CreateNoWindow = true
            };

            try
            {
                using var p = Process.Start(login);
                p.WaitForExit();

                if (p.ExitCode != 0 ||
                    (!openRoot && !Directory.Exists(unc)))
                {
                    MessageBox.Show($"登录失败或共享不存在：{unc}",
                                    "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"执行 net use 时出错：{ex.Message}",
                                "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 访问测试
            try
            {
                Directory.GetFiles(unc);
            }
            catch
            {
                MessageBox.Show($"已登录，但无法访问目录：{unc}",
                                "访问失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            // 4. 打开资源管理器
            var psi = new ProcessStartInfo("cmd.exe",
                $"/c start \"\" \"{unc}\"")  // 第一个空标题字符串防止路径被当参数
            {
                UseShellExecute = true,
                CreateNoWindow = true
            };

            try
            {
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"打开资源管理器失败：{ex.Message}",
                                "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("共享登录并访问成功！",
                            "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 辅助方法

        private string ResolveHostToIPv4(string host)
        {
            try
            {
                var entry = Dns.GetHostEntry(host);
                foreach (var addr in entry.AddressList
                                           .Where(a => a.AddressFamily == AddressFamily.InterNetwork))
                {
                    if (PingOnce(addr.ToString()))
                        return addr.ToString();
                }
            }
            catch
            {
                // 忽略解析内异常
            }
            return null;
        }

        private bool PingOnce(string ip)
        {
            try
            {
                using var p = new Ping();
                return p.Send(ip, 1000).Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string helpText =
@"系统文件夹共享与连接 工具使用说明：
1. 在上方四个输入框分别填写：
   • 主机名：如果无法确定共享文件所在主机的主机名，可询问管理员，或在已共享的电脑上打开“命令提示符”并输入：echo %COMPUTERNAME%。
   • 共享名：指的是共享文件夹的名称，可询问管理员。
   • 用户名：通常是电脑的登录用户名，可在设置的关于本机、锁屏界面和登录界面可以看到。
   • 密码：通常是电脑密码
2. 点击“运行”按钮，程序会自动映射并打开共享文件夹。
3. 下次启动会记住上次输入。";

            using var frm = new HelpForm("帮助", helpText);
            frm.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string aboutText =
@"ShareYourFolder WinForms 应用 v1.0
本工具旨在映射并快速打开网络共享文件夹，特别适用于以下局域网访问困难的典型场景：

IP地址频繁变动：由于路由器使用 DHCP 自动分配机制，网络重启或设备断线后可能分配到新的 IP，导致共享路径失效；

设备不在同一子网：连接到不同Wi-Fi路由器或子网，无法访问目标计算机；

计算机名无法解析：部分路由器出于安全策略禁用 mDNS、LLMNR 或 NetBIOS 广播，导致设备之间无法通过名称互相识别。

本软件通过自动解析主机名、记录和重用上次成功的共享路径，有效解决上述问题，让局域网共享更稳定、更方便。

    | 作者：Tan Junto

作者的话：
本工具是本地化的项目资源管理器（Project Resource Explorer）项目的起点，旨在为小团队或个人用户提供无需搭建服务器、即开即用的本地管理解决方案。

目前版本仅实现了基础功能——网络共享文件夹映射与打开功能，也是整个系统中的第一模块。

核心目的是解决设备IP频繁变动、主机名无法解析、子网不一致或Wi-Fi安全策略导致的连接失败等。

未来版本计划包括：
- 项目管理：支持项目目录注册、自动创建共享等；
- 时间轴与访问记录：记录何时由谁访问、修改或映射共享目录；
- 权限管理：设置不同用户或IP的访问权限（只读、可写、隐藏）；
- 同步与备份：允许设置自动同步策略，保障数据安全；
- 用户界面升级：计划采用 React 技术栈重构前端，以实现更加现代化、响应式的用户体验。

需要特别说明的是：本工具现在及未来均不会涉及文件的内容创建、编辑、保存等操作，以避免破坏原始文件结构，确保数据安全与可控性。

我将持续在本项目的 GitHub 页面上更新进度与发布新版本。

GitHub:
https://github.com/tanjuntao-dev/ShareYourFolder
"";

-----------------------------------------------------------------------------------------------------------

Features
This tool is designed to map and open network shared folders reliably, especially under common LAN issues such as:

Frequent IP changes: Routers using DHCP may assign a different IP address to devices upon reboot or disconnection, breaking saved share paths.

Subnet mismatch: Devices connected to different routers or Wi-Fi networks may fail to access each other.

Host name resolution failure: Some routers disable mDNS, LLMNR, or NetBIOS broadcasts for security reasons, preventing devices from resolving computer names within the network.

The tool addresses these issues by automatically resolving hostnames, reusing last-known working IPs, and enabling stable, user-friendly access to shared folders in a local network.

    | Author：Tan Junto

Author's Note:

This tool marks the starting point of the Local Project Resource Explorer initiative, designed to provide small teams and individual users with a lightweight, server-free, plug-and-play local resource management solution.

The current version implements only the foundational feature — mapping and opening network shared folders — as the first module in the overall system architecture.

Its primary goal is to address common LAN connectivity issues such as:frequent IP changes due to DHCP,hostname resolution failures,subnet mismatches,and blocked connections caused by Wi-Fi security policies (e.g., mDNS, NetBIOS restrictions).

Planned future features include:

- Project Management: Registering project directories and auto-creating share paths.

- Access Timeline & Logs: Recording who accessed, modified, or mapped shared folders and when.

- Permission Control: Defining access levels (read-only, writable, hidden) per user or IP.

- Synchronization & Backup: Allowing scheduled sync rules to ensure data redundancy and security.

- User Interface Upgrade: A planned migration to the React technology stack to deliver a more modern, responsive, and intuitive user experience.

Importantly, the tool — both now and in future versions — will not support file creation, editing, or saving, in order to preserve the integrity of original files and maintain full user control over data.

Development updates and new releases will continue to be published on this project's GitHub page.

GitHub:
https://github.com/tanjuntao-dev/ShareYourFolder";

            // 弹窗显示 About 信息
            using var frm = new HelpForm("关于", aboutText);
            frm.ShowDialog();
        }

        private void lblFutureFeature_Click(object sender, EventArgs e)
        {
        MessageBox.Show(
        "此功能正在研发中，敬请期待后续更新。",   // 更专业的表达
        "功能预告",                         // 标题
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
    );
        }
    }
}
