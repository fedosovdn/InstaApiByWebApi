using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstaWebAppControllers.Services
{
    public interface IStoriesService
    {
        Task<IReadOnlyList<string>> GetStories(string userName);
    }
}
