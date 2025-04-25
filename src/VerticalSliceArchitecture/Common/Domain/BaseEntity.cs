using MediatR;

namespace VerticalSliceArchitecture.Common.Domain;

public class BaseEntity
{
    public readonly List<INotification> StagedEvents = [];
}
