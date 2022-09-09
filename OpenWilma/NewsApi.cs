using OpenWilma.Wilma;

namespace OpenWilma;

public class NewsApi : INewsApi
{
    private readonly Role _role;
    private readonly IWilmaSession _session;

    public NewsApi(IWilmaSession session, Role role)
        => (_session, _role) = (session, role);

    /// <summary>
    /// Lists all the news stories available.
    /// </summary>
    public Task<IEnumerable<NewsRecord>> GetAllAsync()
    {
        return WAPI.GetAsync<IEnumerable<NewsRecord>>(_session, _role.Slug + "/news/index_json");
    }

    /// <summary>
    /// Returns the news story with its content.
    /// </summary>
    /// <param name="newsId">The unique id of the news.</param>
    public async Task<News> GetContentAsync(int newsId)
    {
        var news = await WAPI.GetAsync<IEnumerable<News>>(_session,
            _role.Slug + "/news/index_json/" + newsId).ConfigureAwait(false);
        return news.First();
    }
}
