using System.Collections.Generic;
using MediatR;

namespace WebApiWithCqrsMediatRExample.Queries
{
    public class GetValuesQuery
    {
        public class Query : IRequest<IEnumerable<string>> { }

        public class Handler : RequestHandler<Query, IEnumerable<string>>
        {
            private readonly FakeDataStore _db;
            public Handler(FakeDataStore db)
            {
                _db = db;
            }
            protected override IEnumerable<string> Handle(Query request)
            {
                return _db.GetAllValues();
            }
        }
    }
}