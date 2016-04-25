using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRart.Models;

namespace VRart.Dal
{
    public class ArtRepository : IArtRepository
    {
        ArtContext _ctx;
        public ArtRepository()
        {
            _ctx = new ArtContext();
        }

        public bool AddAlbum(Album newAlbum)
        {
            //TODO log this
            _ctx.Albums.Add(newAlbum);
            return true;
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

        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception)
            {
                //TODO log this 
                return false;
            }
        }
    }
}
