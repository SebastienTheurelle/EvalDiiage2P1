using System;
using EvaluationMauiDiiage.Helper.Interfaces;
using Newtonsoft.Json;

namespace EvaluationMauiDiiage.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class SerializationHelper : ISerializationHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public SerializationHelper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T Deserialize<T>(string json)
        {
            var resultObj = JsonConvert.DeserializeObject<T>(json);
            return resultObj;
        }
    }
}

