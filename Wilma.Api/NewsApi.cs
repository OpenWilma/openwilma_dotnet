using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Wilma.Api.Wilma;

namespace Wilma.Api
{
    public class NewsApi
    {
        private readonly Role _role;
        private readonly WilmaSession _session;

        public NewsApi(WilmaSession session, Role role)
        {
            _session = session;
            _role = role;
        }

        /// <summary>
        /// Lists all the news stories available.
        /// </summary>
        public Task<IEnumerable<NewsRecord>> GetStoriesAsync()
        {
            return WAPI.GetAsync<IEnumerable<NewsRecord>>(_session, _role.Slug + "/news/index_json");
        }

        /// <summary>
        /// Returns the news story with its content.
        /// </summary>
        /// <param name="newsId">The unique id of the news.</param>
        public async Task<News> GetStoryContentAsync(int newsId)
        {
            var news = await WAPI.GetAsync<IEnumerable<News>>(_session,
                _role.Slug + "/news/index_json/" + newsId).ConfigureAwait(false);
            return news.First();
        }
    }
}
