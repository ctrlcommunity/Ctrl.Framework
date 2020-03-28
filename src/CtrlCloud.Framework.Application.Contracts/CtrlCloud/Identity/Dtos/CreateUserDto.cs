using System;

namespace Ctrl.Domain.Models.Dtos.Identity
{
    /// <summary>
    ///     用户信息输入类
    /// </summary>
    public class CreateUserDto
    {
        /// <summary>
        ///     角色编码
        /// </summary>
        /// <value></value>
        public string RoleId { get; set; }
        /// <summary>
        ///     登录名
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///     真实姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///     密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        ///     电话
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        ///     头像路径
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        ///     邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        ///     第一次访问时间
        /// </summary>
        public DateTime? FirstVisitTime { get; set; }
        /// <summary>
        ///     最后一次访问时间
        /// </summary>
        public DateTime? LastVisitTime { get; set; }
        /// <summary>
        ///     备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        ///     是否是管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        ///     冻结
        /// </summary>
        public bool? IsFreeze { get; set; }

    }
}