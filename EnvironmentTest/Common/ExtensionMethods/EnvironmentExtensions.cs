using EnvironmentTest.Common.Utilities;
using EnvironmentTest.Environment.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace EnvironmentTest.Common.ExtensionMethods
{
    public static class EnvironmentExtensions
    {
        /// <summary>
        /// 환경설정 파일 불러와 값 설정하기
        /// </summary>
        public static T Read<T>(this T Env, string EnvironmentFilePath = null) where T : IEnvironment
        {
            if (string.IsNullOrEmpty(EnvironmentFilePath))
            {
                EnvironmentFilePath = Path.Combine(Define.ConfDirPath, $"{typeof(T).Name}.json");
            }

            using (StreamReader r = new StreamReader(EnvironmentFilePath))
            {
                string json = r.ReadToEnd();
                Env = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            }

            return Env;
        }

        /// <summary>
        /// 설정 값을 파일로 저장하기
        /// </summary>
        public static T Save<T>(this T Env, string EnvironmentFilePath = null) where T : IEnvironment
        {
            if (string.IsNullOrEmpty(EnvironmentFilePath))
            {
                EnvironmentFilePath = Path.Combine(Define.ConfDirPath, $"{typeof(T).Name}.json");
            }

            //if (string.IsNullOrWhiteSpace(EnvironmentFilePath))
            //{
            //    string param = "string EnvironmentFilePath";
            //    throw new ArgumentNullException(param);
            //}

            string jsonString = JsonConvert.SerializeObject(Env, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText(EnvironmentFilePath, jsonString);

            return Env;
        }
    }
}
