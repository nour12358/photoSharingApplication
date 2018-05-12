using PhotoSharingApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Models
{
    public class PhotoSharingContext : DbContext
    {
        public DbSet<Photo> Photo { get; set; }
           public  DbSet<Comment> Comments { get; set; }
        public object Photos { get; internal set; }
    }
}