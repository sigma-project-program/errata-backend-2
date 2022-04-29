﻿// <auto-generated />
using System;
using ErrataManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace errata_backend_2.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20220429121339_creation-done")]
    partial class creationdone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("ErrataManager.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ErrataManager.Models.Error", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Decision")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ErrorName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ErrorType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("BookId1");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("ErrataManager.Models.Error", b =>
                {
                    b.HasOne("ErrataManager.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ErrataManager.Models.Book", "Book")
                        .WithMany("Errors")
                        .HasForeignKey("BookId1");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("ErrataManager.Models.Book", b =>
                {
                    b.Navigation("Errors");
                });
#pragma warning restore 612, 618
        }
    }
}