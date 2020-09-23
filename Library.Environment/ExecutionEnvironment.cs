using Library.Common;
using Library.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Library.Environment
{
    public class ExecutionEnvironment<T> where T : IEnvironment, new()
    {
        #region Singleton

        private static readonly Lazy<ExecutionEnvironment<T>> instance = new Lazy<ExecutionEnvironment<T>>(() => new ExecutionEnvironment<T>());

        public static ExecutionEnvironment<T> Instance
        {
            get
            {
                return instance.Value;
            }
        }

        #endregion Singleton

        public T Env { get; set; }

        public string EnvironmentFilePath { get; set; }

        private ExecutionEnvironment()
        {
            Env = new T();
            EnvironmentFilePath = Path.Combine(Define.ConfDirPath, $"{typeof(T).Name}.json");

            // 환경설정 폴더 없으면 생성
            DirectoryUtilities.CreateDirectory(Define.ConfDirPath);

            // 설정파일 확인
            if (File.Exists(EnvironmentFilePath))
            {
                Env = Env.Read(EnvironmentFilePath);
            }
            else
            {
                Env.Initialize();
                Env = Env.Save(EnvironmentFilePath);
            }
        }
    }
}
