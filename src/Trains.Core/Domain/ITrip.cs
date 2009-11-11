using System.Collections.Generic;

namespace Trains.Core.Domain
{
    public interface ITrip
    {
        IList<IEdge> Route { get; }
        int getNumberOfStops();
        Node LastNode();
        Node StartNode();
        bool IsEmpty();
        bool Contains(IEdge edge);
        void AddEdge(IEdge edge);
        int GetDistance();

    }
}