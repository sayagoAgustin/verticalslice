using MediatR;

namespace VerticalSliceArchitecture.Features.Todos.Domain.Envents;

public record TodoCreatedEvent(Guid TodoId) : INotification;
