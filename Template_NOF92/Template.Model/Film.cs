using NakedObjects;
using NakedObjects.Redirect;
using NakedObjects.Value;
using System;

namespace Template.Model
{
    public class Film
    {
        //All persisted properties on a domain object must be 'virtual'

        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int FilmID { get; set; }

        [Title]//This property will be used for the object's title at the top of the view and in a link
        public virtual string FilmTitle { get; set; }

        [Optionally]
        public virtual string Genre { get; set; }
        public virtual string Director { get; set; }
        public virtual DateTime? DateReleased { get; set; }
        public virtual string Trailer { get; set; }

        

        public virtual FileAttachment Image
        {
            get
            {
                if (AttContent == null) return null;
                return new FileAttachment(AttContent, AttName, AttMime);
            }
        }

        [NakedObjectsIgnore]
        public virtual byte[] AttContent { get; set; }

        [NakedObjectsIgnore]
        public virtual string AttName { get; set; }

        [NakedObjectsIgnore]
        public virtual string AttMime { get; set; }

        public void AddOrChangeImage(FileAttachment newImage)
        {
            AttContent = newImage.GetResourceAsByteArray();
            AttName = newImage.Name;
            AttMime = newImage.MimeType;
        }



    }
}
