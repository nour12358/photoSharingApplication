using PhotoSharingApp.Model;
using PhotoSharingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApp.Controllers
{
    public class PhotoController : Controller
    {
        private PhotoSharingContext context = new PhotoSharingContext();
        // GET: Photo
        public ActionResult Index()
        {
            //var photo = new Photo();
            return View(context.Photos.ToList()); 
                //context.Photos.First<Photo>());
        }
        public ActionResult Display(int id)
        {
            List<Photo> photos = context.Photos.ToList();
            var verif = photos.Find(photo => photo.PhotoID == id);
            if (verif != null)
                return View("display" , verif);
            else
                return HttpNotFound();
        }
        public ActionResult Create()
        {
            Photo photo = new Photo();
            photo.CreatedDate = DateTime.Now;
            return View("created", photo);
        }
        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            { if(image!=null)
                {
                    photo.ImageMimeType = image.ContentType;
                    photo.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength);
                    context.Photos.Add(photo);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
               
            else
            {
                return View("Create", photo); }
        }
    
    public ActionResult Delete(int id)
    {
        List<Photo> photos = context.Photos.ToList();
        var verif = photos.Find(photo => photo.PhotoID == id);
        if (verif != null)
            return HttpNotFound();
        else
            return View("delete", verif);
        
    }
    [HttpPost]
    [ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        List<Photo> photos = context.Photos.ToList();
        var verif = photos.Find(photo => photo.PhotoID == id);
        //verification de lexistence de l'image 
        //test sur la verif

            context.Entry(verif).State = System.Data.EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
    }


    }


}