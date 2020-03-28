using System;
using Volo.Abp.Application.Dtos;

namespace Ctrl.Domain.Models.Dtos.Permission
{
    public class SystemMenuDto :  IEntityDto<Guid>
    {
       //public string ParentName { get; set; }
        public Guid Id { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public Guid MenuId { get; set; }

        /// <summary>
        /// ����id
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public byte[] OpenType { get; set; }
        /// <summary>
        ///     ��ť
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        ///  ����
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        ///  ������
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        ///  ����
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// �򿪵�ַ
        /// </summary>
        public string OpenUrl { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///  ����
        /// </summary>
        public int OrderNo { get; set; }

        /// <summary>
        /// ����ɾ��
        /// </summary>
        public bool CanbeDelete { get; set; }
        /// <summary>
        ///  ����
        /// </summary>
        public bool IsFreeze { get; set; }

        /// <summary>
        ///  ��ʾ
        /// </summary>
        public bool IsShowMenu { get; set; }

    }
}