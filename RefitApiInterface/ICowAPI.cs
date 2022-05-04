using CowApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;

namespace CowApi.Controllers
{
    public interface ICowAPI
    {
        [Get("/{collarId}/status")]
        Task<List<CollarStatus>> GetCollarStatusList(string collarId);
    }
}
