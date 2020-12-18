using Microsoft.Extensions.Logging;
using Models.Domain.Aggregates;
using BuildingBlocks.SeedWork;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Models.Infrastructure
{
    public class ModelsEntityRepository : IModelsEntityRepository
    {
        private ILogger<ModelsEntityRepository> _logger;
        private IDbCollection<ModelsEntity> _models;
        public static string CollectionName = "ModelsEntities";

        public ModelsEntityRepository(ILoggerFactory logger, IDatabaseContext context)
        {
            _logger = logger.CreateLogger<ModelsEntityRepository>();
            _models = context.GetCollection<ModelsEntity>(CollectionName);
        }

        public void Create(ModelsEntity entity)
        {
            _models.InsertOne(entity);
            _logger.LogInformation($"Models {entity.Name} inserted in database"); 
        }

        public List<ModelsEntity> GetAll() 
        {
            var result = _models.FindAll();

            if (result == null) 
            {
                _logger.LogInformation($"Non-existant Models retrieval attempted");
            }

            _logger.LogInformation($"Modelss retrieved from database");
            return result;
        }

        public ModelsEntity GetById(ObjectId id) 
        {
            var result = _models.FindOne(e => e.Id.Equals(id));

            if (result == null) 
            {
                _logger.LogInformation($"Non-existant Models retrieval attempted");
                throw new System.Exception("Could not retreive entity");
            }

            _logger.LogInformation($"Models [{result.Name}] retrieved from database");
            return result;
        }
        public void Update(ModelsEntity Models)
        {
            var existing = _models.FindOne(u => u.Id == Models.Id);

            if (existing == null)
            {
                throw new System.Exception("No models found to update");
            }

            _models.UpdateOne(Models);
        }
    }
}