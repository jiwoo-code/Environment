using EnvironmentTest.Environment.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvironmentTest
{
    public class TestEnvironment1 : IEnvironment
    {
        public string Test1 { get; set; }
        public string Test2 { get; set; }

        public void Initialize()
        {
            Test1 = "1";
            Test2 = "2";
        }
    }
}
