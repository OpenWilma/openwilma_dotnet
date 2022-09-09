using OpenWilma.Wilma;

namespace OpenWilma;

public interface INewsApi
{
    Task<IEnumerable<NewsRecord>> GetAllAsync();
    Task<News> GetContentAsync(int newsId);
}