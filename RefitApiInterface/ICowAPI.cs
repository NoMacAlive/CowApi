using HalterExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;

namespace HalterExercise.Controllers
{
    public interface ICowAPI
    {
        [Get("/{collarId}/status")]
        Task<List<CollarStatus>> GetCollarStatusList(string collarId);
    }
}
