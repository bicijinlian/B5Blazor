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
            var cssClassString = CssBuilder
                .Default()
                .AddValue(null)
                .Build();

            //断言
            Assert.Empty(cssClassString);
        }

        [Fact]
        public void Create_Null_Test()
        {
            var cssClassString = new CssBuilder(null)
                .Build();

            Assert.Empty(cssClassString);
        }

        [Fact]
        public void Create_Test()
        {
            var cssClassString = new CssBuilder("container")
                .Build();

            Assert.Equal("container", cssClassString);
        }

        [Fact]
        public void GetDefault_Test()
        {
            var cssClassString =  CssBuilder
                .Default()
                .Build();

            Assert.Empty(cssClassString);
        }

        [Fact]
        public void GetEmpty_Test()
        {
            var cssClassString = CssBuilder.Empty()
                .Build();

            Assert.Empty(cssClassString);
        }

        [Theory]
        [InlineData("", null)]
        public void AddClass_Test(string? value, Func<bool> when)
        {
            var cssClassString = _builder
                .AddClass(value, when)
                .Build();

            Assert.Equal(value, cssClassString);
        }

        [Fact]
        public void AddClassFromAttributes_Null_Test()
        {
            var cssClassString = _builder
                .AddValue(null)
                .Build();

            //断言
            Assert.Empty(cssClassString);
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

            var cssClassString = _builder
                .AddClassFromAttributes(additional)
                .Build();

            Assert.Empty(cssClassString);
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
            var cssClassString = _builder.Build();

            Assert.Empty(cssClassString);
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

            var cssClassString = _builder
                .AddClassFromAttributes(additional)
                .Build();

            Assert.Equal("container",cssClassString);
        }

        
        [Fact]
        public void Build_Test()
        {
            var cssClassString =  _builder
                .SetPrefix("b5b_")
                .AddClass("container")
                .AddClass("card")
                .Build();

            Assert.Equal("b5b_container b5b_card", cssClassString);
        }

        [Fact]
        public void Tostring_Test()
        {
            _builder
                .SetPrefix("b5b_")
                .AddClass("container")
                .AddClass("card");
 
            Assert.Equal(_builder.Build(),_builder.ToString());
        }

        public void Dispose()
        {
            
        }
    }
}
