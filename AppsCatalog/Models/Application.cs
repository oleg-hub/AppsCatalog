using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppsCatalog.Models.enums;

namespace AppsCatalog.Models
{
    public class Application : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public CategoryType Сategory { get; set; }
        public string ApplicationUserName { get; set; } // change on one-to-many model
        public byte[] Cover { get; set; }



    }
}
