using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EALFramework.Models
{
    //public interface INameValue {
    //    object Name { get; set; }
    //    object Value { get; set; }
    //}
    //public interface INameValue<T, H>
    //{
    //    T Name { get; set; }
    //    H Value { get; set; }
    //}
    public class NameValue<T,H>//: INameValue<T, H>
    {
        public T Name { get; set; }
        public H Value { get; set; }
       
    }

   
}
