using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRart.Data.Art
{
    public interface IArtRepository
    {
        //IEnumerable for returning static types. IQueryable for adding paging, filtering, etc
        IQueryable<Album> GetAlbums();
        IQueryable<Upload> GetUploadsByAlbums(int albumID);
    }
}
