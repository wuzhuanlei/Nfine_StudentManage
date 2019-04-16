using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.Enums
{
    public enum StudentStatus
    {
        /// <summary>
        /// 新建
        /// </summary>
        [Description("新建")]
        NewCreate = 1,
        /// <summary>
        /// 已入住
        /// </summary>
        [Description("已入住")]
        CheckedIn = 2,
        /// <summary>
        /// 已退宿。
        /// </summary>
        [Description("已退宿")]
        Refunded = 3,
        /// <summary>
        /// 作废
        /// </summary>
        [Description("作废")]
        Abandon = 4
    }
}
