using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApiWithCqrsMediatRExample.Notifications;

namespace WebApiWithCqrsMediatRExample.Commands
{
    public class AddValueCommand
    {
        public class Command : IRequest
        {
            public Command(string value)
            {
                Value = value;
            }

            public string Value { get; }
        }

        public class Handler : AsyncRequestHandler<Command>
        {
            private readonly FakeDataStore _db;
            private readonly IMediator _mediator;

            public Handler(FakeDataStore db, IMediator mediator)
            {
                _db = db;
                _mediator = mediator;
            }

            protected override async Task Handle(Command request, CancellationToken cancelationToken)
            {
                _db.AddValue(request.Value);
                await _mediator.Publish(new ValueAddedNotification(request.Value));
            }
        }
    }
}