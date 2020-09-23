using Library.Environment;
using System;
using System.IO;

namespace EnvironmentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");

                var execution = ExecutionEnvironment<TestEnvironment>.Instance;
                execution.Env.DBConnectionString = "execution";
                execution.Env.Save(execution.EnvironmentFilePath);
                execution.Env.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
