using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Model
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public string Title { get; set; }
        public  byte[] PhotoFile { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }




    }

}