using BuildingBlocks.SeedWork;

namespace Models.Domain.Aggregates
{
    public class Visibility : Enumeration
    {
        public static Visibility PUBLIC = new Visibility(1, "Public");
        public static Visibility PRIVATE = new Visibility(2, "Private");
        public Visibility(int id, string name) : base(id, name) {}
    }
}