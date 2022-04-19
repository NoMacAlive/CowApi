using HalterExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalterExercise.Controllers
{
    interface ICowAPI
    {
        [Get("/users/{user}")]
        Task<List<Cow>> GetCows(string cowId);
    }
}
