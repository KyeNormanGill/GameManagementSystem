using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MissionGameSystem.DataAccess.Models;

namespace MissionGameSystem.Migrations
{
    [DbContext(typeof(MissionGameSystemDbContext))]
    [Migration("20161109225254_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MissionGameSystem.DataAccess.Models.Contestant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Firstname");

                    b.Property<int>("GamesWon");

                    b.Property<string>("Lastname");

                    b.Property<string>("Mood");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Contestants");
                });

            modelBuilder.Entity("MissionGameSystem.DataAccess.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Prize");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Theme");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("MissionGameSystem.DataAccess.Models.Game_Contestant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContestandId");

                    b.Property<int?>("ContestantId");

                    b.Property<int>("GameId");

                    b.HasKey("Id");

                    b.HasIndex("ContestantId");

                    b.HasIndex("GameId");

                    b.ToTable("Game_Contestant");
                });

            modelBuilder.Entity("MissionGameSystem.DataAccess.Models.Game_Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<int>("MissionId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("MissionId");

                    b.ToTable("Game_Mission");
                });

            modelBuilder.Entity("MissionGameSystem.DataAccess.Models.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Note");

                    b.Property<int>("RewardPoints");

                    b.HasKey("Id");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("MissionGameSystem.DataAccess.Models.Game_Contestant", b =>
                {
                    b.HasOne("MissionGameSystem.DataAccess.Models.Contestant", "Contestant")
                        .WithMany()
                        .HasForeignKey("ContestantId");

                    b.HasOne("MissionGameSystem.DataAccess.Models.Game", "Game")
                        .WithMany("Game_Contestants")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MissionGameSystem.DataAccess.Models.Game_Mission", b =>
                {
                    b.HasOne("MissionGameSystem.DataAccess.Models.Game", "Game")
                        .WithMany("Game_Missions")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MissionGameSystem.DataAccess.Models.Mission", "Mission")
                        .WithMany()
                        .HasForeignKey("MissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
