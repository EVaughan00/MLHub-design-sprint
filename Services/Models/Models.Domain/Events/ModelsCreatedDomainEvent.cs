using BuildingBlocks.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Domain.Events
{
    public class ModelsCreatedDomainEvent : DomainEvent
    {
        public string ModelsID { get; set; }
    }
}
