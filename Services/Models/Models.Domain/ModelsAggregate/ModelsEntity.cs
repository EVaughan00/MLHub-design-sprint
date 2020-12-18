using BuildingBlocks.SeedWork;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Models.Domain.Aggregates
{
    public class ModelsEntity : Entity, IAggregateRoot
    {
        [BsonElement("Name")]
        public string Name { get; private set; }

        [BsonElement("DateCreated")]
        public DateTime DateCreated { get; private set; }

        [BsonElement("Status")]
        public ModelStatus Status { get; private set; }

        [BsonElement("Visibility")]
        public Visibility Visibility { get; private set; }

        [BsonElement("Classification")]
        public Classification Classification { get; private set; }


        public ModelsEntity(string name) {

            Name = name;
            DateCreated = DateTime.Now;

            setStatus(ModelStatus.ACTIVE);
        }

        public void setVisibility(Visibility visibility) {
            Visibility = visibility;
        }

        public void setStatus(ModelStatus status) {
            Status = status;
        }

        public void setClassifiction(Classification classification) {
            Classification = classification;
        }

    }
}