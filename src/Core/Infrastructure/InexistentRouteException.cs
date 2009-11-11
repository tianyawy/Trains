using System;

namespace Trains
{
    public class InexistentRouteException : Exception
    {
            public override string Message
            {
                get
                {
                    return "NO SUCH ROUTE";
                }
            }
    }
}