using System.Collections.Generic;
using BuildingBlocks.SeedWork;
using Models.Domain.Aggregates;
using MongoDB.Bson;


namespace Models.Infrastructure
{
    public interface IModelsEntityRepository : IRepository<ModelsEntity>
    {
        void Create(ModelsEntity ModelsEntity);
        List<ModelsEntity> GetAll();
        ModelsEntity GetById(ObjectId id);
        void Update(ModelsEntity ModelsEntity);
    }    
}