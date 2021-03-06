﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using OneBelote.SQLite;
using System;

namespace OneBelote.Migrations
{
    [DbContext(typeof(GameDatabase))]
    partial class GameDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("OneBelote.Model.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Them");

                    b.Property<int>("Us");

                    b.HasKey("Id");

                    b.ToTable("Score");
                });
#pragma warning restore 612, 618
        }
    }
}
