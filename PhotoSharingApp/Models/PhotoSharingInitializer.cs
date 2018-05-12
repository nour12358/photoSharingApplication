using PhotoSharingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Models
{
    public class PhotoSharingInitializer:DropCreateDatabaseAlways <PhotoSharingContext> 
    {
        protected override void Seed(PhotoSharingContext context)
        {
            Collection<Photo> photo = new Collection<Photo>();
            Photo ph = new Photo();
            ph.Title = "Test Photo";
            ph.Description = "tesst tesst :p";
            ph.Owner = "NaokiSato";
            ph.PhotoFile = getFileBytes("\\Images\\");
            ph.CreatedDate = DateTime.Now;
            ph.ImageMimeType = "image/jpeg";
            photo.Add(ph);
            foreach(Photo p in photo )
            context.Photos.Add(p);
                base.Seed(context);


        }
        // define getFileBytes
        byte[] getFileBytes(string image)
        {
            return System.IO.File.ReadAllBytes(image);
        }

    }
}