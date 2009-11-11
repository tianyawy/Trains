using System.Collections.Generic;

namespace Trains.Core.Domain
{
    public interface SearchAlgorithm
    {
        IList<ITrip> run();
    }
}