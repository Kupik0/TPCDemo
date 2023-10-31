using TPCDemo.Shared.Events;

namespace TPCDemo.Application.Common.Events;

public interface IEventPublisher : ITransientService
{
    Task PublishAsync(IEvent @event);
}