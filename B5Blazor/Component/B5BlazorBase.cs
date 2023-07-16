using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B5Blazor.Interfaces;
using Microsoft.AspNetCore.Components;

namespace B5Blazor.Component
{
    public class B5BlazorBase : ComponentBase, IB5BlazorBase
    {
        /// <summary>
        /// 用户自定义属性
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object>? AdditionalAttributes { get; set; }
    }
}
