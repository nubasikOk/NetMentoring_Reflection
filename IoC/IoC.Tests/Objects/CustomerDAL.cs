using IoC.Attributes;

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
}
