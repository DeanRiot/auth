﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using notifier.EF.Entity;

namespace notifier.EF.Migrations
{
    [DbContext(typeof(NotifyContext))]
    [Migration("20220610202644_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("notifier.EF.Entity.MAIL", b =>
                {
                    b.Property<bool>("enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("mail")
                        .HasColumnType("text");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uuid");

                    b.ToTable("MAIL");
                });

            modelBuilder.Entity("notifier.EF.Entity.SMS", b =>
                {
                    b.Property<bool>("enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uuid");

                    b.ToTable("SMS");
                });
#pragma warning restore 612, 618
        }
    }
}