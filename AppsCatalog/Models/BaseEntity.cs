using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppsCatalog.Models
{
    public abstract class BaseEntity
    {
        private string id;
        [Key]
        [Required]
        public string Id
        {
            get
            {
                return id ?? (id = Guid.NewGuid().ToString());
            }
            set
            {
                id = value;
            }
        }
        [Required]
        public DateTime CreationDate
        {
            get;
            protected set;
        }

        protected BaseEntity()
        {
            CreationDate = DateTime.Now;
        }
    }
}
