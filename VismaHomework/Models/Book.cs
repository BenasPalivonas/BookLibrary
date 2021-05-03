using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VismaHomework.Entities
{
    class Book
    {

        public string Name { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public string Language { get; set; }

        public Nullable<DateTime> PublicationDate { get; set; }

        public string ISBN { get; set; }

        public Nullable<DateTime> reservedUntill { get; set; }

    }
}
