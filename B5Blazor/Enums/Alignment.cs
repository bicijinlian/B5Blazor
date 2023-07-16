using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B5Blazor.Enums
{
    /// <summary>
    /// 对齐方式 枚举
    /// </summary>
    public enum Alignment
    {
        /// <summary>
        /// 未设置
        /// </summary>
        None,

        /// <summary>
        /// 左对齐
        /// </summary>
        [Description("start")]
        Left,

        /// <summary>
        /// 居中对齐
        /// </summary>
        [Description("center")]
        Center,

        /// <summary>
        /// 右对齐
        /// </summary>
        [Description("end")]
        Right
    }
}
