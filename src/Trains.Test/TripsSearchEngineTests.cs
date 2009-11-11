using NUnit.Framework;
using Trains.Core.Domain;
using Trains.Core.Services;

namespace Trains.Test
{
    [TestFixture]
    public class TripsSearchEngineTests
    {

        private string graph = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
        private TripsSearchEngine engine;

        [SetUp]
        public void setUp()
        {
            engine = new TripsSearchEngine(graph);
        }

        [Test]
        public void should_get_nine_as_distance_from_route_ABC()
        {
            
            var result = engine.GetDistanceFromRoute("A-B-C");

            Assert.AreEqual(9, result);
        }

        [Test]
        public void should_get_five_as_distance_from_route_AD()
        {
            
            var result = engine.GetDistanceFromRoute("A-D");

            Assert.AreEqual(5, result);
        }

        [Test]
        public void should_get_thriteen_as_distance_from_route_ADC()
        {
            
            var result = engine.GetDistanceFromRoute("A-D-C");

            Assert.AreEqual(13, result);
        }

        [Test]
        public void should_get_twenty_two_as_distance_from_route_AEBCD()
        {
            
            var result = engine.GetDistanceFromRoute("A-E-B-C-D");

            Assert.AreEqual(22, result);
        }


        [Test]
        public void should_get_inexistent_route_exception_for_route_AED()
        {
            Assert.Throws<InexistentRouteException>(delegate { engine.GetDistanceFromRoute("A-E-D"); });
        }

        [Test]
        public void should_get_the_number_of_routes_starting_at_C_and_ending_at_C_with_max_3_stops()
        {
            
            var result = engine.GetRoutesWithMaxNumberOfStops('C','C',3).Count;
            Assert.AreEqual(2, result);
        }

        [Test]
        public void should_get_the_number_of_routes_starting_at_A_and_ending_at_C_with_exact_4_stops()
        {
            
            var result = engine.GetRoutesWithExactNumberOfStops('A','C',4).Count;
            Assert.AreEqual(3, result);
        }

        [Test]
        public void should_find_the_lenght_of_the_shortest_route_from_A_to_C()
        {
            ITrip shortest = engine.GetShortestRouteBetween('A', 'C');
            var result = shortest.GetDistance();
            Assert.AreEqual(9, result);
        }

        [Test]
        public void should_find_the_lenght_of_the_shortest_route_from_B_to_B()
        {
            ITrip shortest = engine.GetShortestRouteBetween('B', 'B');
            var result = shortest.GetDistance();
            Assert.AreEqual(9, result);
        }

        [Test]
        public void should_find_all_different_routes_from_C_to_C_with_distance_less_than_30()
        {
            var result = engine.GetRoutesWithDistanceLowerThan(30, 'C', 'C').Count;
            Assert.AreEqual(7, result);
        }
        
    }
}