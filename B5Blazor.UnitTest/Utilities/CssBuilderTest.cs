using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using B5Blazor.Utilities;

namespace B5Blazor.UnitTest.Utilities
{
    public class CssBuilderTest:IDisposable
    {
        private readonly CssBuilder _builder;
        public CssBuilderTest() 
        {
            _builder = CssBuilder.Default();
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

        [Fact]
        public void Create_Null_Test()
        {
            var builder = new CssBuilder(null);

            var cssText = builder.Build();

            Assert.Empty(cssText);
        }

        [Fact]
        public void Create_Test()
        {
            var builder = new CssBuilder("container");

            var cssText = builder.Build();

            Assert.Equal("container", cssText);
        }

        [Fact]
        public void GetDefault_Test()
        {
            var builder = CssBuilder.Default();

            var cssText = builder.Build();

            Assert.Empty(cssText);
        }

        [Fact]
        public void GetEmpty_Test()
        {
            var builder = CssBuilder.Empty();

            var cssText = builder.Build();

            Assert.Empty(cssText);
        }

        [Theory]
        [InlineData("", null)]
        public void AddClass_Test(string? value, Func<bool> when)
        {
            _builder.AddClass(value, when);

            var cssText = _builder.Build();

            Assert.Equal(value, cssText);
        }

        [Fact]
        public void AddClassFromAttributes_Null_Test()
        {
            _builder.AddValue(null);

            var cssText = _builder.Build();

            //断言
            Assert.Empty(cssText);
        }

        [Fact]
        public void AddClassFromAttributes_Excluding_Test()
        {
            IReadOnlyDictionary<string, object> additional = new Dictionary<string, object>
            {
                {"css","" },
                {"js","js/index.js" },
                {"language","zh-CN" },
            }; 

            _builder.AddClassFromAttributes(additional);
            var cssText = _builder.Build();

            //断言
            Assert.Empty(cssText);
        }

        [Fact]
        public void AddClassFromAttributes_Included_Null_Test()
        {
            IReadOnlyDictionary<string, object> additional = new Dictionary<string, object>
            {
                {"class",null},
                {"js","js/index.js" },
                {"language","zh-CN" },
            };

            _builder.AddClassFromAttributes(additional);
            var cssText = _builder.Build();

            //断言
            Assert.Empty(cssText);
        }

        [Fact]
        public void AddClassFromAttributes_Included_Test()
        {
            IReadOnlyDictionary<string, object> additional = new Dictionary<string, object>
            {
                {"class","container"},
                {"js","js/index.js" },
                {"language","zh-CN" },
            };

            _builder.AddClassFromAttributes(additional);
            var cssText = _builder.Build();

            //断言
            Assert.Equal("container",cssText);
        }

        
        [Fact]
        public void Build_Test()
        {
            _builder.SetPrefix("b5b_");
            _builder.AddClass("container");
            _builder.AddClass("card");
            var cssText = _builder.Build();

            Assert.Equal("b5b_container b5b_card", cssText);
        }

        [Fact]
        public void Tostring_Test()
        {
            _builder.SetPrefix("b5b_");
            _builder.AddClass("container");
            _builder.AddClass("card");
 
            Assert.Equal(_builder.Build(),_builder.ToString());
        }

        public void Dispose()
        {
            
        }
    }
}
