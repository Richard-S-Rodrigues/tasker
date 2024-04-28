﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tasker.Infrastructure.Context;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Tasker.Domain.AttachmentFileAgggregate.AttachmentFile", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted_at");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("deleted_by");

                    b.Property<long>("TaskId")
                        .HasColumnType("bigint")
                        .HasColumnName("task_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("attachment_file", (string)null);
                });

            modelBuilder.Entity("Tasker.Domain.BoardAggregate.Board", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

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

            modelBuilder.Entity("Tasker.Domain.CommentAggregate.Comment", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

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

                    b.Property<long>("TaskId")
                        .HasColumnType("bigint")
                        .HasColumnName("task_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("comment", (string)null);
                });

            modelBuilder.Entity("Tasker.Domain.MemberAggregate.Member", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("BoardId")
                        .HasColumnType("bigint")
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

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_admin");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("member", (string)null);
                });

            modelBuilder.Entity("Tasker.Domain.TaskAggregate.Task", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("BoardId")
                        .HasColumnType("bigint")
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

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint")
                        .HasColumnName("parent_id");

                    b.Property<int>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<long[]>("SubTaskIds")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint[]")
                        .HasDefaultValue(new long[0])
                        .HasColumnName("sub_task_ids");

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

            modelBuilder.Entity("Tasker.Domain.UserAggregate.User", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

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

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Tasker.Domain.TaskAggregate.Task", b =>
                {
                    b.OwnsOne("Tasker.Domain.TaskAggregate.ValueObjects.TimeDetails", "TimeDetails", b1 =>
                        {
                            b1.Property<long>("TaskId")
                                .HasColumnType("bigint");

                            b1.Property<DateTime?>("EndDate")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("end_date");

                            b1.Property<TimeSpan?>("EstimatedTime")
                                .HasColumnType("time")
                                .HasColumnName("estimated_time");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("start_date");

                            b1.Property<TimeSpan?>("Time")
                                .HasColumnType("time")
                                .HasColumnName("time");

                            b1.HasKey("TaskId");

                            b1.ToTable("task");

                            b1.WithOwner()
                                .HasForeignKey("TaskId");
                        });

                    b.OwnsMany("Tasker.Domain.AttachmentFileAgggregate.ValueObjects.AttachmentFileId", "AttachmentFileIds", b1 =>
                        {
                            b1.Property<long>("id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<long>("id"));

                            b1.Property<long>("Value")
                                .HasColumnType("bigint")
                                .HasColumnName("attachment_file_id");

                            b1.Property<long>("task_id")
                                .HasColumnType("bigint");

                            b1.HasKey("id");

                            b1.HasIndex("task_id");

                            b1.ToTable("task_attachment_file_ids", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("task_id");
                        });

                    b.OwnsMany("Tasker.Domain.CommentAggregate.ValueObjects.CommentId", "CommentIds", b1 =>
                        {
                            b1.Property<long>("id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<long>("id"));

                            b1.Property<long>("Value")
                                .HasColumnType("bigint")
                                .HasColumnName("comment_id");

                            b1.Property<long>("task_id")
                                .HasColumnType("bigint");

                            b1.HasKey("id");

                            b1.HasIndex("task_id");

                            b1.ToTable("task_comment_ids", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("task_id");
                        });

                    b.OwnsMany("Tasker.Domain.TaskAggregate.ValueObjects.Responsible", "Responsibles", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint")
                                .HasColumnName("user_id");

                            b1.Property<TimeSpan?>("EstimatedTime")
                                .HasColumnType("time")
                                .HasColumnName("estimated_time");

                            b1.Property<TimeSpan?>("Time")
                                .HasColumnType("time")
                                .HasColumnName("time");

                            b1.Property<long>("task_id")
                                .HasColumnType("bigint");

                            b1.HasKey("UserId");

                            b1.HasIndex("task_id");

                            b1.ToTable("task_responsibles", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("task_id");
                        });

                    b.Navigation("AttachmentFileIds");

                    b.Navigation("CommentIds");

                    b.Navigation("Responsibles");

                    b.Navigation("TimeDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
