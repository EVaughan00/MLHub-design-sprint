using BuildingBlocks.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Infrastructure.IntegrationEvents
{
    public class ModelsCreatedIntegrationEvent : Event
    {
        public string ModelsID{ get; private set; }

        public ModelsCreatedIntegrationEvent(string modelsID)
        {
            ModelsID = modelsID;
        }
    }
}
