namespace Trains.Core.Domain
{
    public interface IEdge
    {
            int Distance { get; }
            Node End { get; }
            Node Start { get; }
    }
}