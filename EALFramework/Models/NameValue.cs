using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EALFramework.Models
{
    public class NameValue<T,H>
    {
        public T Name { get; set; }
        public H Value { get; set; }
    }
}
