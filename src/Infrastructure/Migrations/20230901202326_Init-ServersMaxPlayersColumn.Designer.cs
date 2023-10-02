﻿// <auto-generated />
using System;
using System.Collections.Generic;
using BanHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BanHub.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230901202326_Init-ServersMaxPlayersColumn")]
    partial class InitServersMaxPlayersColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "hstore");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFAlias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("EFAliases", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Created = new DateTimeOffset(new DateTime(2023, 9, 1, 20, 23, 26, 385, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 0, 0, 0, 0)),
                            IpAddress = "0.0.0.0",
                            PlayerId = -1,
                            UserName = "IW4MAdmin"
                        });
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFAuthToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Expiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Used")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("EFAuthTokens", (string)null);
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFChat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CommunityId")
                        .HasColumnType("integer");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("ServerId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Submitted")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CommunityId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("ServerId");

                    b.ToTable("EFChats", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CommunityId = -1,
                            Message = "Seed Chat",
                            PlayerId = -1,
                            ServerId = -1,
                            Submitted = new DateTimeOffset(new DateTime(2023, 9, 1, 20, 23, 26, 385, DateTimeKind.Unspecified).AddTicks(6745), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFChatSentiment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatCount")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("LastChatCalculated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<float>("Sentiment")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("EFChatSentiments", (string)null);
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFCommunity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("About")
                        .HasColumnType("text");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ApiKey")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CommunityGuid")
                        .HasColumnType("uuid");

                    b.Property<string>("CommunityIp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CommunityIpFriendly")
                        .HasColumnType("text");

                    b.Property<string>("CommunityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CommunityPort")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("HeartBeat")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Dictionary<string, string>>("Socials")
                        .HasColumnType("hstore");

                    b.HasKey("Id");

                    b.ToTable("EFCommunities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            About = "Some description about the instance.",
                            Active = true,
                            ApiKey = new Guid("aa85fe95-cc9b-46eb-b3c8-04661f8c9f2c"),
                            CommunityGuid = new Guid("353fd886-7ea1-4067-825c-191d087f55eb"),
                            CommunityIp = "123.123.123.123",
                            CommunityIpFriendly = "zombo.com",
                            CommunityName = "Seed Instance",
                            CommunityPort = 1624,
                            Created = new DateTimeOffset(new DateTime(2023, 9, 1, 20, 23, 26, 385, DateTimeKind.Unspecified).AddTicks(6723), new TimeSpan(0, 0, 0, 0, 0)),
                            HeartBeat = new DateTimeOffset(new DateTime(2023, 9, 1, 20, 23, 26, 385, DateTimeKind.Unspecified).AddTicks(6721), new TimeSpan(0, 0, 0, 0, 0)),
                            Socials = new Dictionary<string, string> { ["YouTube"] = "https://www.youtube.com/watch?v=dQw4w9WgXcQ", ["Another YouTube"] = "https://www.youtube.com/watch?v=sFce1pBvSd4" }
                        });
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFCurrentAlias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AliasId")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AliasId");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("EFCurrentAliases", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AliasId = -1,
                            PlayerId = -1
                        });
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("boolean");

                    b.Property<int>("IssuerId")
                        .HasColumnType("integer");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("NoteGuid")
                        .HasColumnType("uuid");

                    b.Property<int>("RecipientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IssuerId");

                    b.HasIndex("RecipientId");

                    b.ToTable("EFNotes", (string)null);
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFPenalty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Automated")
                        .HasColumnType("boolean");

                    b.Property<int>("CommunityId")
                        .HasColumnType("integer");

                    b.Property<string>("Evidence")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("Expiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IssuerId")
                        .HasColumnType("integer");

                    b.Property<Guid>("PenaltyGuid")
                        .HasColumnType("uuid");

                    b.Property<int>("PenaltyScope")
                        .HasColumnType("integer");

                    b.Property<int>("PenaltyStatus")
                        .HasColumnType("integer");

                    b.Property<int>("PenaltyType")
                        .HasColumnType("integer");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RecipientId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Submitted")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CommunityId");

                    b.HasIndex("IssuerId");

                    b.HasIndex("RecipientId");

                    b.ToTable("EFPenalties", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Automated = true,
                            CommunityId = -1,
                            Evidence = "WePNs-G7puA",
                            IssuerId = -1,
                            PenaltyGuid = new Guid("f83d05b3-e49f-4416-8e49-63e145e1beb4"),
                            PenaltyScope = 20,
                            PenaltyStatus = 10,
                            PenaltyType = 8,
                            Reason = "Seed Infraction",
                            RecipientId = -1,
                            Submitted = new DateTimeOffset(new DateTime(2023, 9, 1, 20, 23, 26, 385, DateTimeKind.Unspecified).AddTicks(6740), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFPenaltyIdentifier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Expiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Identity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PenaltyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PenaltyId")
                        .IsUnique();

                    b.ToTable("EFPenaltyIdentifiers", (string)null);
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CommunityRole")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("Heartbeat")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Identity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("PlayTime")
                        .HasColumnType("interval");

                    b.Property<int>("TotalConnections")
                        .HasColumnType("integer");

                    b.Property<int>("WebRole")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("EFPlayers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CommunityRole = 10,
                            Created = new DateTimeOffset(new DateTime(2023, 9, 1, 20, 23, 26, 385, DateTimeKind.Unspecified).AddTicks(6457), new TimeSpan(0, 0, 0, 0, 0)),
                            Heartbeat = new DateTimeOffset(new DateTime(2023, 9, 1, 20, 23, 26, 385, DateTimeKind.Unspecified).AddTicks(6456), new TimeSpan(0, 0, 0, 0, 0)),
                            Identity = "0:UKN",
                            PlayTime = new TimeSpan(0, 0, 0, 0, 0),
                            TotalConnections = 0,
                            WebRole = 10
                        });
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CommunityId")
                        .HasColumnType("integer");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("integer");

                    b.Property<int>("ServerGame")
                        .HasColumnType("integer");

                    b.Property<string>("ServerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ServerIp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ServerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ServerPort")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CommunityId");

                    b.ToTable("EFServers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CommunityId = -1,
                            MaxPlayers = 0,
                            ServerGame = 0,
                            ServerId = "123.123.123.123:123",
                            ServerIp = "123.123.123.123",
                            ServerName = "Shef",
                            ServerPort = 123,
                            Updated = new DateTimeOffset(new DateTime(2023, 9, 1, 20, 23, 26, 385, DateTimeKind.Unspecified).AddTicks(6754), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFServerConnection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Connected")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("ServerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("ServerId");

                    b.ToTable("EFServerConnections", (string)null);
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFTomatoCounter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("Tomatoes")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("EFTomatoCounters", (string)null);
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFAlias", b =>
                {
                    b.HasOne("BanHub.WebCore.Server.Domains.EFPlayer", "Player")
                        .WithMany("Aliases")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFAuthToken", b =>
                {
                    b.HasOne("BanHub.WebCore.Server.Domains.EFPlayer", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFChat", b =>
                {
                    b.HasOne("BanHub.WebCore.Server.Domains.EFCommunity", "Community")
                        .WithMany()
                        .HasForeignKey("CommunityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BanHub.WebCore.Server.Domains.EFPlayer", "Player")
                        .WithMany("Chats")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BanHub.WebCore.Server.Domains.EFServer", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Community");

                    b.Navigation("Player");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFChatSentiment", b =>
                {
                    b.HasOne("BanHub.WebCore.Server.Domains.EFPlayer", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFCurrentAlias", b =>
                {
                    b.HasOne("BanHub.WebCore.Server.Domains.EFAlias", "Alias")
                        .WithMany()
                        .HasForeignKey("AliasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BanHub.WebCore.Server.Domains.EFPlayer", "Player")
                        .WithOne("CurrentAlias")
                        .HasForeignKey("BanHub.WebCore.Server.Domains.EFCurrentAlias", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alias");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFNote", b =>
                {
                    b.HasOne("BanHub.WebCore.Server.Domains.EFPlayer", "Issuer")
                        .WithMany()
                        .HasForeignKey("IssuerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BanHub.WebCore.Server.Domains.EFPlayer", "Recipient")
                        .WithMany("Notes")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issuer");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFPenalty", b =>
                {
                    b.HasOne("BanHub.WebCore.Server.Domains.EFCommunity", "Community")
                        .WithMany()
                        .HasForeignKey("CommunityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BanHub.WebCore.Server.Domains.EFPlayer", "Issuer")
                        .WithMany()
                        .HasForeignKey("IssuerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BanHub.WebCore.Server.Domains.EFPlayer", "Recipient")
                        .WithMany("Penalties")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Community");

                    b.Navigation("Issuer");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFPenaltyIdentifier", b =>
                {
                    b.HasOne("BanHub.WebCore.Server.Domains.EFPenalty", "Penalty")
                        .WithOne("Identifier")
                        .HasForeignKey("BanHub.WebCore.Server.Domains.EFPenaltyIdentifier", "PenaltyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Penalty");
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFServer", b =>
                {
                    b.HasOne("BanHub.WebCore.Server.Domains.EFCommunity", "Community")
                        .WithMany("ServerConnections")
                        .HasForeignKey("CommunityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Community");
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFServerConnection", b =>
                {
                    b.HasOne("BanHub.WebCore.Server.Domains.EFPlayer", "Player")
                        .WithMany("ServerConnections")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BanHub.WebCore.Server.Domains.EFServer", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFTomatoCounter", b =>
                {
                    b.HasOne("BanHub.WebCore.Server.Domains.EFPlayer", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFCommunity", b =>
                {
                    b.Navigation("ServerConnections");
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFPenalty", b =>
                {
                    b.Navigation("Identifier");
                });

            modelBuilder.Entity("BanHub.WebCore.Server.Domains.EFPlayer", b =>
                {
                    b.Navigation("Aliases");

                    b.Navigation("Chats");

                    b.Navigation("CurrentAlias")
                        .IsRequired();

                    b.Navigation("Notes");

                    b.Navigation("Penalties");

                    b.Navigation("ServerConnections");
                });
#pragma warning restore 612, 618
        }
    }
}
