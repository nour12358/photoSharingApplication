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
            List<Comment> comments = new List<Comment>();
            List <Photo> photo = new List<Photo>();
            Photo ph = new Photo();
            ph.Title = "Test Photo";
            ph.Description = "tesst tesst :p";
            ph.Owner = "NaokiSato";
           ph.PhotoFile = System.IO.File.ReadAllBytes("\\Users\\NOUR\\Desktop\\SEMESTRE2\\photoSharingApplication\\PhotoSharingApp\\Images\\flower.jpeg");
            ph.CreatedDate = DateTime.Now;
            ph.ImageMimeType = "image/jpeg";
            photo.Add(ph);
            foreach(Photo p in photo )
            context.Photos.Add(p);
            context.SaveChanges();
            Comment comm = new Comment();
            comm.PhotoID = 1;
            comm.User = "NaokiSato";
            comm.Subject = "Test Comment";
            comm.Body = "This comment should be appear in photo";
            comments.Add(comm);
            foreach (Comment c in comments)
                context.Comments.Add(c);
            context.SaveChanges();

            base.Seed(context);
        }
        // define getFileBytes
       /* byte[] getFileBytes(string image)
        {
            return System.IO.File.ReadAllBytes(image);
        }*/

    }
}