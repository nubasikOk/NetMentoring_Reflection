using IoC.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IoC.Tests.Objects
{
    public interface ICustomerDAL
    {
    }

    
    [Export(new Type[] { typeof(ICustomerDAL), typeof(IEnumerable) })]
    public class CustomerDAL : ICustomerDAL,IEnumerable
    {
        public CustomerDAL() { }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    [Export(typeof(IEnumerator))]
    public class CustomerDAL2 : ICustomerDAL
    {
        public CustomerDAL2() { }

      
    }





}
