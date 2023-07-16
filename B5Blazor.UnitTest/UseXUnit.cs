using B5Blazor.Utilities;

namespace B5Blazor.UnitTest
{
    public class UseXUnit:IDisposable
    {
        private readonly ITestOutputHelper output;
        public UseXUnit(ITestOutputHelper outputHelper)
        {
            this.output = outputHelper;
        }

        [Fact]
        public void Test()
        {
            output.WriteLine("使用 xUnit测试框架！");
            Assert.True(true,"使用 xunit");
        }

        public void Dispose()
        {

        }
    }
}