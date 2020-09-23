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
    public abstract class EnvironmentBase<T>
    {
        protected T Environment { get; set; }

        private string EnvironmentFilePath;

        public void CheckEnvironment(T env)
        {
            Environment = env;
            EnvironmentFilePath = Path.Combine(Define.ConfDirPath, $"{typeof(T).Name}.json");

            // 환경설정 폴더 없으면 생성
            DirectoryUtilities.CreateDirectory(Define.ConfDirPath);

            // 설정파일 확인
            if (File.Exists(EnvironmentFilePath))
            {
                Road();
            }
            else
            {
                Initialize();
                Save();
            }
        }

        public abstract void Initialize();

        public virtual void Road()
        {
            using (StreamReader r = new StreamReader(EnvironmentFilePath))
            {
                string json = r.ReadToEnd();
                Environment = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            }
        }

        /// <summary>
        /// 설정 값을 파일로 저장하기
        /// </summary>
        public virtual void Save()
        {
            if (string.IsNullOrWhiteSpace(EnvironmentFilePath))
            {
                string param = "string path";
                throw new ArgumentNullException(param);
            }

            string jsonString = JsonConvert.SerializeObject(Environment, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText(EnvironmentFilePath, jsonString);
        }
    }
}
