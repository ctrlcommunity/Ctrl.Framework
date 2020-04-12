using System;
using Ctrl.Core.Core.Log;
using Ctrl.Core.Core.Utils;
using Ctrl.Core.Core.Web;

namespace CtrlCloud.Framework.Core.Logs
{
    /// <summary>
    ///     构造函数
    /// </summary>
    public class LoginLogHandler:BaseHandler<LoginLog>
    {
        public LoginLogHandler(string userId,string code,string userName,int loginStatus):base("LoginLogToDatabase") {
            log = 
            new LoginLog
            {
                Id = CombUtil.NewComb(),
                CreateUserId = userId,
                CreateUserCode = code ?? "",
                ServerHost = $"{IpBrowserUtil.GetServerHost()}【{IpBrowserUtil.GetServerHostIp()}】",
                ClientHost = $"{IpBrowserUtil.GetClientIp()}",
                UserAgent = IpBrowserUtil.GetBrowser(),
                OsVersion = IpBrowserUtil.GetOsVersion(),
                LoginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                IpAddressName = IpBrowserUtil.GetAddressByApi(),
                CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                CreateUserName = userName,
                LoginStatus=loginStatus

            };
        }
    }
}
