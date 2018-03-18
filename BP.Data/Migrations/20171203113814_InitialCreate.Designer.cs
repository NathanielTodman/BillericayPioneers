﻿// <auto-generated />
using BP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BP.Data.Migrations
{
    [DbContext(typeof(BPContext))]
    [Migration("20171203113814_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-120")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BP.Data.Match", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AwayScore");

                    b.Property<int>("Competition");

                    b.Property<DateTime>("Date");

                    b.Property<int>("HomeScore");

                    b.Property<int>("OpositionID");

                    b.Property<bool>("PlayedAtHome");

                    b.HasKey("ID");

                    b.HasIndex("OpositionID");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("BP.Data.Performance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Appearance");

                    b.Property<int>("Assists");

                    b.Property<bool>("CleanSheet");

                    b.Property<int>("Goals");

                    b.Property<int>("GoalsConceeded");

                    b.Property<bool>("MOTM");

                    b.Property<int>("MatchID");

                    b.Property<int>("PenaltiesMissed");

                    b.Property<int>("PenaltiesSaved");

                    b.Property<int>("PlayerID");

                    b.Property<int>("Position");

                    b.Property<bool>("RedCard");

                    b.Property<int>("TotalPoints");

                    b.Property<bool>("YellowCard");

                    b.HasKey("ID");

                    b.HasIndex("MatchID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Performances");
                });

            modelBuilder.Entity("BP.Data.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("NickName");

                    b.Property<int>("Number");

                    b.HasKey("ID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BP.Data.Scoring", b =>
                {
                    b.Property<int>("Position");

                    b.Property<int>("Appearance");

                    b.Property<int>("Assist");

                    b.Property<int>("CleanSheet");

                    b.Property<int>("GoalScored");

                    b.Property<int>("MOTM");

                    b.Property<int>("PenMiss");

                    b.Property<int>("PenSave");

                    b.Property<int>("RedCard");

                    b.Property<int>("YellowCard");

                    b.HasKey("Position");

                    b.ToTable("ScoringSystem");
                });

            modelBuilder.Entity("BP.Data.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Draws");

                    b.Property<int>("GoalDifference");

                    b.Property<int>("GoalsAgainst");

                    b.Property<int>("GoalsFor");

                    b.Property<int>("Losses");

                    b.Property<int>("Points");

                    b.Property<string>("TeamName");

                    b.Property<int>("Wins");

                    b.HasKey("ID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("BP.Data.Match", b =>
                {
                    b.HasOne("BP.Data.Team", "Oposition")
                        .WithMany()
                        .HasForeignKey("OpositionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BP.Data.Performance", b =>
                {
                    b.HasOne("BP.Data.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BP.Data.Player", "Player")
                        .WithMany("Performances")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}