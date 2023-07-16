using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B5Blazor.Utilities
{
    /// <summary>
    /// Css 构建者
    /// </summary>
    public class CssBuilder
    {
        private string prefix = string.Empty;
        private StringBuilder stringBuffer = new StringBuilder(100);

        public static CssBuilder Default(string? value = null)
        {
            return new CssBuilder(value);
        }

        public static CssBuilder Empty()
        {
            return new CssBuilder(string.Empty);
        }

        public CssBuilder(string? value = null)
        :this(value,"")
        {
        }

        public CssBuilder(string? value, string? prefix = "")
        {
            this.prefix = prefix ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(value))
            { 
                stringBuffer.Append(" " + prefix + value);
            }
        }

        public CssBuilder SetPrefix(string? value)
        {
            prefix = value ?? "";
            return this;
        }

        public CssBuilder AddValue(string? value)
        {
            stringBuffer.Append(value);
            return this;
        }

        public CssBuilder AddClass(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return this;
            }
            return AddValue(" " + prefix + value);
        }


        public CssBuilder AddClass(string? value, bool when = true)
        {
            if (!when)
            {
                return this;
            }

            return AddClass(value);
        }

        public CssBuilder AddClass(string? value, Func<bool> when)
        {
            if (when == null)
            {
                return this;
            }
            return AddClass(value, when());
        }

        public CssBuilder AddClass(Func<string?> value, bool when = true)
        {
            if (!when)
            {
                return this;
            }

            return AddClass(value());
        }

        public CssBuilder AddClass(Func<string?> value, Func<bool> when)
        {
            if (when == null)
            {
                return this;
            }
            return AddClass(value(), when());
        }

        public CssBuilder AddClass(CssBuilder builder, bool when = true)
        {
            if (!when)
            {
                return this;
            }

            return AddClass(builder.Build());
        }

        public CssBuilder AddClass(CssBuilder builder, Func<bool> when)
        {
            if (when == null)
            {
                return this;
            }
            return AddClass(builder, when());
        }

        public CssBuilder AddClassFromAttributes(IReadOnlyDictionary<string, object>? additionalAttributes)
        {
            if (additionalAttributes != null)
            {
                if (!additionalAttributes.TryGetValue("class", out var value))
                {
                    return this;
                }

                return AddClass(value?.ToString());
            }

            return this;
        }

        public CssBuilder AddClassFromAttributes(IDictionary<string, object>? additionalAttributes)
        {
            if (additionalAttributes != null && additionalAttributes.TryGetValue("class", out var c))
            {
                var classList = c?.ToString();
                AddClass(classList);
            }
            return this;
        }
        public CssBuilder AddStyleFromAttributes(IDictionary<string, object>? additionalAttributes)
        {
            if (additionalAttributes != null && additionalAttributes.TryGetValue("style", out var c))
            {
                var styleList = c?.ToString();
                AddClass(styleList);
            }
            return this;
        }
        public string Build()
        {
            return stringBuffer.ToString().Trim();
        }
        public override string ToString()
        {
            return Build();
        }
    }
}
