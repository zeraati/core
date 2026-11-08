using Common;

namespace FastEndpoints;

public abstract class FastEndpoint<TRequest, TData> : Endpoint<TRequest, Response<TData>> where TRequest : notnull
{
    protected void PermissionsByEndpointName() => Permissions(GetType().Name);

    protected Task Ok(TData data, string? message, CancellationToken cancellation)
    => Send.Success(data, message, cancellation);

    protected Task Fail(string message, IReadOnlyList<ApiError>? errors, CancellationToken cancellation)
    => Send.Fail(message, errors, cancellation: cancellation);
}

public abstract class FastEndpoint<TRequest> : Endpoint<TRequest, Response> where TRequest : notnull
{
    protected void PermissionsByEndpointName() => Permissions(GetType().Name);

    protected Task Ok(string? message, CancellationToken cancellation)
    => Send.Success(message, cancellation);

    protected Task Fail(string message, IReadOnlyList<ApiError>? errors, CancellationToken cancellation)
    => Send.Fail(message, errors, cancellation: cancellation);
}

public abstract class FastEndpointWithoutRequest : EndpointWithoutRequest<Response>
{
    protected void PermissionsByEndpointName() => Permissions(GetType().Name);

    protected Task Ok(string? message, CancellationToken cancellation)
    => Send.Success(message, cancellation);

    protected Task Fail(string message, IReadOnlyList<ApiError>? errors, CancellationToken cancellation)
    => Send.Fail(message, errors, cancellation: cancellation);
}

public abstract class FastEndpointWithoutRequest<TData> : EndpointWithoutRequest<Response<TData>>
{
    protected void PermissionsByEndpointName() => Permissions(GetType().Name);

    protected Task Ok(TData data, string? message, CancellationToken cancellation)
    => Send.Success(data, message, cancellation);

    protected Task Fail(string message, IReadOnlyList<ApiError>? errors, CancellationToken cancellation)
    => Send.Fail(message, errors, cancellation: cancellation);
}
