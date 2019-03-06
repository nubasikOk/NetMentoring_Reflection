using IoC.Attributes;
using System.Collections;
using System.Collections.Generic;

namespace IoC.Tests.Objects
{
    public interface ICustomerDAL
    {
    }

    [Export(typeof(ICustomerDAL))]
    public class CustomerDAL : ICustomerDAL
    {
        public CustomerDAL() { }
    }


    [Export(typeof(IEnumerable))]
    public class CustomerDAL2 : ICustomerDAL
    {
        public CustomerDAL2() { }
    }
    [Export(typeof(IEnumerable),typeof(ICustomerDAL))]
     public class CustomerDAL3 : ICustomerDAL
    {
        public CustomerDAL3() { }
    }

}
