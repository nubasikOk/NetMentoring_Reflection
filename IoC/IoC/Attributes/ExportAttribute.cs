using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportAttribute: Attribute
    {
        
        public Type Contract { get; private set; }

        public ExportAttribute()
        { }

        public ExportAttribute(Type contract)
        {
            Contract = contract;
        }

    }
}
