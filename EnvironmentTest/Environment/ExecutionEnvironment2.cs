using EnvironmentTest.Common;
using EnvironmentTest.Common.Utilities;
using EnvironmentTest.Environment.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnvironmentTest.Environment
{
    public class ExecutionEnvironment2<T> where T : IEnvironment, new()
    {
        private static object _Lock = new object();
        private static ExecutionEnvironment2<T> _instacne;
        public static ExecutionEnvironment2<T> Instacne
        {
            get
            {
                if (_instacne == null)
                {
                    lock (_Lock)
                    {
                        _instacne = new ExecutionEnvironment2<T>();
                    }

                }
                return _instacne;
            }
        }


        private readonly string EnvironmentFilePath;

        public T Env { get; set; }

        private ExecutionEnvironment2()
        {
            Env = new T();
            EnvironmentFilePath = Path.Combine(Define.ConfDirPath, $"{typeof(T).Name}.json");

            // 환경설정 폴더 없으면 생성
            DirectoryUtilities.CreateDirectory(Define.ConfDirPath);

            // 설정파일 확인
            if (File.Exists(EnvironmentFilePath))
            {
                Read();
            }
            else
            {
                Env.Initialize();
                Save();
            }
        }

        /// <summary>
        /// 환경설정 파일 불러와 값 설정하기
        /// </summary>
        public void Read()
        {
            using (StreamReader r = new StreamReader(EnvironmentFilePath))
            {
                string json = r.ReadToEnd();
                Env = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            }
        }

        /// <summary>
        /// 설정 값을 파일로 저장하기
        /// </summary>
        public void Save()
        {
            if (string.IsNullOrWhiteSpace(EnvironmentFilePath))
            {
                string param = "string path";
                throw new ArgumentNullException(param);
            }

            string jsonString = JsonConvert.SerializeObject(Env, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText(EnvironmentFilePath, jsonString);
        }
    }
}
