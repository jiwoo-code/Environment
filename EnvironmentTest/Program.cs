using EnvironmentTest.Environment;
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
            var executionEnv3 = new ExecutionEnvironment<TestEnvironment3>().Env;
            Console.WriteLine(executionEnv1.Test1);
            Console.WriteLine(executionEnv2.TestB);
            Console.WriteLine(executionEnv3.Users);

            var env1 = ExecutionEnvironment2<TestEnvironment1>.Instacne.Env;
            var env2 = ExecutionEnvironment2<TestEnvironment2>.Instacne.Env;
            var env3 = ExecutionEnvironment2<TestEnvironment3>.Instacne.Env;
            var env4 = ExecutionEnvironment2<TestEnvironment4>.Instacne.Env;
            var env5 = ExecutionEnvironment2<TestEnvironment4>.Instacne.Env;

            env4.DBConnectionString = "1";
            env5.DBConnectionString = "2";

            var e1 = ExecutionEnvironment3<TestEnvironment1>.InstanceEnv;
            var e2 = ExecutionEnvironment3<TestEnvironment2>.InstanceEnv;
            var e3 = ExecutionEnvironment3<TestEnvironment3>.InstanceEnv;
            var e4 = ExecutionEnvironment3<TestEnvironment4>.InstanceEnv;
            var e5 = ExecutionEnvironment3<TestEnvironment4>.InstanceEnv;

            e4.DBConnectionString = "1";
            e5.DBConnectionString = "2";

            Console.WriteLine( e1.GetHashCode().ToString());
            Console.WriteLine( e2.GetHashCode().ToString());
            Console.WriteLine( e3.GetHashCode().ToString());
            Console.WriteLine( e4.GetHashCode().ToString());
            Console.WriteLine( e5.GetHashCode().ToString());
        }
    }
}
