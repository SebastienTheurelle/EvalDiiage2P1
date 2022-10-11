namespace EvaluationMauiDiiage.Services
{
    public interface IServiceSource
    {
        public Task<string> GetSourceFileContent();
    }
}