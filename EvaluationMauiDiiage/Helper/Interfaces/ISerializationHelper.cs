using System;
namespace EvaluationMauiDiiage.Helper.Interfaces
{
    public interface ISerializationHelper
    {
        T Deserialize<T>(string json);
    }
}

