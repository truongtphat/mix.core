﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mix.Database.Entities.Account;

#nullable disable

namespace Mix.Database.Migrations.SqlServerAccount
{
    [DbContext(typeof(SqlServerAccountContext))]
    [Migration("20220618115249_UpdateForeinKeys")]
    partial class UpdateForeinKeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Mix.Database.Entities.Account.AspNetRoleClaims", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<Guid?>("AspNetRolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClaimType")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<Guid?>("MixRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.HasKey("Id");

                    b.HasIndex("AspNetRolesId");

                    b.HasIndex("MixRoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.AspNetRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("(NormalizedName IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<Guid?>("MixUserId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.HasKey("Id");

                    b.HasIndex("MixUserId1");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(50)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(50)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("PK_AspNetUserLogins_1");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.AspNetUserRoles", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<int>("MixTenantId")
                        .HasColumnType("int");

                    b.Property<Guid?>("AspNetRolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MixRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId", "MixTenantId");

                    b.HasIndex("AspNetRolesId");

                    b.HasIndex("MixRoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.AspNetUserTokens", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(50)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("Value")
                        .HasColumnType("varchar(4000)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.Clients", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(50)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("AllowedOrigin")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<int>("ApplicationType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<int>("RefreshTokenLifeTime")
                        .HasColumnType("int");

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.MixRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasDatabaseName("MixRoleNameIndex")
                        .HasFilter("(NormalizedName IS NOT NULL)");

                    b.ToTable("MixRoles");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.MixUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(50)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("Gender")
                        .HasColumnType("varchar(50)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<bool>("IsActived")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(50)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("NickName")
                        .HasColumnType("varchar(50)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(50)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RegisterType")
                        .HasColumnType("varchar(50)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("varchar(50)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("(NormalizedUserName IS NOT NULL)");

                    b.ToTable("MixUsers");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.MixUserTenant", b =>
                {
                    b.Property<Guid>("MixUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("MixUserId", "TenantId");

                    b.HasIndex("MixUserId");

                    b.HasIndex("TenantId");

                    b.ToTable("MixUserTenants");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.RefreshTokens", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.Property<DateTime>("ExpiresUtc")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("IssuedUtc")
                        .HasColumnType("datetime");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(250)")
                        .UseCollation("Vietnamese_CI_AS")
                        .HasAnnotation("MySql:CharSet", "utf8");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.AspNetRoleClaims", b =>
                {
                    b.HasOne("Mix.Database.Entities.Account.AspNetRoles", null)
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("AspNetRolesId");

                    b.HasOne("Mix.Database.Entities.Account.MixRole", null)
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("MixRoleId");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.AspNetUserClaims", b =>
                {
                    b.HasOne("Mix.Database.Entities.Account.MixUser", null)
                        .WithMany("Claims")
                        .HasForeignKey("MixUserId1");

                    b.HasOne("Mix.Database.Entities.Account.MixUser", "MixUser")
                        .WithMany("AspNetUserClaimsUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MixUser");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.AspNetUserLogins", b =>
                {
                    b.HasOne("Mix.Database.Entities.Account.MixUser", "MixUser")
                        .WithMany("AspNetUserLoginsUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MixUser");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.AspNetUserRoles", b =>
                {
                    b.HasOne("Mix.Database.Entities.Account.AspNetRoles", null)
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("AspNetRolesId");

                    b.HasOne("Mix.Database.Entities.Account.MixRole", null)
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("MixRoleId");

                    b.HasOne("Mix.Database.Entities.Account.MixUser", "MixUser")
                        .WithMany("AspNetUserRolesUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MixUser");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.AspNetUserTokens", b =>
                {
                    b.HasOne("Mix.Database.Entities.Account.MixUser", "MixUser")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MixUser");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.AspNetRoles", b =>
                {
                    b.Navigation("AspNetRoleClaims");

                    b.Navigation("AspNetUserRoles");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.MixRole", b =>
                {
                    b.Navigation("AspNetRoleClaims");

                    b.Navigation("AspNetUserRoles");
                });

            modelBuilder.Entity("Mix.Database.Entities.Account.MixUser", b =>
                {
                    b.Navigation("AspNetUserClaimsUser");

                    b.Navigation("AspNetUserLoginsUser");

                    b.Navigation("AspNetUserRolesUser");

                    b.Navigation("AspNetUserTokens");

                    b.Navigation("Claims");
                });
#pragma warning restore 612, 618
        }
    }
}