﻿// <auto-generated />
using System;
using FinalProjectV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalProjectV2.Migrations
{
    [DbContext(typeof(FinalProjectV2Context))]
    [Migration("20191003211427_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinalProjectV2.Models.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminName");

                    b.Property<string>("ManagingTournament");

                    b.HasKey("ID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("FinalProjectV2.Models.Match", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location");

                    b.Property<string>("MatchName");

                    b.Property<int>("TournamentId");

                    b.Property<string>("TournamentName");

                    b.HasKey("ID");

                    b.HasIndex("TournamentId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("FinalProjectV2.Models.Tournament", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminId");

                    b.Property<string>("Location");

                    b.Property<DateTime>("TournamentEndDate");

                    b.Property<string>("TournamentName");

                    b.Property<DateTime>("TournamentStartDate");

                    b.Property<bool>("isActive");

                    b.HasKey("ID");

                    b.HasIndex("AdminId");

                    b.ToTable("Tournament");
                });

            modelBuilder.Entity("FinalProjectV2.Models.Match", b =>
                {
                    b.HasOne("FinalProjectV2.Models.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinalProjectV2.Models.Tournament", b =>
                {
                    b.HasOne("FinalProjectV2.Models.Admin", "Admin")
                        .WithMany("Tournaments")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
