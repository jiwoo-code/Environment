using EnvironmentTest.Common;
using EnvironmentTest.Common.ExtensionMethods;
using EnvironmentTest.Environment;
using System;
using System.IO;

namespace EnvironmentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var executionEnv1 = new ExecutionEnvironment<TestEnvironment1>().Env;
            var executionEnv2 = new ExecutionEnvironment<TestEnvironment2>().Env;
            var executionEnv3 = new ExecutionEnvironment<TestEnvironment3>().Env;
            Console.WriteLine(executionEnv1.Test1);
            Console.WriteLine(executionEnv2.TestB);
            Console.WriteLine(executionEnv3.Users);

            var env1 = ExecutionEnvironment2<TestEnvironment1>.Instacne.Env;
            var env2 = ExecutionEnvironment2<TestEnvironment2>.Instacne.Env;

            env2.TestA = "A";

            var e1 = ExecutionEnvironment3<TestEnvironment1>.Instance;
            var e2 = ExecutionEnvironment3<TestEnvironment2>.Instance;
            var e3 = ExecutionEnvironment3<TestEnvironment3>.Instance;

            e3.Env.DBConnectionString = "1";

            Console.WriteLine( e1.GetHashCode().ToString());
            Console.WriteLine( e2.GetHashCode().ToString());
            Console.WriteLine( e3.GetHashCode().ToString());

            var execution1 = ExecutionEnvironment4<TestEnvironment3>.Instance;
            var execution2 = ExecutionEnvironment4<TestEnvironment4>.Instance;
            execution1.Env.DBConnectionString = "execution1";
            execution2.Env.DBConnectionString = "execution2";
            execution1.Env.Save(execution1.EnvironmentFilePath);
            execution2.Env.Save();
            Console.WriteLine();
        }
    }
}
