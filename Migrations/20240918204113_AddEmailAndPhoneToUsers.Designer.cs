﻿// <auto-generated />
using System;
using Inzynieria_oprogramowania_API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Inzynieria_oprogramowania_API.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20240918204113_AddEmailAndPhoneToUsers")]
    partial class AddEmailAndPhoneToUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Inzynieria_oprogramowania_API.Data_Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Inzynieria_oprogramowania_API.Data_Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LikesDown")
                        .HasColumnType("integer");

                    b.Property<int>("LikesUp")
                        .HasColumnType("integer");

                    b.Property<int>("PinId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Zdjecia")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("ID");

                    b.HasIndex("PinId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Inzynieria_oprogramowania_API.Data_Models.Option", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("OptionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Inzynieria_oprogramowania_API.Data_Models.Pin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<int>("LikesDown")
                        .HasColumnType("integer");

                    b.Property<int>("LikesUp")
                        .HasColumnType("integer");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<int>("PostTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Zdjecia")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("ID");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PostTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Pins");
                });

            modelBuilder.Entity("Inzynieria_oprogramowania_API.Data_Models.PostType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("PostTypes");
                });

            modelBuilder.Entity("Inzynieria_oprogramowania_API.Data_Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OptionId")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("OptionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Inzynieria_oprogramowania_API.Data_Models.Comment", b =>
                {
                    b.HasOne("Inzynieria_oprogramowania_API.Data_Models.Pin", "Pin")
                        .WithMany("Comments")
                        .HasForeignKey("PinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inzynieria_oprogramowania_API.Data_Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Inzynieria_oprogramowania_API.Data_Models.Pin", b =>
                {
                    b.HasOne("Inzynieria_oprogramowania_API.Data_Models.Category", "Category")
                        .WithMany("Pins")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Inzynieria_oprogramowania_API.Data_Models.PostType", "PostType")
                        .WithMany("Pins")
                        .HasForeignKey("PostTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Inzynieria_oprogramowania_API.Data_Models.User", "User")
                        .WithMany("Pins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("PostType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Inzynieria_oprogramowania_API.Data_Models.User", b =>
                {
                    b.HasOne("Inzynieria_oprogramowania_API.Data_Models.Option", "Option")
                        .WithMany("Users")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Option");
                });

            modelBuilder.Entity("Inzynieria_oprogramowania_API.Data_Models.Category", b =>
                {
                    b.Navigation("Pins");
                });

            modelBuilder.Entity("Inzynieria_oprogramowania_API.Data_Models.Option", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Inzynieria_oprogramowania_API.Data_Models.Pin", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Inzynieria_oprogramowania_API.Data_Models.PostType", b =>
                {
                    b.Navigation("Pins");
                });

            modelBuilder.Entity("Inzynieria_oprogramowania_API.Data_Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Pins");
                });
#pragma warning restore 612, 618
        }
    }
}
