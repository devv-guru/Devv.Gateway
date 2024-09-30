﻿// <auto-generated />
using System;
using Devv.Gateway.Data.Contexts.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Devv.Gateway.Data.Contexts.SqlServer.Migrations
{
    [DbContext(typeof(SqlServerWriteOnlyContext))]
    [Migration("20240930130212_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Devv.Gateway.Data.Entities.ActiveHealthCheck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<Guid>("HealthCheckConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan?>("Interval")
                        .IsRequired()
                        .HasColumnType("time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Policy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Query")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("Timeout")
                        .HasColumnType("time");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HealthCheckConfigId")
                        .IsUnique();

                    b.ToTable("ActiveHealthChecks", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Certificate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AwsCertificateName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("AwsCertificatePasswordName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("AwsRegion")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CertificateSource")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KeyVaultCertificateName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("KeyVaultCertificatePasswordName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("KeyVaultName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("KeyVaultUri")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SubjectAlternativeNames")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Certificates", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Cluster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LoadBalancingPolicy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HostId")
                        .IsUnique();

                    b.ToTable("Clusters", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Destination", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ClusterConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Health")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClusterConfigId");

                    b.ToTable("Destinations", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.HeaderMatch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCaseSensitive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("MatchConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Values")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MatchConfigId");

                    b.ToTable("HeaderMatches", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.HealthCheck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClusterConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClusterConfigId")
                        .IsUnique();

                    b.ToTable("HealthChecks", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.HttpClientSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClusterConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DangerousAcceptAnyServerCertificate")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EnableMultipleHttp2Connections")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaxConnectionsPerServer")
                        .HasColumnType("int");

                    b.Property<string>("RequestHeaderEncoding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponseHeaderEncoding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SslProtocols")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClusterConfigId")
                        .IsUnique();

                    b.ToTable("HttpClientSettings", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.HttpRequestSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("ActivityTimeout")
                        .HasColumnType("time");

                    b.Property<bool>("AllowResponseBuffering")
                        .HasColumnType("bit");

                    b.Property<Guid>("ClusterConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VersionPolicy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClusterConfigId")
                        .IsUnique();

                    b.ToTable("HttpRequestSettings", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hosts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Methods")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RouteConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RouteConfigId")
                        .IsUnique();

                    b.ToTable("Matches", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Metadata", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClusterConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("RouteConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClusterConfigId")
                        .IsUnique()
                        .HasFilter("[ClusterConfigId] IS NOT NULL");

                    b.ToTable("Metadata", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.PassiveHealthCheck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<Guid>("HealthCheckConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Policy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("ReactivationPeriod")
                        .HasColumnType("time");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HealthCheckConfigId")
                        .IsUnique();

                    b.ToTable("PassiveHealthChecks", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.QueryParameterMatch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCaseSensitive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("MatchConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Values")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MatchConfigId");

                    b.ToTable("QueryParameterMatches", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Route", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorizationPolicy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("ClusterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CorsPolicy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("MaxRequestBodySize")
                        .HasColumnType("bigint");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HostId");

                    b.ToTable("Routes", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.SessionAffinity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClusterConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("FailurePolicy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Policy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Settings")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClusterConfigId")
                        .IsUnique();

                    b.ToTable("SessionAffinity", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Transform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RequestHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RouteConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Set")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RouteConfigId");

                    b.ToTable("Transforms", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.WebHost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CertificateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClusterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("HostName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CertificateId");

                    b.ToTable("WebHosts", (string)null);
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.ActiveHealthCheck", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.HealthCheck", "HealthCheckConfig")
                        .WithOne("Active")
                        .HasForeignKey("Devv.Gateway.Data.Entities.ActiveHealthCheck", "HealthCheckConfigId");

                    b.Navigation("HealthCheckConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Cluster", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.WebHost", "Host")
                        .WithOne("Cluster")
                        .HasForeignKey("Devv.Gateway.Data.Entities.Cluster", "HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Host");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Destination", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.Cluster", "ClusterConfig")
                        .WithMany("Destinations")
                        .HasForeignKey("ClusterConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClusterConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.HeaderMatch", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.Match", "MatchConfig")
                        .WithMany("Headers")
                        .HasForeignKey("MatchConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MatchConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.HealthCheck", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.Cluster", "ClusterConfig")
                        .WithOne("HealthCheck")
                        .HasForeignKey("Devv.Gateway.Data.Entities.HealthCheck", "ClusterConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClusterConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.HttpClientSettings", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.Cluster", "ClusterConfig")
                        .WithOne("HttpClient")
                        .HasForeignKey("Devv.Gateway.Data.Entities.HttpClientSettings", "ClusterConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClusterConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.HttpRequestSettings", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.Cluster", "ClusterConfig")
                        .WithOne("HttpRequest")
                        .HasForeignKey("Devv.Gateway.Data.Entities.HttpRequestSettings", "ClusterConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClusterConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Match", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.Route", "Route")
                        .WithOne("Match")
                        .HasForeignKey("Devv.Gateway.Data.Entities.Match", "RouteConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Metadata", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.Cluster", "Cluster")
                        .WithOne("Metadata")
                        .HasForeignKey("Devv.Gateway.Data.Entities.Metadata", "ClusterConfigId");

                    b.HasOne("Devv.Gateway.Data.Entities.Route", "Route")
                        .WithOne("Metadata")
                        .HasForeignKey("Devv.Gateway.Data.Entities.Metadata", "ClusterConfigId");

                    b.Navigation("Cluster");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.PassiveHealthCheck", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.HealthCheck", "HealthCheckConfig")
                        .WithOne("Passive")
                        .HasForeignKey("Devv.Gateway.Data.Entities.PassiveHealthCheck", "HealthCheckConfigId");

                    b.Navigation("HealthCheckConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.QueryParameterMatch", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.Match", "Match")
                        .WithMany("QueryParameters")
                        .HasForeignKey("MatchConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Route", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.WebHost", "Host")
                        .WithMany("Routes")
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Host");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.SessionAffinity", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.Cluster", "ClusterConfig")
                        .WithOne("SessionAffinity")
                        .HasForeignKey("Devv.Gateway.Data.Entities.SessionAffinity", "ClusterConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClusterConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Transform", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.Route", "RouteConfig")
                        .WithMany("Transforms")
                        .HasForeignKey("RouteConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RouteConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.WebHost", b =>
                {
                    b.HasOne("Devv.Gateway.Data.Entities.Certificate", "Certificate")
                        .WithMany("Hosts")
                        .HasForeignKey("CertificateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Certificate");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Certificate", b =>
                {
                    b.Navigation("Hosts");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Cluster", b =>
                {
                    b.Navigation("Destinations");

                    b.Navigation("HealthCheck");

                    b.Navigation("HttpClient");

                    b.Navigation("HttpRequest");

                    b.Navigation("Metadata");

                    b.Navigation("SessionAffinity");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.HealthCheck", b =>
                {
                    b.Navigation("Active");

                    b.Navigation("Passive");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Match", b =>
                {
                    b.Navigation("Headers");

                    b.Navigation("QueryParameters");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.Route", b =>
                {
                    b.Navigation("Match");

                    b.Navigation("Metadata");

                    b.Navigation("Transforms");
                });

            modelBuilder.Entity("Devv.Gateway.Data.Entities.WebHost", b =>
                {
                    b.Navigation("Cluster");

                    b.Navigation("Routes");
                });
#pragma warning restore 612, 618
        }
    }
}