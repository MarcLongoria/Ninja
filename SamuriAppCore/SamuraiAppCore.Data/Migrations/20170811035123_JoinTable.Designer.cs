using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SamuraiAppCore.Data;

namespace SamuraiAppCore.Data.Migrations
{
    [DbContext(typeof(SamuraiContext))]
    [Migration("20170811035123_JoinTable")]
    partial class JoinTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SamuraiAppCore.Domain.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SamuraiId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Samurai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BattleId");

                    b.Property<int>("Battlefield");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BattleId");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.SamuraiBattle", b =>
                {
                    b.Property<int>("BattleID");

                    b.Property<int>("SamuraiId");

                    b.HasKey("BattleID", "SamuraiId");

                    b.HasIndex("SamuraiId");

                    b.ToTable("SamuraiBattle");
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Quote", b =>
                {
                    b.HasOne("SamuraiAppCore.Domain.Samurai", "Samurai")
                        .WithMany("Qoutes")
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Samurai", b =>
                {
                    b.HasOne("SamuraiAppCore.Domain.Battle")
                        .WithMany("Samurais")
                        .HasForeignKey("BattleId");
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.SamuraiBattle", b =>
                {
                    b.HasOne("SamuraiAppCore.Domain.Battle", "Battle")
                        .WithMany()
                        .HasForeignKey("BattleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SamuraiAppCore.Domain.Samurai", "Samurai")
                        .WithMany()
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
