using Informers;
using Insta;
using Insta.AuthenticationProcessor.Services;
using Insta.StoryProcessor.Services;
using Insta.UserProcessor.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaWebAppControllers.Services
{
    public class StoriesService : IStoriesService
    {
        public async Task<IReadOnlyList<string>> GetStories(string userName)
        {
            const string stateFile = "state.bin";

            var IOService = new StubInputOutputService();

            var authentificator = new Authentificator();
            var (_, instaApi) = await authentificator.AuthentificateByDefaultWay(stateFile, IOService);

            var apiKeeper = new ApiKeeper(instaApi);

            var userService = new UserService(apiKeeper.InstaApi);
            var userInfo = await userService.GetUserInfo(userName);

            var mediaService = new StoryService(apiKeeper.InstaApi);
            var stories = await mediaService.GetUserStories(userInfo);

            return stories.SelectMany(st =>
                st.Images.Select(img => img.Uri).Distinct().Concat(
                st.Videos.Select(vd => vd.Uri).Distinct()
                )).ToArray();
        }
    }
}
