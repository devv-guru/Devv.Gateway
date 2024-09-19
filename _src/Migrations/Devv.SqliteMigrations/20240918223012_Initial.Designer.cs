﻿// <auto-generated />

#nullable disable

using Devv.Gateway.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Devv.SqliteMigrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240918223012_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.ActiveHealthCheckConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HealthCheckConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("Interval")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Policy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Query")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Timeout")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HealthCheckConfigId")
                        .IsUnique();

                    b.ToTable("ActiveHealthChecks");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.CertificateConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AwsRegion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AwsSecretName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KeyVaultName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KeyVaultSecretName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KeyVaultUri")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("LocalPath")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("RouteConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SourceType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RouteConfigId")
                        .IsUnique();

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.ClusterConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClusterId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LoadBalancingPolicy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clusters");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.DestinationConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ClusterConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DestinationId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Health")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClusterConfigId");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.HeaderMatchConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCaseSensitive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Values")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MatchConfigId");

                    b.ToTable("HeaderMatches");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.HealthCheckConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClusterConfigId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClusterConfigId")
                        .IsUnique();

                    b.ToTable("HealthChecks");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.HttpClientConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClusterConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DangerousAcceptAnyServerCertificate")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EnableMultipleHttp2Connections")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxConnectionsPerServer")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RequestHeaderEncoding")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ResponseHeaderEncoding")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SslProtocols")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClusterConfigId")
                        .IsUnique();

                    b.ToTable("HttpClients");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.HttpRequestConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("ActivityTimeout")
                        .HasColumnType("TEXT");

                    b.Property<bool>("AllowResponseBuffering")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClusterConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VersionPolicy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClusterConfigId")
                        .IsUnique();

                    b.ToTable("HttpRequests");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.MatchConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hosts")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Methods")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RouteConfigId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RouteConfigId")
                        .IsUnique();

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.MetadataConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClusterConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RouteConfigId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClusterConfigId")
                        .IsUnique();

                    b.HasIndex("RouteConfigId")
                        .IsUnique();

                    b.ToTable("Metadata");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.PassiveHealthCheckConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HealthCheckConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Policy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("ReactivationPeriod")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HealthCheckConfigId")
                        .IsUnique();

                    b.ToTable("PassiveHealthChecks");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.QueryParameterMatchConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCaseSensitive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Values")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MatchConfigId");

                    b.ToTable("QueryParameterMatches");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.RouteConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AuthorizationPolicy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClusterId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CorsPolicy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("MaxRequestBodySize")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RouteId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.SessionAffinityConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClusterConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FailurePolicy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Policy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Settings")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClusterConfigId")
                        .IsUnique();

                    b.ToTable("SessionAffinities");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.TransformConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RequestHeader")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RouteConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Set")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RouteConfigId");

                    b.ToTable("Transforms");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.ActiveHealthCheckConfig", b =>
                {
                    b.HasOne("Devv.Gateway.Api.Data.Entities.HealthCheckConfig", "HealthCheckConfig")
                        .WithOne("Active")
                        .HasForeignKey("Devv.Gateway.Api.Data.Entities.ActiveHealthCheckConfig", "HealthCheckConfigId");

                    b.Navigation("HealthCheckConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.CertificateConfig", b =>
                {
                    b.HasOne("Devv.Gateway.Api.Data.Entities.RouteConfig", "RouteConfig")
                        .WithOne("Certificate")
                        .HasForeignKey("Devv.Gateway.Api.Data.Entities.CertificateConfig", "RouteConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RouteConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.DestinationConfig", b =>
                {
                    b.HasOne("Devv.Gateway.Api.Data.Entities.ClusterConfig", "ClusterConfig")
                        .WithMany("Destinations")
                        .HasForeignKey("ClusterConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClusterConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.HeaderMatchConfig", b =>
                {
                    b.HasOne("Devv.Gateway.Api.Data.Entities.MatchConfig", "MatchConfig")
                        .WithMany("Headers")
                        .HasForeignKey("MatchConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MatchConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.HealthCheckConfig", b =>
                {
                    b.HasOne("Devv.Gateway.Api.Data.Entities.ClusterConfig", "ClusterConfig")
                        .WithOne("HealthCheck")
                        .HasForeignKey("Devv.Gateway.Api.Data.Entities.HealthCheckConfig", "ClusterConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClusterConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.HttpClientConfig", b =>
                {
                    b.HasOne("Devv.Gateway.Api.Data.Entities.ClusterConfig", "ClusterConfig")
                        .WithOne("HttpClient")
                        .HasForeignKey("Devv.Gateway.Api.Data.Entities.HttpClientConfig", "ClusterConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClusterConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.HttpRequestConfig", b =>
                {
                    b.HasOne("Devv.Gateway.Api.Data.Entities.ClusterConfig", "ClusterConfig")
                        .WithOne("HttpRequest")
                        .HasForeignKey("Devv.Gateway.Api.Data.Entities.HttpRequestConfig", "ClusterConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClusterConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.MatchConfig", b =>
                {
                    b.HasOne("Devv.Gateway.Api.Data.Entities.RouteConfig", "RouteConfig")
                        .WithOne("Match")
                        .HasForeignKey("Devv.Gateway.Api.Data.Entities.MatchConfig", "RouteConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RouteConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.MetadataConfig", b =>
                {
                    b.HasOne("Devv.Gateway.Api.Data.Entities.ClusterConfig", "ClusterConfig")
                        .WithOne("Metadata")
                        .HasForeignKey("Devv.Gateway.Api.Data.Entities.MetadataConfig", "ClusterConfigId");

                    b.HasOne("Devv.Gateway.Api.Data.Entities.RouteConfig", "RouteConfig")
                        .WithOne("Metadata")
                        .HasForeignKey("Devv.Gateway.Api.Data.Entities.MetadataConfig", "RouteConfigId");

                    b.Navigation("ClusterConfig");

                    b.Navigation("RouteConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.PassiveHealthCheckConfig", b =>
                {
                    b.HasOne("Devv.Gateway.Api.Data.Entities.HealthCheckConfig", "HealthCheckConfig")
                        .WithOne("Passive")
                        .HasForeignKey("Devv.Gateway.Api.Data.Entities.PassiveHealthCheckConfig", "HealthCheckConfigId");

                    b.Navigation("HealthCheckConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.QueryParameterMatchConfig", b =>
                {
                    b.HasOne("Devv.Gateway.Api.Data.Entities.MatchConfig", "MatchConfig")
                        .WithMany("QueryParameters")
                        .HasForeignKey("MatchConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MatchConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.SessionAffinityConfig", b =>
                {
                    b.HasOne("Devv.Gateway.Api.Data.Entities.ClusterConfig", "ClusterConfig")
                        .WithOne("SessionAffinity")
                        .HasForeignKey("Devv.Gateway.Api.Data.Entities.SessionAffinityConfig", "ClusterConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClusterConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.TransformConfig", b =>
                {
                    b.HasOne("Devv.Gateway.Api.Data.Entities.RouteConfig", "RouteConfig")
                        .WithMany("Transforms")
                        .HasForeignKey("RouteConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RouteConfig");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.ClusterConfig", b =>
                {
                    b.Navigation("Destinations");

                    b.Navigation("HealthCheck")
                        .IsRequired();

                    b.Navigation("HttpClient")
                        .IsRequired();

                    b.Navigation("HttpRequest")
                        .IsRequired();

                    b.Navigation("Metadata")
                        .IsRequired();

                    b.Navigation("SessionAffinity")
                        .IsRequired();
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.HealthCheckConfig", b =>
                {
                    b.Navigation("Active");

                    b.Navigation("Passive");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.MatchConfig", b =>
                {
                    b.Navigation("Headers");

                    b.Navigation("QueryParameters");
                });

            modelBuilder.Entity("Devv.Gateway.Api.Data.Entities.RouteConfig", b =>
                {
                    b.Navigation("Certificate")
                        .IsRequired();

                    b.Navigation("Match")
                        .IsRequired();

                    b.Navigation("Metadata")
                        .IsRequired();

                    b.Navigation("Transforms");
                });
#pragma warning restore 612, 618
        }
    }
}
