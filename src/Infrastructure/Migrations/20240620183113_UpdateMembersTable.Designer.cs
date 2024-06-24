﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tasker.Infrastructure.Context;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240620183113_UpdateMembersTable")]
    partial class UpdateMembersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Tasker.Domain.BoardAggregate.Board", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted_at");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("deleted_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("board", (string)null);
                });

            modelBuilder.Entity("Tasker.Domain.TaskAggregate.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("BoardId")
                        .HasColumnType("uuid")
                        .HasColumnName("board_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted_at");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("deleted_by");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("task", (string)null);
                });

            modelBuilder.Entity("Tasker.Domain.BoardAggregate.Board", b =>
                {
                    b.OwnsMany("Tasker.Domain.BoardAggregate.Member", "Members", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<Guid>("BoardId")
                                .HasColumnType("uuid")
                                .HasColumnName("board_id");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("created_at");

                            b1.Property<long?>("CreatedBy")
                                .HasColumnType("bigint")
                                .HasColumnName("created_by");

                            b1.Property<DateTime?>("DeletedAt")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("deleted_at");

                            b1.Property<long?>("DeletedBy")
                                .HasColumnType("bigint")
                                .HasColumnName("deleted_by");

                            b1.Property<bool>("IsAdmin")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("boolean")
                                .HasDefaultValue(false)
                                .HasColumnName("is_admin");

                            b1.Property<DateTime?>("UpdatedAt")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("updated_at");

                            b1.Property<long?>("UpdatedBy")
                                .HasColumnType("bigint")
                                .HasColumnName("updated_by");

                            b1.HasKey("Id");

                            b1.HasIndex("BoardId");

                            b1.ToTable("board_member", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("BoardId");
                        });

                    b.Navigation("Members");
                });

            modelBuilder.Entity("Tasker.Domain.TaskAggregate.Task", b =>
                {
                    b.OwnsMany("Tasker.Domain.TaskAggregate.AttachmentFile", "AttachmentFiles", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Base64")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("base64");

                            b1.Property<string>("ContentType")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("content_type");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("created_at");

                            b1.Property<long?>("CreatedBy")
                                .HasColumnType("bigint")
                                .HasColumnName("created_by");

                            b1.Property<DateTime?>("DeletedAt")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("deleted_at");

                            b1.Property<long?>("DeletedBy")
                                .HasColumnType("bigint")
                                .HasColumnName("deleted_by");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("name");

                            b1.Property<Guid>("TaskId")
                                .HasColumnType("uuid")
                                .HasColumnName("task_id");

                            b1.Property<DateTime?>("UpdatedAt")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("updated_at");

                            b1.Property<long?>("UpdatedBy")
                                .HasColumnType("bigint")
                                .HasColumnName("updated_by");

                            b1.HasKey("Id");

                            b1.HasIndex("TaskId");

                            b1.ToTable("task_attachment_file", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("TaskId");
                        });

                    b.OwnsMany("Tasker.Domain.TaskAggregate.Comment", "Comments", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("created_at");

                            b1.Property<long?>("CreatedBy")
                                .HasColumnType("bigint")
                                .HasColumnName("created_by");

                            b1.Property<DateTime?>("DeletedAt")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("deleted_at");

                            b1.Property<long?>("DeletedBy")
                                .HasColumnType("bigint")
                                .HasColumnName("deleted_by");

                            b1.Property<Guid>("MemberId")
                                .HasColumnType("uuid")
                                .HasColumnName("user_id");

                            b1.Property<Guid>("TaskId")
                                .HasColumnType("uuid")
                                .HasColumnName("task_id");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("text");

                            b1.Property<DateTime?>("UpdatedAt")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("updated_at");

                            b1.Property<long?>("UpdatedBy")
                                .HasColumnType("bigint")
                                .HasColumnName("updated_by");

                            b1.HasKey("Id");

                            b1.HasIndex("TaskId");

                            b1.ToTable("task_comment", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("TaskId");
                        });

                    b.OwnsMany("Tasker.Domain.TaskAggregate.TaskChecklist", "TaskChecklists", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("created_at");

                            b1.Property<long?>("CreatedBy")
                                .HasColumnType("bigint")
                                .HasColumnName("created_by");

                            b1.Property<DateTime?>("DeletedAt")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("deleted_at");

                            b1.Property<long?>("DeletedBy")
                                .HasColumnType("bigint")
                                .HasColumnName("deleted_by");

                            b1.Property<string>("Description")
                                .HasColumnType("text")
                                .HasColumnName("description");

                            b1.Property<bool>("IsDone")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("boolean")
                                .HasDefaultValue(false)
                                .HasColumnName("is_done");

                            b1.Property<Guid>("MemberId")
                                .HasColumnType("uuid")
                                .HasColumnName("user_id");

                            b1.Property<Guid>("TaskId")
                                .HasColumnType("uuid")
                                .HasColumnName("task_id");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("title");

                            b1.Property<DateTime?>("UpdatedAt")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("updated_at");

                            b1.Property<long?>("UpdatedBy")
                                .HasColumnType("bigint")
                                .HasColumnName("updated_by");

                            b1.HasKey("Id");

                            b1.HasIndex("TaskId");

                            b1.ToTable("task_checklist", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("TaskId");
                        });

                    b.OwnsOne("Tasker.Domain.TaskAggregate.ValueObjects.TimeDetails", "TimeDetails", b1 =>
                        {
                            b1.Property<Guid>("TaskId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("end_date");

                            b1.Property<long>("EstimatedTime")
                                .HasColumnType("bigint")
                                .HasColumnName("estimated_time");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("start_date");

                            b1.Property<long>("Time")
                                .HasColumnType("bigint")
                                .HasColumnName("time");

                            b1.HasKey("TaskId");

                            b1.ToTable("task");

                            b1.WithOwner()
                                .HasForeignKey("TaskId");
                        });

                    b.OwnsMany("Tasker.Domain.TaskAggregate.ValueObjects.Responsible", "Responsibles", b1 =>
                        {
                            b1.Property<Guid>("MemberId")
                                .HasColumnType("uuid")
                                .HasColumnName("user_id");

                            b1.Property<TimeOnly?>("EstimatedTime")
                                .HasColumnType("time without time zone")
                                .HasColumnName("estimated_time");

                            b1.Property<TimeOnly?>("Time")
                                .HasColumnType("time without time zone")
                                .HasColumnName("time");

                            b1.Property<Guid>("task_id")
                                .HasColumnType("uuid");

                            b1.HasKey("MemberId");

                            b1.HasIndex("task_id");

                            b1.ToTable("task_responsibles", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("task_id");
                        });

                    b.Navigation("AttachmentFiles");

                    b.Navigation("Comments");

                    b.Navigation("Responsibles");

                    b.Navigation("TaskChecklists");

                    b.Navigation("TimeDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
