using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.BaseRepository.Abstract
{
    public abstract class EntityBase
    {
        public virtual bool IsActive { get; set; } = true;
        public virtual bool IsDelete { get; set; } = false;
        public virtual string ModifiedName { get; set; } = "User";
        public virtual string CreatedName { get; set; } = "User";
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
