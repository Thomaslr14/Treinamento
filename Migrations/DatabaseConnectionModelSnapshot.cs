﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Treinamento.Database;

namespace Treinamento.Migrations
{
    [DbContext(typeof(DatabaseConnection))]
    partial class DatabaseConnectionModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Treinamento.Database.Salt", b =>
                {
                    b.Property<int>("SaltID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("SaltUser")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("SaltID");

                    b.ToTable("SALTS");
                });

            modelBuilder.Entity("Treinamento.Database.Users", b =>
                {
                    b.Property<int>("UsersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("SaltID_FK")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UsersID");

                    b.HasIndex("SaltID_FK");

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("Treinamento.Database.Users", b =>
                {
                    b.HasOne("Treinamento.Database.Salt", "Salt")
                        .WithMany("Users")
                        .HasForeignKey("SaltID_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salt");
                });

            modelBuilder.Entity("Treinamento.Database.Salt", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
