using System;
namespace EvaluationMauiDiiage.Services.Interfaces
{
    public interface IServiceSource
    {
        Task<string> GetSourceFileContent();
    }
}

