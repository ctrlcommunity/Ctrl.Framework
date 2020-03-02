using Ctrl.Core.PetaPoco;
using System;
using Volo.Abp.Domain.Entities;

namespace Ctrl.Domain.Models.Entities
{
    /// <summary>
    ///     Sys_User类
    /// </summary>
    [TableName("Sys_User")]
    [PrimaryKey("UserId")]
    public class SystemUser: Entity<Guid>
    {
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


        public SystemUser() { }
        public SystemUser(Guid id,string code, string name, string password, string mobile, string email, DateTime? firstVisitTime, DateTime? lastVisitTime, string remark, bool isAdmin, DateTime? createTime, bool? isFreeze, string imgUrl)
        {
            Id = id;
            Code = code;
            Name = name;
            Password = password;
            Mobile = mobile;
            Email = email;
            FirstVisitTime = firstVisitTime;
            LastVisitTime = lastVisitTime;
            Remark = remark;
            IsAdmin = isAdmin;
            CreateTime = createTime;
            IsFreeze = isFreeze;
            ImgUrl = imgUrl;
        }
    }
}
