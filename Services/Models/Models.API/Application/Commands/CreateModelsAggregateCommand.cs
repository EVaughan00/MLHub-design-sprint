using System;
using BuildingBlocks.Common;
using Models.Domain.Aggregates;

namespace Models.API.Commands
{
    public class CreateModelsAggregateCommand : Command<bool>
    {
        public string name { get; set; }
        public string status { get; set; }
        public string visibility { get; set; }
        public string classification { get; set; }
    }
}