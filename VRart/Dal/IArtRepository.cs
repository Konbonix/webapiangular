using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRart.Models;

namespace VRart.Dal
{
    public interface IArtRepository
    {
        //IEnumerable for returning static types. IQueryable for adding paging, filtering, etc
        IQueryable<Album> GetAlbums();
        Album GetAlbum(int id);
        Album GetAlbumWithUploads(int id);
        IQueryable<Upload> GetUploads();
        IQueryable<Upload> GetUploadsByAlbumId(int albumId);



        bool Save();
        bool AddAlbum(Album newAlbum);
        bool AddUpload(Upload newUpload);
    }
}
