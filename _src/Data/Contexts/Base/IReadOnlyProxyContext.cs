﻿using Data.Entities.Proxy;

namespace Data.Contexts.Base;

public interface IReadOnlyProxyContext
{
    IQueryable<WebHost> WebHosts { get; }
    IQueryable<Route> Routes { get; }
    IQueryable<Cluster> Clusters { get; }
    IQueryable<Match> Matches { get; }
    IQueryable<Certificate> Certificates { get; }
    IQueryable<SessionAffinity> SessionAffinities { get; }
    IQueryable<Destination> Destinations { get; }
    IQueryable<Metadata> Metadata { get; }
    IQueryable<HttpClientSettings> HttpClients { get; }
    IQueryable<HttpRequestSettings> HttpRequests { get; }
    IQueryable<HealthCheck> HealthChecks { get; }
    IQueryable<ActiveHealthCheck> ActiveHealthChecks { get; }
    IQueryable<PassiveHealthCheck> PassiveHealthChecks { get; }
    IQueryable<Transform> Transforms { get; }
    IQueryable<HeaderMatch> HeaderMatches { get; }
    IQueryable<QueryParameterMatch> QueryParameterMatches { get; }
}