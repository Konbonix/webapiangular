using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRart.Models;
using VRart.Extensions;
namespace VRart.Dal
{
    public interface IArtRepository
    {
        //IEnumerable for returning static types. IQueryable for adding paging, filtering, etc
        IQueryable<AlbumOverview> GetAlbumsOverview();
        IQueryable<Album> GetAlbums();
        Album GetAlbum(string albumUrl);
        Album GetAlbumWithUploads(int id);
        IQueryable<Upload> GetUploads();
        IQueryable<Upload> GetUploadsByAlbumId(int albumId);



        bool Save();
        bool AddAlbum(Album newAlbum);
        //void AddUpload(Upload newUpload);
        //void AddUpload(byte[] httpPostedFile);
        //bool AddUpload(HttpPostedField httpPostedField, HttpPostedFile httpPostedFile, int AlbumId);

        string AddTiltUploadAndAlbum(byte[] httpPostedFile);
    }
}
