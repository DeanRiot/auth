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
    [Migration("20220613092347_add_uuid_gen_path")]
    partial class add_uuid_gen_path
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("notifier.EF.Entity.Communication", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("method")
                        .HasColumnType("text");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("user")
                        .HasColumnType("uuid");

                    b.HasKey("id");

                    b.ToTable("Communication");
                });

            modelBuilder.Entity("notifier.EF.Entity.MAIL", b =>
                {
                    b.Property<Guid>("mail_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<bool>("enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("mail")
                        .HasColumnType("text");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("mail_id");

                    b.ToTable("MAIL");
                });

            modelBuilder.Entity("notifier.EF.Entity.SMS", b =>
                {
                    b.Property<Guid>("sms_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<bool>("enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("sms_id");

                    b.ToTable("SMS");
                });
#pragma warning restore 612, 618
        }
    }
}
