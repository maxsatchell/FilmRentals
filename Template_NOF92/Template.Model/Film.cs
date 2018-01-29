﻿using NakedObjects;

namespace Template.Model
{
    public class Film
    {
        //All persisted properties on a domain object must be 'virtual'

        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int FilmID { get; set; }

        [Title]//This property will be used for the object's title at the top of the view and in a link
        public virtual string FilmTitle { get; set; }
    }
}
