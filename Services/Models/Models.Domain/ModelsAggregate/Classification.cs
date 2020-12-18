using BuildingBlocks.SeedWork;

namespace Models.Domain.Aggregates
{

    public class Classification : Enumeration
    {
        public static Classification BINARY = new Classification(1, "Binary");
        public static Classification MULTI_CLASS = new Classification(2, "Multi-class");
        public static Classification MULTI_LABEL = new Classification(3, "Multi-label");
        public static Classification IMBALANCED = new Classification(4, "Imbalanced");
        public Classification(int id, string name) : base(id, name) {}

    }
}