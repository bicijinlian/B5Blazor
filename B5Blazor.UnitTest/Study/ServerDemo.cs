using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B5Blazor.UnitTest.Study
{
    public class ServerDemo : IServerDemo
    {
        public string GetClassName()
        {
            return this.GetType().Name;
        }
    }
}
