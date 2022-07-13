﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Database;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(RTSContext))]
    [Migration("20220712140915_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("backend.Database.Models.AttributeDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("DriverValid")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LapValid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("RaceDriverValid")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RaceValid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AttributeDefinitions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("54a85f54-e87e-4b98-a2fd-a57dd2ab4df0"),
                            Description = "The team the driver belongs to",
                            DriverValid = true,
                            LapValid = false,
                            Name = "Team",
                            RaceDriverValid = true,
                            RaceValid = false,
                            Type = "SingleLineOfText"
                        });
                });

            modelBuilder.Entity("backend.Database.Models.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("User")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8f9c7d3a-fae0-4570-a619-67d26f070ff5"),
                            Name = "Driver 1",
                            User = new Guid("8044f000-95ee-4fd9-9707-4ee9737af0cf")
                        },
                        new
                        {
                            Id = new Guid("d6a9074d-5eb0-4fef-a16e-a024f14edfca"),
                            Name = "Driver 2",
                            User = new Guid("d77eeabb-adb5-440b-88b4-d3af56a7fbb2")
                        },
                        new
                        {
                            Id = new Guid("6a4bc4bb-fa80-45fa-aace-4865837e928a"),
                            Name = "Driver 3",
                            User = new Guid("46733858-a61e-4d98-8a68-23fbf3849ad2")
                        });
                });

            modelBuilder.Entity("backend.Database.Models.DriverAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DefinitionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DefinitionId");

                    b.HasIndex("DriverId");

                    b.ToTable("DriverAttributes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1c537108-3001-43db-9fd5-b00fed55bdcb"),
                            DefinitionId = new Guid("54a85f54-e87e-4b98-a2fd-a57dd2ab4df0"),
                            DriverId = new Guid("8f9c7d3a-fae0-4570-a619-67d26f070ff5"),
                            Value = "Team1"
                        },
                        new
                        {
                            Id = new Guid("101d496f-acfd-42e8-912c-632593ba0d03"),
                            DefinitionId = new Guid("54a85f54-e87e-4b98-a2fd-a57dd2ab4df0"),
                            DriverId = new Guid("d6a9074d-5eb0-4fef-a16e-a024f14edfca"),
                            Value = "Team2"
                        },
                        new
                        {
                            Id = new Guid("fd669999-4245-48b0-9ab9-1bd7e13f7a02"),
                            DefinitionId = new Guid("54a85f54-e87e-4b98-a2fd-a57dd2ab4df0"),
                            DriverId = new Guid("6a4bc4bb-fa80-45fa-aace-4865837e928a"),
                            Value = "Team3"
                        });
                });

            modelBuilder.Entity("backend.Database.Models.DriverTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TagId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("TagId");

                    b.ToTable("DriverTags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("889a5af0-e848-42e0-b9a9-554428ba53e0"),
                            DriverId = new Guid("8f9c7d3a-fae0-4570-a619-67d26f070ff5"),
                            TagId = new Guid("b34104e1-efd8-46ec-80f3-b732f8aa6d75")
                        },
                        new
                        {
                            Id = new Guid("cbb0efdc-eda1-4c3b-a50e-8f02550e2006"),
                            DriverId = new Guid("d6a9074d-5eb0-4fef-a16e-a024f14edfca"),
                            TagId = new Guid("b34104e1-efd8-46ec-80f3-b732f8aa6d75")
                        },
                        new
                        {
                            Id = new Guid("f6818e9f-37fc-483e-8afd-8be3f7fab5c5"),
                            DriverId = new Guid("6a4bc4bb-fa80-45fa-aace-4865837e928a"),
                            TagId = new Guid("b34104e1-efd8-46ec-80f3-b732f8aa6d75")
                        });
                });

            modelBuilder.Entity("backend.Database.Models.Lap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RaceDriverId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RaceDriverId");

                    b.ToTable("Laps");
                });

            modelBuilder.Entity("backend.Database.Models.LapAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DefinitionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LapId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DefinitionId");

                    b.HasIndex("LapId");

                    b.ToTable("LapAttributes");
                });

            modelBuilder.Entity("backend.Database.Models.LapTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LapId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TagId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LapId");

                    b.HasIndex("TagId");

                    b.ToTable("LapTags");
                });

            modelBuilder.Entity("backend.Database.Models.Race", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("User")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("backend.Database.Models.RaceAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DefinitionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RaceId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DefinitionId");

                    b.HasIndex("RaceId");

                    b.ToTable("RaceAttributes");
                });

            modelBuilder.Entity("backend.Database.Models.RaceDriver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RaceId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("RaceId");

                    b.ToTable("RaceDrivers");
                });

            modelBuilder.Entity("backend.Database.Models.RaceDriverAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DefinitionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RaceDriverId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DefinitionId");

                    b.HasIndex("RaceDriverId");

                    b.ToTable("RaceDriverAttributes");
                });

            modelBuilder.Entity("backend.Database.Models.RaceDriverTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RaceDriverId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TagId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RaceDriverId");

                    b.HasIndex("TagId");

                    b.ToTable("RaceDriverTags");
                });

            modelBuilder.Entity("backend.Database.Models.RaceTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RaceId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TagId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.HasIndex("TagId");

                    b.ToTable("RaceTags");
                });

            modelBuilder.Entity("backend.Database.Models.TagCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("DriverValid")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LapValid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("RaceDriverValid")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RaceValid")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TagCategorys");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd4f4040-d248-412f-86b2-38fffc580398"),
                            Description = "The tyre the driver prefers",
                            DriverValid = true,
                            LapValid = false,
                            Name = "Tyre",
                            RaceDriverValid = true,
                            RaceValid = false
                        });
                });

            modelBuilder.Entity("backend.Database.Models.TagDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("TagDefinitions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b34104e1-efd8-46ec-80f3-b732f8aa6d75"),
                            CategoryId = new Guid("cd4f4040-d248-412f-86b2-38fffc580398"),
                            Value = "Soft"
                        });
                });

            modelBuilder.Entity("backend.Database.Models.DriverAttribute", b =>
                {
                    b.HasOne("backend.Database.Models.AttributeDefinition", "Definition")
                        .WithMany()
                        .HasForeignKey("DefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Database.Models.Driver", "Driver")
                        .WithMany("Attributes")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Definition");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("backend.Database.Models.DriverTag", b =>
                {
                    b.HasOne("backend.Database.Models.Driver", "Driver")
                        .WithMany("Tags")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Database.Models.TagDefinition", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("backend.Database.Models.Lap", b =>
                {
                    b.HasOne("backend.Database.Models.RaceDriver", "RaceDriver")
                        .WithMany()
                        .HasForeignKey("RaceDriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RaceDriver");
                });

            modelBuilder.Entity("backend.Database.Models.LapAttribute", b =>
                {
                    b.HasOne("backend.Database.Models.AttributeDefinition", "Definition")
                        .WithMany()
                        .HasForeignKey("DefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Database.Models.Lap", "Lap")
                        .WithMany("Attributes")
                        .HasForeignKey("LapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Definition");

                    b.Navigation("Lap");
                });

            modelBuilder.Entity("backend.Database.Models.LapTag", b =>
                {
                    b.HasOne("backend.Database.Models.Lap", "Lap")
                        .WithMany("Tags")
                        .HasForeignKey("LapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Database.Models.TagDefinition", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lap");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("backend.Database.Models.RaceAttribute", b =>
                {
                    b.HasOne("backend.Database.Models.AttributeDefinition", "Definition")
                        .WithMany()
                        .HasForeignKey("DefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Database.Models.Race", "Race")
                        .WithMany("Attributes")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Definition");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("backend.Database.Models.RaceDriver", b =>
                {
                    b.HasOne("backend.Database.Models.Driver", "Driver")
                        .WithMany("RaceEntries")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Database.Models.Race", "Race")
                        .WithMany("RaceEntries")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("backend.Database.Models.RaceDriverAttribute", b =>
                {
                    b.HasOne("backend.Database.Models.AttributeDefinition", "Definition")
                        .WithMany()
                        .HasForeignKey("DefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Database.Models.RaceDriver", "RaceDriver")
                        .WithMany("Attributes")
                        .HasForeignKey("RaceDriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Definition");

                    b.Navigation("RaceDriver");
                });

            modelBuilder.Entity("backend.Database.Models.RaceDriverTag", b =>
                {
                    b.HasOne("backend.Database.Models.RaceDriver", "RaceDriver")
                        .WithMany("Tags")
                        .HasForeignKey("RaceDriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Database.Models.TagDefinition", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RaceDriver");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("backend.Database.Models.RaceTag", b =>
                {
                    b.HasOne("backend.Database.Models.Race", "Race")
                        .WithMany("Tags")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Database.Models.TagDefinition", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("backend.Database.Models.TagDefinition", b =>
                {
                    b.HasOne("backend.Database.Models.TagCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("backend.Database.Models.Driver", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("RaceEntries");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("backend.Database.Models.Lap", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("backend.Database.Models.Race", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("RaceEntries");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("backend.Database.Models.RaceDriver", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}