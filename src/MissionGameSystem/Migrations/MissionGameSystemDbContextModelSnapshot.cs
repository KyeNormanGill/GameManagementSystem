using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MissionGameSystem.DataAccess.Models;

namespace MissionGameSystem.Migrations
{
    [DbContext(typeof(MissionGameSystemDbContext))]
    partial class MissionGameSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MissionGameSystem.DataAccess.Models.Contestant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int>("GamesWon");

                    b.Property<string>("Mood");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Contestants");
                });

            modelBuilder.Entity("MissionGameSystem.DataAccess.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("Theme");

                    b.HasKey("Id");

                    b.ToTable("Games");
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

            modelBuilder.Entity("MissionGameSystem.DataAccess.Models.Prize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Worth");

                    b.HasKey("Id");

                    b.ToTable("Prizes");
                });
        }
    }
}
