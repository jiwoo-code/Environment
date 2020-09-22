﻿using EnvironmentTest.Environment;
using System;

namespace EnvironmentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var executionEnv1 = new ExecutionEnvironment<TestEnvironment1>().Env;
            var executionEnv2 = new ExecutionEnvironment<TestEnvironment2>().Env;
            Console.WriteLine(executionEnv1.Test1);
            Console.WriteLine(executionEnv2.TestB);
        }
    }
}