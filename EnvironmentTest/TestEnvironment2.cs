using EnvironmentTest.Environment.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvironmentTest
{
    public class TestEnvironment2 : IEnvironment
    {
        public string TestA { get; set; }
        public string TestB { get; set; }
        public List<string> TestC { get; set; }

        public void Initialize()
        {
            TestA = "A";
            TestB = "B";
            TestC = new List<string>()
            {
                "C1",
                "C2",
                "C3"
            };
        }
    }
}
