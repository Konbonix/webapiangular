using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRart.Models;
using VRart.Extensions;
using System.IO;
using VRart.Services;

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
            try
            {
                _ctx.Albums.Add(newAlbum);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this
                return false;
            }
        }

        public IQueryable<Album> GetAlbums()
        {
            return _ctx.Albums;
            //throw new NotImplementedException();
        }

        public Album GetAlbum(int id)
        {
            return _ctx.Albums.Where(a => a.Id == id).First();
        }

        public Album GetAlbumWithUploads(int id)
        {
            return _ctx.Albums.Include("Uploads").Where(a => a.Id == id).First();
        }


        public bool AddUpload(Upload newUpload)
        {
            try
            {
                _ctx.Uploads.Add(newUpload);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this
                return false;
            }
        }

        //TODO - Move this code to service or BLL layer?
        public bool AddUpload(byte[] httpPostedFile)
        {
            string savePath = "c:\\Temp\\Uploads\\"; //TODO - expose as config. 
            string fileName = UploadServices.GetRandomFileName();
            string path = savePath + fileName;
            
            //TODO - Save in context
            try
            {
                File.WriteAllBytes(path, httpPostedFile);
            }
            catch (Exception e)
            {
                //todo log this
                throw;
            }           

            return true;
        }

        public bool AddUpload(HttpPostedField httpPostedField, HttpPostedFile httpPostedFile, int AlbumId)
        {
            return true;
        }

        public IQueryable<Upload> GetUploadsByAlbumId(int albumId)
        {
            return _ctx.Uploads.Where(u => u.AlbumId == albumId);
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

        public IQueryable<Upload> GetUploads()
        {
            return _ctx.Uploads;
        }

    }
}
