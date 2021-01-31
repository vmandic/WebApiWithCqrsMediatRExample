# CQRS + MediatR web API example

I am building this example as explaind on code-maze.com to learn more about CQRS and MediatR working together.

## Observations

- if request / resposne classes are not coupled with the handlers it might be hard to locate the handlers in code
- the commands and queries are just convention, everything is really an IRequest which refs the response type in its generic type (optionally)
- the nongeneric IRequest actually does have a backing response type of MediatR.Unit (observed in logging behavior)
- notifications can not be seamlessly ordered which is obviously by design, but still I'd like an option for that
- I did not try this, but I guess one can implement behaviors for targeted only handlers. ie. specific behaviors
- the behavior pipeline is the same as dotnet HTTP pipeline which makes it easy to understand

## Conclusion

Using CQRS as opposed to "business service layer" is till using a BAL but the layman's explanation would be all you service methods which you are used to now become classes ie. BLH (business logic handlers). This is actually OK as it narrows the business concern in that specific class and narrows down its dependencies making it more transparent to you as a developer how "hard" one implementation is in terms of deps it takes in. With this kind of organization you do get more files and code but also a ton more of observability and maintenance speed-up as you are able to isolate logic with your "in-memory" sort of message que system implemented with MediatR. I think Jimmy did us all a favor by making this tool. It is definately a worth of try and definately NOT for every project. This would fit great in enterprise scale systems as again favors SRP of SOLID but then agian it does hide the direct "business" deps in the controllers as IMediator instance just sends or publishes messages away.

All in all a very good in memory message system to make your system more decoupled and logic better isolated.