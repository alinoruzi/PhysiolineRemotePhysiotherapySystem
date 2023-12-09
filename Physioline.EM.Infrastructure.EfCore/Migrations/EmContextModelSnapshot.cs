﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Physioline.EM.Infrastructure.EfCore;

#nullable disable

namespace Physioline.EM.Infrastructure.EfCore.Migrations
{
    [DbContext(typeof(EmContext))]
    partial class EmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Physioline.EM.Domain.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Descriptin")
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories", "EM");
                });

            modelBuilder.Entity("Physioline.EM.Domain.Entities.Exercise", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Exercises", "EM");
                });

            modelBuilder.Entity("Physioline.EM.Domain.Entities.ExerciseCategory", b =>
                {
                    b.Property<long>("ExerciseId")
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.HasKey("ExerciseId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ExerciseCategories", "EM");
                });

            modelBuilder.Entity("Physioline.EM.Domain.Entities.Category", b =>
                {
                    b.HasOne("Physioline.EM.Domain.Entities.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Physioline.EM.Domain.Entities.Exercise", b =>
                {
                    b.OwnsOne("Physioline.EM.Domain.ValueObjects.ExerciseValueObjects.ExerciseFile", "Picture", b1 =>
                        {
                            b1.Property<long>("ExerciseId")
                                .HasColumnType("bigint");

                            b1.Property<string>("FileExtention")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ExerciseId");

                            b1.ToTable("Exercises", "EM");

                            b1.WithOwner()
                                .HasForeignKey("ExerciseId");
                        });

                    b.OwnsOne("Physioline.EM.Domain.ValueObjects.ExerciseValueObjects.ExerciseFile", "Video", b1 =>
                        {
                            b1.Property<long>("ExerciseId")
                                .HasColumnType("bigint");

                            b1.Property<string>("FileExtention")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ExerciseId");

                            b1.ToTable("Exercises", "EM");

                            b1.WithOwner()
                                .HasForeignKey("ExerciseId");
                        });

                    b.OwnsMany("Physioline.EM.Domain.ValueObjects.ExerciseValueObjects.ExerciseGuide", "Guides", b1 =>
                        {
                            b1.Property<long>("ExerciseId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"));

                            b1.Property<string>("Link")
                                .IsRequired()
                                .HasMaxLength(1500)
                                .HasColumnType("nvarchar(1500)");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.HasKey("ExerciseId", "Id");

                            b1.ToTable("ExerciseGuide", "EM");

                            b1.WithOwner()
                                .HasForeignKey("ExerciseId");
                        });

                    b.Navigation("Guides");

                    b.Navigation("Picture")
                        .IsRequired();

                    b.Navigation("Video");
                });

            modelBuilder.Entity("Physioline.EM.Domain.Entities.ExerciseCategory", b =>
                {
                    b.HasOne("Physioline.EM.Domain.Entities.Category", "Category")
                        .WithMany("ExerciseCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Physioline.EM.Domain.Entities.Exercise", "Exercise")
                        .WithMany("ExerciseCategories")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("Physioline.EM.Domain.Entities.Category", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("ExerciseCategories");
                });

            modelBuilder.Entity("Physioline.EM.Domain.Entities.Exercise", b =>
                {
                    b.Navigation("ExerciseCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
