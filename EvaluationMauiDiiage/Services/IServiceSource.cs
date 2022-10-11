using EvaluationMauiDiiage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationMauiDiiage.Services.Interfaces
{
    public interface IServiceSource
    {
        public Task<List<RDVEntity>> GetSourceFileContent();
    }
}
