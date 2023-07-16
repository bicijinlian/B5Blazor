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
        private readonly ITestOutputHelper _output;
        private readonly CssBuilder _builder;
        public CssBuilderTest(ITestOutputHelper output)
        {
            _builder = new CssBuilder();
            _output = output;
        }

        [Fact]
        public void New_Value_Test()
        {
            var cssClassString = new CssBuilder().Build();
            Assert.Empty(cssClassString);

            cssClassString = new CssBuilder(null).Build();
            Assert.Empty(cssClassString);

            cssClassString = new CssBuilder("container").Build();
            Assert.Equal("container", cssClassString);
        }

        [Theory]
        [InlineData(null,null)]
        [InlineData(null,"")]
        [InlineData(null,"bs_")]
        [InlineData("",null)]
        [InlineData("","")]
        [InlineData("","bs_")]
        [InlineData("container", null)]
        [InlineData("container", "")]
        [InlineData("container", "bs_")]
        public void New_ValueAndPrefix_Test(string? value, string? prefix)
        {
            string prefixString = string.IsNullOrEmpty(value) ? "" : " " + prefix;
            string expectedClassString = prefixString.Trim() + value;

            string actualClassString = new CssBuilder(value, prefix).Build();
            Assert.Equal(expectedClassString, actualClassString);
        }

        [Fact]
        public void New_ValueAndPrefix_Simple_Test()
        {
            var cssClassString = new CssBuilder(null, null).Build();
            Assert.Empty(cssClassString);

            cssClassString = new CssBuilder(null, "").Build();
            Assert.Empty(cssClassString);

            cssClassString = new CssBuilder(null, "bs_").Build();
            Assert.Empty(cssClassString);

            cssClassString = new CssBuilder("", null).Build();
            Assert.Empty(cssClassString);

            cssClassString = new CssBuilder("", "").Build();
            Assert.Empty(cssClassString);

            cssClassString = new CssBuilder("", "bs_").Build();
            Assert.Empty(cssClassString);

            cssClassString = new CssBuilder("container", null).Build();
            Assert.Equal("container", cssClassString);

            cssClassString = new CssBuilder("container", "").Build();
            Assert.Equal("container", cssClassString);

            cssClassString = new CssBuilder("container", "bs_").Build();
            Assert.Equal(expected: "bs_container", actual: cssClassString);
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

        [Fact]
        public void AddClass_Value_Test()
        {
            var cssClassString = "";
            
            cssClassString = CssBuilder.Default().AddClass(null).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass("demo").Build();
            Assert.Equal("demo", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix("").AddClass("demo").Build();
            Assert.Equal("demo", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix("bs_").AddClass("demo").Build();
            Assert.Equal("bs_demo", cssClassString);
        }

        [Fact]
        public void AddClass_ValueAndWhen_Test()
        {
            var cssClassString = "";

            cssClassString = CssBuilder.Default().AddClass("", false).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass("",true).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass("demo",false).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass("demo", true).Build();
            Assert.Equal("demo", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix(null).AddClass("demo", false).Build();
            Assert.Equal("", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix(null).AddClass("demo", true).Build();
            Assert.Equal("demo", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix("bs_").AddClass("demo",false).Build();
            Assert.Equal("", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix("bs_").AddClass("demo",true).Build();
            Assert.Equal("bs_demo", cssClassString);
        }

        [Fact]
        public void AddClass_FuncValueAndWhen_Test()
        {
            var cssClassString = "";

            cssClassString = CssBuilder.Default().AddClass(() => "", false).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass(() => "", true).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass(() => "demo", false).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass(() => "demo", true).Build();
            Assert.Equal("demo", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix(null).AddClass(() => "demo", false).Build();
            Assert.Equal("", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix(null).AddClass(() => "demo", true).Build();
            Assert.Equal("demo", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix("bs_").AddClass(() => "demo", false).Build();
            Assert.Equal("", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix("bs_").AddClass(() => "demo", true).Build();
            Assert.Equal("bs_demo", cssClassString);
        }

        [Fact]
        public void AddClass_FuncValueAndFuncWhen_Test()
        {
            var cssClassString = "";

            cssClassString = CssBuilder.Default().AddClass(() => "", () => false).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass(() => "", () => true).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass(() => "demo", () => false).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass(() => "demo", () => true).Build();
            Assert.Equal("demo", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix(null).AddClass(() => "demo", () => false).Build();
            Assert.Equal("", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix(null).AddClass(() => "demo", () => true).Build();
            Assert.Equal("demo", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix("bs_").AddClass(() => "demo", () => false).Build();
            Assert.Equal("", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix("bs_").AddClass(() => "demo", () => true).Build();
            Assert.Equal("bs_demo", cssClassString);
        }

        [Fact]
        public void AddClass_CssBuiller_When_Test()
        {
            var cssClassString = "";

            cssClassString = CssBuilder.Default().AddClass(new CssBuilder(), false).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass(new CssBuilder(), true).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass(new CssBuilder("demo"), false).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass(new CssBuilder("demo"), true).Build();
            Assert.Equal("demo", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix(null).AddClass(new CssBuilder("demo"), false).Build();
            Assert.Equal("", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix(null).AddClass(new CssBuilder("demo"), true).Build();
            Assert.Equal("demo", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix("bs_").AddClass(new CssBuilder("demo"), false).Build();
            Assert.Equal("", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix("bs_").AddClass(new CssBuilder("demo"), true).Build();
            Assert.Equal("bs_demo", cssClassString);
        }

        [Fact]
        public void AddClass_CssBuiller_FuncWhen_Test()
        {
            var cssClassString = "";

            cssClassString = CssBuilder.Default().AddClass(new CssBuilder(), () => false).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass(new CssBuilder(), () => true).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass(new CssBuilder("demo"), () => false).Build();
            Assert.Equal(string.Empty, cssClassString);

            cssClassString = CssBuilder.Default().AddClass(new CssBuilder("demo"), () => true).Build();
            Assert.Equal("demo", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix(null).AddClass(new CssBuilder("demo"), () => false).Build();
            Assert.Equal("", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix(null).AddClass(new CssBuilder("demo"), () => true).Build();
            Assert.Equal("demo", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix("bs_").AddClass(new CssBuilder("demo"), () => false).Build();
            Assert.Equal("", cssClassString);

            cssClassString = CssBuilder.Default().SetPrefix("bs_").AddClass(new CssBuilder("demo"), () => true).Build();
            Assert.Equal("bs_demo", cssClassString);
        }

        [Theory]
        [InlineData("", null)]
        public void AddClass_FuncWhen_Test(string? value, Func<bool> when)
        {
            var cssClassString = _builder
                .AddClass(value, when)
                .Build();

            Assert.Equal(value, cssClassString);
        }

        [Fact]
        public void AddClassFromAttributes_IReadOnlyDictionary_Test()
        {
            string cssClassString = "";
            IReadOnlyDictionary<string, object>? dic = null;

            cssClassString = CssBuilder.Default().AddClassFromAttributes(dic).Build();
            Assert.Empty(cssClassString);


            dic = new Dictionary<string, object>
            {
                {"css","" },
                {"js","js/index.js" },
                {"language","zh-CN" },
            };
            cssClassString = CssBuilder.Default().AddClassFromAttributes(dic).Build();
            Assert.Empty(cssClassString);


            dic = new Dictionary<string, object>
            {
                {"class","container"},
                {"js","js/index.js" },
                {"language","zh-CN" },
            };
            cssClassString = CssBuilder.Default().AddClassFromAttributes(dic).Build();
            Assert.Equal("container", cssClassString);

            dic = new Dictionary<string, object>
            {
                {"class","demo"},
            };
            cssClassString = CssBuilder.Default().AddClassFromAttributes(dic).Build();
            Assert.Equal("demo", cssClassString);

        }

        [Fact]
        public void AddClassFromAttributes_IDictionary_Test()
        {
            string cssClassString = "";
            IDictionary<string, object>? dic = null;

            cssClassString = CssBuilder.Empty().AddClassFromAttributes(dic).Build();
            Assert.Empty(cssClassString);

            dic = new Dictionary<string, object>
            {
                {"css","" },
                {"js","js/index.js" },
                {"language","zh-CN" },
            };
            cssClassString = CssBuilder.Empty().AddClassFromAttributes(dic).Build();
            Assert.Empty(cssClassString);


            dic = new Dictionary<string, object>
            {
                {"class","container"},
                {"js","js/index.js" },
                {"language","zh-CN" },
            };
            cssClassString = CssBuilder.Empty().AddClassFromAttributes(dic).Build();
            Assert.Equal("container",cssClassString);

        }

        [Fact]
        public void AddStyleFromAttributesAddStyleFromAttributes_Test()
        {
            string cssClassString = "";
            IDictionary<string, object>? dic = null;

            cssClassString = CssBuilder.Empty().AddStyleFromAttributes(dic).Build();
            Assert.Empty(cssClassString);

            dic = new Dictionary<string, object>
            {
                {"css","" },
                {"js","js/index.js" },
                {"language","zh-CN" },
            };
            cssClassString = CssBuilder.Empty().AddStyleFromAttributes(dic).Build();
            Assert.Empty(cssClassString);


            dic = new Dictionary<string, object>
            {
                {"style","container"},
            };
            cssClassString = CssBuilder.Empty().AddStyleFromAttributes(dic).Build();
            Assert.Equal("container", cssClassString);

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
