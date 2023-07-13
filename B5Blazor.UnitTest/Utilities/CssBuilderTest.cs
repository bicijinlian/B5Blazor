using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using B5Blazor.Utilities;

namespace B5Blazor.UnitTest.Utilities
{
    public class CssBuilderTest
    {
        [Fact]
        public void Con_Test1()
        {
            var builder = new CssBuilder(null);

            var cssText = builder.Build();
        }

        [Fact]
        public void AddClass_Test()
        {
            var builder = CssBuilder.Default();
            CssBuilder.Default().AddClass("demo", null);
        }

        [Fact]
        public void Temp_Test()
        {
            var builder = CssBuilder.Default();

            builder.AddValue(null);

            var cssText = builder.Build();

            //断言
            Assert.Empty(cssText);
        }
    }
}
