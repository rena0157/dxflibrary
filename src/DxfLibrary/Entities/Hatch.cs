
using DxfLibrary.Geometry;

namespace DxfLibrary.Entities
{
    public class Hatch : Entity, IGeoArea
    {
        public double Area => throw new System.NotImplementedException();

        public GeoPoint ElevationPoint {get;}
    }

    internal class HatchStructure : Entity
    {
        
    }
}