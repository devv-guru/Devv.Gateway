﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devv.Gateway.Data.Contexts.SqLite.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clusters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClusterId = table.Column<string>(type: "TEXT", nullable: false),
                    LoadBalancingPolicy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clusters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RouteId = table.Column<string>(type: "TEXT", nullable: false),
                    ClusterId = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: true),
                    MaxRequestBodySize = table.Column<long>(type: "INTEGER", nullable: true),
                    AuthorizationPolicy = table.Column<string>(type: "TEXT", nullable: false),
                    CorsPolicy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DestinationId = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Health = table.Column<string>(type: "TEXT", nullable: false),
                    ClusterConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destinations_Clusters_ClusterConfigId",
                        column: x => x.ClusterConfigId,
                        principalTable: "Clusters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthChecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClusterConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthChecks_Clusters_ClusterConfigId",
                        column: x => x.ClusterConfigId,
                        principalTable: "Clusters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HttpClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SslProtocols = table.Column<string>(type: "TEXT", nullable: false),
                    DangerousAcceptAnyServerCertificate = table.Column<bool>(type: "INTEGER", nullable: false),
                    MaxConnectionsPerServer = table.Column<int>(type: "INTEGER", nullable: false),
                    EnableMultipleHttp2Connections = table.Column<bool>(type: "INTEGER", nullable: false),
                    RequestHeaderEncoding = table.Column<string>(type: "TEXT", nullable: false),
                    ResponseHeaderEncoding = table.Column<string>(type: "TEXT", nullable: false),
                    ClusterConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HttpClients_Clusters_ClusterConfigId",
                        column: x => x.ClusterConfigId,
                        principalTable: "Clusters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HttpRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActivityTimeout = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false),
                    VersionPolicy = table.Column<string>(type: "TEXT", nullable: false),
                    AllowResponseBuffering = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClusterConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HttpRequests_Clusters_ClusterConfigId",
                        column: x => x.ClusterConfigId,
                        principalTable: "Clusters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionAffinities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    Policy = table.Column<string>(type: "TEXT", nullable: false),
                    FailurePolicy = table.Column<string>(type: "TEXT", nullable: false),
                    Settings = table.Column<string>(type: "TEXT", nullable: false),
                    ClusterConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionAffinities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionAffinities_Clusters_ClusterConfigId",
                        column: x => x.ClusterConfigId,
                        principalTable: "Clusters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SourceType = table.Column<int>(type: "INTEGER", nullable: false),
                    LocalPath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    KeyVaultName = table.Column<string>(type: "TEXT", nullable: false),
                    KeyVaultSecretName = table.Column<string>(type: "TEXT", nullable: false),
                    KeyVaultUri = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    AwsSecretName = table.Column<string>(type: "TEXT", nullable: false),
                    AwsRegion = table.Column<string>(type: "TEXT", nullable: false),
                    RouteConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_Routes_RouteConfigId",
                        column: x => x.RouteConfigId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Hosts = table.Column<string>(type: "TEXT", nullable: false),
                    Methods = table.Column<string>(type: "TEXT", nullable: false),
                    RouteConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Routes_RouteConfigId",
                        column: x => x.RouteConfigId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Metadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    RouteConfigId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClusterConfigId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Metadata_Clusters_ClusterConfigId",
                        column: x => x.ClusterConfigId,
                        principalTable: "Clusters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Metadata_Routes_RouteConfigId",
                        column: x => x.RouteConfigId,
                        principalTable: "Routes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestHeader = table.Column<string>(type: "TEXT", nullable: false),
                    Set = table.Column<string>(type: "TEXT", nullable: false),
                    RouteConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transforms_Routes_RouteConfigId",
                        column: x => x.RouteConfigId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActiveHealthChecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    Interval = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Timeout = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Policy = table.Column<string>(type: "TEXT", nullable: false),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Query = table.Column<string>(type: "TEXT", nullable: false),
                    HealthCheckConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveHealthChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveHealthChecks_HealthChecks_HealthCheckConfigId",
                        column: x => x.HealthCheckConfigId,
                        principalTable: "HealthChecks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PassiveHealthChecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    Policy = table.Column<string>(type: "TEXT", nullable: false),
                    ReactivationPeriod = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    HealthCheckConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassiveHealthChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassiveHealthChecks_HealthChecks_HealthCheckConfigId",
                        column: x => x.HealthCheckConfigId,
                        principalTable: "HealthChecks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HeaderMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Values = table.Column<string>(type: "TEXT", nullable: false),
                    Mode = table.Column<string>(type: "TEXT", nullable: false),
                    IsCaseSensitive = table.Column<bool>(type: "INTEGER", nullable: false),
                    MatchConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeaderMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeaderMatches_Matches_MatchConfigId",
                        column: x => x.MatchConfigId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueryParameterMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Values = table.Column<string>(type: "TEXT", nullable: false),
                    Mode = table.Column<string>(type: "TEXT", nullable: false),
                    IsCaseSensitive = table.Column<bool>(type: "INTEGER", nullable: false),
                    MatchConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryParameterMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueryParameterMatches_Matches_MatchConfigId",
                        column: x => x.MatchConfigId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveHealthChecks_HealthCheckConfigId",
                table: "ActiveHealthChecks",
                column: "HealthCheckConfigId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_RouteConfigId",
                table: "Certificates",
                column: "RouteConfigId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_ClusterConfigId",
                table: "Destinations",
                column: "ClusterConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_HeaderMatches_MatchConfigId",
                table: "HeaderMatches",
                column: "MatchConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthChecks_ClusterConfigId",
                table: "HealthChecks",
                column: "ClusterConfigId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HttpClients_ClusterConfigId",
                table: "HttpClients",
                column: "ClusterConfigId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequests_ClusterConfigId",
                table: "HttpRequests",
                column: "ClusterConfigId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RouteConfigId",
                table: "Matches",
                column: "RouteConfigId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_ClusterConfigId",
                table: "Metadata",
                column: "ClusterConfigId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_RouteConfigId",
                table: "Metadata",
                column: "RouteConfigId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PassiveHealthChecks_HealthCheckConfigId",
                table: "PassiveHealthChecks",
                column: "HealthCheckConfigId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QueryParameterMatches_MatchConfigId",
                table: "QueryParameterMatches",
                column: "MatchConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionAffinities_ClusterConfigId",
                table: "SessionAffinities",
                column: "ClusterConfigId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transforms_RouteConfigId",
                table: "Transforms",
                column: "RouteConfigId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveHealthChecks");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "HeaderMatches");

            migrationBuilder.DropTable(
                name: "HttpClients");

            migrationBuilder.DropTable(
                name: "HttpRequests");

            migrationBuilder.DropTable(
                name: "Metadata");

            migrationBuilder.DropTable(
                name: "PassiveHealthChecks");

            migrationBuilder.DropTable(
                name: "QueryParameterMatches");

            migrationBuilder.DropTable(
                name: "SessionAffinities");

            migrationBuilder.DropTable(
                name: "Transforms");

            migrationBuilder.DropTable(
                name: "HealthChecks");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Clusters");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}