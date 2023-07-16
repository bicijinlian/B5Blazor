using System;

using Microsoft.Extensions.Logging;

using Xunit;
using Xunit.DependencyInjection;

using B5Blazor.Utilities;
using B5Blazor.UnitTest.Study;

namespace B5Blazor.UnitTest
{
    /// <summary>
    /// xUnit��ʹ������ע���ܣ�Xunit.DependencyInjection
    /// </summary>
    public class UseXUnitWithDI : IDisposable
    {
        //ʹ�� ITestOutputHelperAccessor ע�� ITestOutputHelper
        private readonly ITestOutputHelper _output;
        private readonly ILogger<UseXUnitWithDI> _logger;
        private readonly IServerDemo _demoServer;

        public UseXUnitWithDI(ITestOutputHelperAccessor helperAccessor, ILogger<UseXUnitWithDI> logger, IServerDemo serverDemo)
        {
            this._output = helperAccessor.Output!;
            this._logger = logger;
            this._demoServer = serverDemo;
        }

        [Fact]
        public void Use_ITestOutputHelper_Test()
        {
            Assert.True(true, "xUnit��ʹ������ע���� Xunit.DependencyInjection��");
        }

        [Fact]
        public void Use_Test()
        {
            _output.WriteLine($"xUnit��ʹ������ע���� Xunit.DependencyInjection��");
            Assert.True(true);
        }

        [Fact]
        public void Use_ILogger_Test()
        {
            _logger.LogInformation("logger��־������� xUnit ��׼����У������Ϳ���ֻʹ��logger��־����");
            Assert.True(true);
        }

        [Fact]
        public void DemoServer_Test()
        {
            _logger.LogInformation($"ClassName = {_demoServer.GetClassName()}");
            Assert.Equal(nameof(ServerDemo), _demoServer.GetClassName());
        }

        public void Dispose()
        {

        }
    }
}