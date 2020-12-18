using BuildingBlocks.SeedWork;

namespace Models.Domain.Aggregates
{
    public class ModelStatus : Enumeration
    {
        public static ModelStatus ACTIVE = new ModelStatus(1, "Active");
        public static ModelStatus INACTIVE = new ModelStatus(2, "Inactive");
        public ModelStatus(int id, string name) : base(id, name) {}
    }
}