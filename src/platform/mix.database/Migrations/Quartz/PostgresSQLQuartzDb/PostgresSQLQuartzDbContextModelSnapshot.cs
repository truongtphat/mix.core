﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mix.Database.Entities.Quartz;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mix.Database.Migrations.PostgresSQLQuartzDb
{
    [DbContext(typeof(PostgresSQLQuartzDbContext))]
    partial class PostgresSQLQuartzDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzBlobTrigger", b =>
                {
                    b.Property<string>("SchedName")
                        .HasColumnType("text")
                        .HasColumnName("sched_name");

                    b.Property<string>("TriggerName")
                        .HasColumnType("text")
                        .HasColumnName("trigger_name");

                    b.Property<string>("TriggerGroup")
                        .HasColumnType("text")
                        .HasColumnName("trigger_group");

                    b.Property<byte[]>("BlobData")
                        .HasColumnType("bytea")
                        .HasColumnName("blob_data");

                    b.HasKey("SchedName", "TriggerName", "TriggerGroup")
                        .HasName("qrtz_blob_triggers_pkey");

                    b.ToTable("qrtz_blob_triggers", (string)null);
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzCalendar", b =>
                {
                    b.Property<string>("SchedName")
                        .HasColumnType("text")
                        .HasColumnName("sched_name");

                    b.Property<string>("CalendarName")
                        .HasColumnType("text")
                        .HasColumnName("calendar_name");

                    b.Property<byte[]>("Calendar")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("calendar");

                    b.HasKey("SchedName", "CalendarName")
                        .HasName("qrtz_calendars_pkey");

                    b.ToTable("qrtz_calendars", (string)null);
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzCronTrigger", b =>
                {
                    b.Property<string>("SchedName")
                        .HasColumnType("text")
                        .HasColumnName("sched_name");

                    b.Property<string>("TriggerName")
                        .HasColumnType("text")
                        .HasColumnName("trigger_name");

                    b.Property<string>("TriggerGroup")
                        .HasColumnType("text")
                        .HasColumnName("trigger_group");

                    b.Property<string>("CronExpression")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cron_expression");

                    b.Property<string>("TimeZoneId")
                        .HasColumnType("text")
                        .HasColumnName("time_zone_id");

                    b.HasKey("SchedName", "TriggerName", "TriggerGroup")
                        .HasName("qrtz_cron_triggers_pkey");

                    b.ToTable("qrtz_cron_triggers", (string)null);
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzFiredTrigger", b =>
                {
                    b.Property<string>("SchedName")
                        .HasColumnType("text")
                        .HasColumnName("sched_name");

                    b.Property<string>("EntryId")
                        .HasColumnType("text")
                        .HasColumnName("entry_id");

                    b.Property<long>("FiredTime")
                        .HasColumnType("bigint")
                        .HasColumnName("fired_time");

                    b.Property<string>("InstanceName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("instance_name");

                    b.Property<bool?>("IsNonconcurrent")
                        .HasColumnType("boolean")
                        .HasColumnName("is_nonconcurrent");

                    b.Property<string>("JobGroup")
                        .HasColumnType("text")
                        .HasColumnName("job_group");

                    b.Property<string>("JobName")
                        .HasColumnType("text")
                        .HasColumnName("job_name");

                    b.Property<int>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.Property<bool?>("RequestsRecovery")
                        .HasColumnType("boolean")
                        .HasColumnName("requests_recovery");

                    b.Property<long>("SchedTime")
                        .HasColumnType("bigint")
                        .HasColumnName("sched_time");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("state");

                    b.Property<string>("TriggerGroup")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("trigger_group");

                    b.Property<string>("TriggerName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("trigger_name");

                    b.HasKey("SchedName", "EntryId")
                        .HasName("qrtz_fired_triggers_pkey");

                    b.HasIndex(new[] { "JobGroup" }, "idx_qrtz_ft_job_group");

                    b.HasIndex(new[] { "JobName" }, "idx_qrtz_ft_job_name");

                    b.HasIndex(new[] { "RequestsRecovery" }, "idx_qrtz_ft_job_req_recovery");

                    b.HasIndex(new[] { "TriggerGroup" }, "idx_qrtz_ft_trig_group");

                    b.HasIndex(new[] { "InstanceName" }, "idx_qrtz_ft_trig_inst_name");

                    b.HasIndex(new[] { "TriggerName" }, "idx_qrtz_ft_trig_name");

                    b.HasIndex(new[] { "SchedName", "TriggerName", "TriggerGroup" }, "idx_qrtz_ft_trig_nm_gp");

                    b.ToTable("qrtz_fired_triggers", (string)null);
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzJobDetail", b =>
                {
                    b.Property<string>("SchedName")
                        .HasColumnType("text")
                        .HasColumnName("sched_name");

                    b.Property<string>("JobName")
                        .HasColumnType("text")
                        .HasColumnName("job_name");

                    b.Property<string>("JobGroup")
                        .HasColumnType("text")
                        .HasColumnName("job_group");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsDurable")
                        .HasColumnType("boolean")
                        .HasColumnName("is_durable");

                    b.Property<bool>("IsNonconcurrent")
                        .HasColumnType("boolean")
                        .HasColumnName("is_nonconcurrent");

                    b.Property<bool>("IsUpdateData")
                        .HasColumnType("boolean")
                        .HasColumnName("is_update_data");

                    b.Property<string>("JobClassName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("job_class_name");

                    b.Property<byte[]>("JobData")
                        .HasColumnType("bytea")
                        .HasColumnName("job_data");

                    b.Property<bool>("RequestsRecovery")
                        .HasColumnType("boolean")
                        .HasColumnName("requests_recovery");

                    b.HasKey("SchedName", "JobName", "JobGroup")
                        .HasName("qrtz_job_details_pkey");

                    b.HasIndex(new[] { "RequestsRecovery" }, "idx_qrtz_j_req_recovery");

                    b.ToTable("qrtz_job_details", (string)null);
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzLock", b =>
                {
                    b.Property<string>("SchedName")
                        .HasColumnType("text")
                        .HasColumnName("sched_name");

                    b.Property<string>("LockName")
                        .HasColumnType("text")
                        .HasColumnName("lock_name");

                    b.HasKey("SchedName", "LockName")
                        .HasName("qrtz_locks_pkey");

                    b.ToTable("qrtz_locks", (string)null);
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzPausedTriggerGrp", b =>
                {
                    b.Property<string>("SchedName")
                        .HasColumnType("text")
                        .HasColumnName("sched_name");

                    b.Property<string>("TriggerGroup")
                        .HasColumnType("text")
                        .HasColumnName("trigger_group");

                    b.HasKey("SchedName", "TriggerGroup")
                        .HasName("qrtz_paused_trigger_grps_pkey");

                    b.ToTable("qrtz_paused_trigger_grps", (string)null);
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzSchedulerState", b =>
                {
                    b.Property<string>("SchedName")
                        .HasColumnType("text")
                        .HasColumnName("sched_name");

                    b.Property<string>("InstanceName")
                        .HasColumnType("text")
                        .HasColumnName("instance_name");

                    b.Property<long>("CheckinInterval")
                        .HasColumnType("bigint")
                        .HasColumnName("checkin_interval");

                    b.Property<long>("LastCheckinTime")
                        .HasColumnType("bigint")
                        .HasColumnName("last_checkin_time");

                    b.HasKey("SchedName", "InstanceName")
                        .HasName("qrtz_scheduler_state_pkey");

                    b.ToTable("qrtz_scheduler_state", (string)null);
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzSimpleTrigger", b =>
                {
                    b.Property<string>("SchedName")
                        .HasColumnType("text")
                        .HasColumnName("sched_name");

                    b.Property<string>("TriggerName")
                        .HasColumnType("text")
                        .HasColumnName("trigger_name");

                    b.Property<string>("TriggerGroup")
                        .HasColumnType("text")
                        .HasColumnName("trigger_group");

                    b.Property<long>("RepeatCount")
                        .HasColumnType("bigint")
                        .HasColumnName("repeat_count");

                    b.Property<long>("RepeatInterval")
                        .HasColumnType("bigint")
                        .HasColumnName("repeat_interval");

                    b.Property<long>("TimesTriggered")
                        .HasColumnType("bigint")
                        .HasColumnName("times_triggered");

                    b.HasKey("SchedName", "TriggerName", "TriggerGroup")
                        .HasName("qrtz_simple_triggers_pkey");

                    b.ToTable("qrtz_simple_triggers", (string)null);
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzSimpropTrigger", b =>
                {
                    b.Property<string>("SchedName")
                        .HasColumnType("text")
                        .HasColumnName("sched_name");

                    b.Property<string>("TriggerName")
                        .HasColumnType("text")
                        .HasColumnName("trigger_name");

                    b.Property<string>("TriggerGroup")
                        .HasColumnType("text")
                        .HasColumnName("trigger_group");

                    b.Property<bool?>("BoolProp1")
                        .HasColumnType("boolean")
                        .HasColumnName("bool_prop_1");

                    b.Property<bool?>("BoolProp2")
                        .HasColumnType("boolean")
                        .HasColumnName("bool_prop_2");

                    b.Property<decimal?>("DecProp1")
                        .HasColumnType("numeric")
                        .HasColumnName("dec_prop_1");

                    b.Property<decimal?>("DecProp2")
                        .HasColumnType("numeric")
                        .HasColumnName("dec_prop_2");

                    b.Property<int?>("IntProp1")
                        .HasColumnType("integer")
                        .HasColumnName("int_prop_1");

                    b.Property<int?>("IntProp2")
                        .HasColumnType("integer")
                        .HasColumnName("int_prop_2");

                    b.Property<long?>("LongProp1")
                        .HasColumnType("bigint")
                        .HasColumnName("long_prop_1");

                    b.Property<long?>("LongProp2")
                        .HasColumnType("bigint")
                        .HasColumnName("long_prop_2");

                    b.Property<string>("StrProp1")
                        .HasColumnType("text")
                        .HasColumnName("str_prop_1");

                    b.Property<string>("StrProp2")
                        .HasColumnType("text")
                        .HasColumnName("str_prop_2");

                    b.Property<string>("StrProp3")
                        .HasColumnType("text")
                        .HasColumnName("str_prop_3");

                    b.Property<string>("TimeZoneId")
                        .HasColumnType("text")
                        .HasColumnName("time_zone_id");

                    b.HasKey("SchedName", "TriggerName", "TriggerGroup")
                        .HasName("qrtz_simprop_triggers_pkey");

                    b.ToTable("qrtz_simprop_triggers", (string)null);
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzTrigger", b =>
                {
                    b.Property<string>("SchedName")
                        .HasColumnType("text")
                        .HasColumnName("sched_name");

                    b.Property<string>("TriggerName")
                        .HasColumnType("text")
                        .HasColumnName("trigger_name");

                    b.Property<string>("TriggerGroup")
                        .HasColumnType("text")
                        .HasColumnName("trigger_group");

                    b.Property<string>("CalendarName")
                        .HasColumnType("text")
                        .HasColumnName("calendar_name");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<long?>("EndTime")
                        .HasColumnType("bigint")
                        .HasColumnName("end_time");

                    b.Property<byte[]>("JobData")
                        .HasColumnType("bytea")
                        .HasColumnName("job_data");

                    b.Property<string>("JobGroup")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("job_group");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("job_name");

                    b.Property<short?>("MisfireInstr")
                        .HasColumnType("smallint")
                        .HasColumnName("misfire_instr");

                    b.Property<long?>("NextFireTime")
                        .HasColumnType("bigint")
                        .HasColumnName("next_fire_time");

                    b.Property<long?>("PrevFireTime")
                        .HasColumnType("bigint")
                        .HasColumnName("prev_fire_time");

                    b.Property<int?>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.Property<long>("StartTime")
                        .HasColumnType("bigint")
                        .HasColumnName("start_time");

                    b.Property<string>("TriggerState")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("trigger_state");

                    b.Property<string>("TriggerType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("trigger_type");

                    b.HasKey("SchedName", "TriggerName", "TriggerGroup")
                        .HasName("qrtz_triggers_pkey");

                    b.HasIndex("SchedName", "JobName", "JobGroup");

                    b.HasIndex(new[] { "NextFireTime" }, "idx_qrtz_t_next_fire_time");

                    b.HasIndex(new[] { "NextFireTime", "TriggerState" }, "idx_qrtz_t_nft_st");

                    b.HasIndex(new[] { "TriggerState" }, "idx_qrtz_t_state");

                    b.ToTable("qrtz_triggers", (string)null);
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzBlobTrigger", b =>
                {
                    b.HasOne("Mix.Database.Entities.Quartz.QrtzTrigger", "QrtzTrigger")
                        .WithOne("QrtzBlobTrigger")
                        .HasForeignKey("Mix.Database.Entities.Quartz.QrtzBlobTrigger", "SchedName", "TriggerName", "TriggerGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("qrtz_blob_triggers_sched_name_trigger_name_trigger_group_fkey");

                    b.Navigation("QrtzTrigger");
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzCronTrigger", b =>
                {
                    b.HasOne("Mix.Database.Entities.Quartz.QrtzTrigger", "QrtzTrigger")
                        .WithOne("QrtzCronTrigger")
                        .HasForeignKey("Mix.Database.Entities.Quartz.QrtzCronTrigger", "SchedName", "TriggerName", "TriggerGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("qrtz_cron_triggers_sched_name_trigger_name_trigger_group_fkey");

                    b.Navigation("QrtzTrigger");
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzSimpleTrigger", b =>
                {
                    b.HasOne("Mix.Database.Entities.Quartz.QrtzTrigger", "QrtzTrigger")
                        .WithOne("QrtzSimpleTrigger")
                        .HasForeignKey("Mix.Database.Entities.Quartz.QrtzSimpleTrigger", "SchedName", "TriggerName", "TriggerGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("qrtz_simple_triggers_sched_name_trigger_name_trigger_group_fkey");

                    b.Navigation("QrtzTrigger");
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzSimpropTrigger", b =>
                {
                    b.HasOne("Mix.Database.Entities.Quartz.QrtzTrigger", "QrtzTrigger")
                        .WithOne("QrtzSimpropTrigger")
                        .HasForeignKey("Mix.Database.Entities.Quartz.QrtzSimpropTrigger", "SchedName", "TriggerName", "TriggerGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("qrtz_simprop_triggers_sched_name_trigger_name_trigger_grou_fkey");

                    b.Navigation("QrtzTrigger");
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzTrigger", b =>
                {
                    b.HasOne("Mix.Database.Entities.Quartz.QrtzJobDetail", "QrtzJobDetail")
                        .WithMany("QrtzTriggers")
                        .HasForeignKey("SchedName", "JobName", "JobGroup")
                        .IsRequired()
                        .HasConstraintName("qrtz_triggers_sched_name_job_name_job_group_fkey");

                    b.Navigation("QrtzJobDetail");
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzJobDetail", b =>
                {
                    b.Navigation("QrtzTriggers");
                });

            modelBuilder.Entity("Mix.Database.Entities.Quartz.QrtzTrigger", b =>
                {
                    b.Navigation("QrtzBlobTrigger");

                    b.Navigation("QrtzCronTrigger");

                    b.Navigation("QrtzSimpleTrigger");

                    b.Navigation("QrtzSimpropTrigger");
                });
#pragma warning restore 612, 618
        }
    }
}