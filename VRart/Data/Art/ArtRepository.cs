using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRart.Data.Art
{
    public class ArtRepository : IArtRepository
    {
        ArtContext _ctx;
        public ArtRepository()
        {
            _ctx = new ArtContext();
        }

        public IQueryable<Album> GetAlbums()
        {
            return _ctx.Albums;
            //throw new NotImplementedException();
        }

        public IQueryable<Upload> GetUploadsByAlbums(int albumID)
        {
            return _ctx.Uploads.Where(u => u.AlbumID == albumID);
        }
    }
}
