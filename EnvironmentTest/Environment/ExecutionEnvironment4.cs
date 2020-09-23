using EnvironmentTest.Common;
using EnvironmentTest.Common.Utilities;
using EnvironmentTest.Common.ExtensionMethods;
using EnvironmentTest.Environment.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnvironmentTest.Environment
{
    public class ExecutionEnvironment4<T> where T : IEnvironment, new()
    {
        #region Singleton

        private static readonly Lazy<ExecutionEnvironment4<T>> instance = new Lazy<ExecutionEnvironment4<T>>(() => new ExecutionEnvironment4<T>());

        public static ExecutionEnvironment4<T> Instance
        {
            get
            {
                return instance.Value;
            }
        }

        #endregion Singleton

        private readonly string environmentFilePath;

        public T Env { get; set; }

        public string EnvironmentFilePath => environmentFilePath;

        private ExecutionEnvironment4()
        {
            Env = new T();
            environmentFilePath = Path.Combine(Define.ConfDirPath, $"{typeof(T).Name}.json");

            // 환경설정 폴더 없으면 생성
            DirectoryUtilities.CreateDirectory(Define.ConfDirPath);

            // 설정파일 확인
            if (File.Exists(environmentFilePath))
            {
                Env = Env.Read(environmentFilePath);
            }
            else
            {
                Env.Initialize();
                Env = Env.Save(environmentFilePath);
            }
        }
    }
}
