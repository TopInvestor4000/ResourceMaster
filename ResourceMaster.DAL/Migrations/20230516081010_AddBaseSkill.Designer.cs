﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ResourceMaster.DAL.Data;

#nullable disable

namespace ResourceMaster.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230516081010_AddBaseSkill")]
    partial class AddBaseSkill
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ResourceMaster.DAL.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ResourceMaster.DAL.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("ProjectEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("ProjectStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ResourceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ResourceId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ResourceMaster.DAL.Models.ProjectSkill", b =>
                {
                    b.Property<int>("ProjectSkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProjectSkillId"));

                    b.Property<bool>("IsCertification")
                        .HasColumnType("boolean");

                    b.Property<string>("Necessity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("RequiredWorkHours")
                        .HasColumnType("integer");

                    b.Property<int>("SkillId")
                        .HasColumnType("integer");

                    b.Property<string>("SkillLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProjectSkillId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SkillId");

                    b.ToTable("ProjectSkills");
                });

            modelBuilder.Entity("ResourceMaster.DAL.Models.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("ResourceMaster.DAL.Models.ResourceProject", b =>
                {
                    b.Property<int>("ResourceProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ResourceProjectId"));

                    b.Property<DateTimeOffset>("BookedFrom")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("BookedTo")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("ResourceId")
                        .HasColumnType("integer");

                    b.HasKey("ResourceProjectId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ResourceId");

                    b.ToTable("ResourceProjects");
                });

            modelBuilder.Entity("ResourceMaster.DAL.Models.ResourceSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCertification")
                        .HasColumnType("boolean");

                    b.Property<int>("ResourceId")
                        .HasColumnType("integer");

                    b.Property<int>("SkillId")
                        .HasColumnType("integer");

                    b.Property<string>("SkillLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.HasIndex("SkillId");

                    b.ToTable("ResourceSkills");
                });

            modelBuilder.Entity("ResourceMaster.DAL.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("ResourceMaster.DAL.Models.Project", b =>
                {
                    b.HasOne("ResourceMaster.DAL.Models.Customer", "Customer")
                        .WithMany("Project")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResourceMaster.DAL.Models.Resource", null)
                        .WithMany("Projects")
                        .HasForeignKey("ResourceId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ResourceMaster.DAL.Models.ProjectSkill", b =>
                {
                    b.HasOne("ResourceMaster.DAL.Models.Project", "Project")
                        .WithMany("Skill")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResourceMaster.DAL.Models.Skill", "Skill")
                        .WithMany("ProjectSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("ResourceMaster.DAL.Models.ResourceProject", b =>
                {
                    b.HasOne("ResourceMaster.DAL.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResourceMaster.DAL.Models.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("ResourceMaster.DAL.Models.ResourceSkill", b =>
                {
                    b.HasOne("ResourceMaster.DAL.Models.Resource", "Resource")
                        .WithMany("Skills")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResourceMaster.DAL.Models.Skill", "Skill")
                        .WithMany("ResourceSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("ResourceMaster.DAL.Models.Customer", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("ResourceMaster.DAL.Models.Project", b =>
                {
                    b.Navigation("Skill");
                });

            modelBuilder.Entity("ResourceMaster.DAL.Models.Resource", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("ResourceMaster.DAL.Models.Skill", b =>
                {
                    b.Navigation("ProjectSkills");

                    b.Navigation("ResourceSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
