﻿using System;
using Volo.Abp.Domain.Entities;

namespace CtrlCloud.Framework.Domain.Models.CtrlCloud.Logs
{
    /// <summary>
    ///     Sys_LoginLog类
    /// </summary>
    public class SystemLoginLog:Entity<Guid>
    {
        /// <summary>
        ///     Ip对应地址
        /// </summary>
        public string IpAddressName { get; set; }
        /// <summary>
        ///     服务器主机名
        /// </summary>
        public string ServerHost { get; set; }
        /// <summary>
        ///     客户端主机名
        /// </summary>
        public string ClientHost { get; set; }
        /// <summary>
        ///     浏览器信息
        /// </summary>
        public string UserAgent { get; set; }
        /// <summary>
        ///     操作系统
        /// </summary>
        public string OsVersion { get; set; }
        /// <summary>
        ///     登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        ///     创建人员
        /// </summary>
        public string CreateUserId { get; set; }
        /// <summary>
        ///     创建人员登录代码
        /// </summary>
        public string CreateUserCode { get; set; }
        /// <summary>
        ///     创建人员名字
        /// </summary>
        public string CreateUserName { get; set; }
        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
