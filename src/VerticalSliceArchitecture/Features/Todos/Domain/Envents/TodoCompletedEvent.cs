using MediatR;

namespace VerticalSliceArchitecture.Features.Todos.Domain.Envents;

public record TodoCompletedEvent(Guid TodoId) : INotification;