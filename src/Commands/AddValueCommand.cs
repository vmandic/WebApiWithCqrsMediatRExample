using MediatR;

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

        public class Handler : RequestHandler<Command>
        {
            private readonly FakeDataStore _db;

            public Handler(FakeDataStore db)
            {
                _db = db;
            }

            protected override void Handle(Command request)
            {
                _db.AddValue(request.Value);
            }
        }
    }
}