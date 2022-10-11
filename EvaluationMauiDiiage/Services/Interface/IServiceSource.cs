using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationMauiDiiage.Services.Interface
{
    public interface IServiceSource
    {
       Task<string> GetSourceFileContent();
    }
}
