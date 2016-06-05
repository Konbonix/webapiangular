using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRart.Models;
using VRart.Extensions;
using System.IO;
using VRart.Services;
using System.Web.Http;

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
            return _ctx.Albums.Where(a => a.AlbumId == id).First();
        }

        public Album GetAlbumWithUploads(int id)
        {
            return _ctx.Albums.Include("Uploads").Where(a => a.AlbumId == id).First();
        }


        public void AddUpload(Upload newUpload)
        {
            try
            {
                _ctx.Uploads.Add(newUpload);
            }
            catch (Exception ex)
            {
                //TODO log this
            }
        }

        ////TODO - Move this code to service or BLL layer?
        //public Upload AddUpload(byte[] httpPostedFile)
        //{
        //    string savePath = "c:\\Temp\\Uploads\\"; //TODO - expose as config. 
        //    string fileName = UploadServices.GetRandomFileName();
        //    string path = savePath + fileName;
            
        //    //TODO - Save in context
        //    try
        //    {
        //        File.WriteAllBytes(path, httpPostedFile);
        //    }
        //    catch (Exception e)
        //    {
        //        //todo log this
        //        throw;
        //    }           

        //}

        public void AddTiltUploadAndAlbum(byte[] httpPostedFile)
        {
            string filePath = @"C:\Temp\Uploads\"; //TODO - expose as config

            //Create New Album For the File
            var newAlbum = new Album();
            newAlbum.AlbumUrl = UploadServices.GetRandomFileName();
            _ctx.Albums.Add(newAlbum);
            Save();

            //Create new tile file upload
            var newUpload = new Upload();
            newUpload.FileName = newAlbum.AlbumUrl + ".tilt";
            newUpload.FilePath = filePath;
            newUpload.AlbumId = newAlbum.AlbumId;
           
            //Write file to disk TODO - move this into service?
            try
            {
                //Save in context
                _ctx.Uploads.Add(newUpload);
                Save();
                //Write to disk
                File.WriteAllBytes(newUpload.FilePath + newUpload.FileName , httpPostedFile);

                //Create the thumbnail 
                UploadServices.ExtractThumbNail(httpPostedFile, filePath, newAlbum.AlbumUrl + ".png");
            }
            catch
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

           
        }

        //public bool AddUpload(HttpPostedField httpPostedField, HttpPostedFile httpPostedFile, int AlbumId)
        //{
        //    return true;
        //}

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
