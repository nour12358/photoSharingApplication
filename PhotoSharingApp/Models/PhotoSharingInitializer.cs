using PhotoSharingApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Models
{
    public class PhotoSharingInitializer:DropCreateDatabaseAlways <PhotoSharingContext> 
    {
        protected override void Seed(PhotoSharingContext context)
        {
            List<Photo> photo = new List<Photo>();
            Photo ph = new Photo();
            ph.Title = "Test Photo";
            ph.Description = "This is a test";
            ph.Owner = "NaokiSato";
            ph.PhotoFile = getFileBytes("\\Images\\");
            ph.CreatedDate = DateTime.Now;
            ph.ImageMimeType = "image/jpeg";
            photo.Add(ph);
            context.Photos.Add(photo.ForEach());
            base.Seed(context);


        }
        // define getFileBytes
        byte[] getFileBytes(string image)
        {
            return System.IO.File.ReadAllBytes(image);
        }

    }
}