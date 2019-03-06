using IoC.Attributes;

namespace IoC.Tests.Objects
{

    [Export(typeof(Logger))]
    public class Logger
    {
    }
}
