using System.Threading.Tasks;
using System.Collections.Generic;

using Wilma.Api.Wilma;

namespace Wilma.Api.Web
{
    public class MessageApi
    {
        private readonly WilmaRole _role;
        private readonly WilmaApiContext _context;

        public MessageApi(WilmaApiContext context, WilmaRole role)
        {
            _role = role;
            _context = context;
        }
        
        public async Task<IList<WilmaMessage>> FetchAsync()
        {
            return await WAPI.GetContentAsync<IList<WilmaMessage>>(_context,
                _role.Slug + "/messages/index_json").ConfigureAwait(false);
        }
    }
}
