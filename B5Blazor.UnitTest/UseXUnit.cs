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
            output.WriteLine("ʹ�� xUnit���Կ�ܣ�");
            Assert.True(true,"ʹ�� xunit");
        }

        public void Dispose()
        {

        }
    }
}