using System.Threading;
using System.Threading.Tasks;
using Models.Domain.Events;
using BuildingBlocks.Common.Events;
using Microsoft.Extensions.Logging;

namespace Models.API.Application.DomainEventHandlers
{
    public class ReferenceDomainEvent : DomainEvent { }
    public class ReferenceDomainEventHandler : DomainEventHandler<ReferenceDomainEvent>
    {
        public override async Task Handle(ReferenceDomainEvent request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

        }
    }
}