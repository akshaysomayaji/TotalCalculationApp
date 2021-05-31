using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CommonData
    {
        public bool flgActive { get; set; }
        public int AddedBy { get; set; }
        public DateTime dtAddedOn { get; set; }
        public int intModifiedBy { get; set; }
        public DateTime dtModifiedOn { get; set; }
    }
}
