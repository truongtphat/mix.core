﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mix.Lib.Enums;
using Mix.Lib.Entities.Cms;

namespace Mix.Lib.Entities.EntityConfigurations.POSTGRESQL
{
    public class MixPortalPageRoleConfiguration : IEntityTypeConfiguration<MixPortalPageRole>
    {
        public void Configure(EntityTypeBuilder<MixPortalPageRole> entity)
        {
            entity.HasKey(e => new { e.Id })
                    .HasName("PK_mix_portal_page_role");

            entity.ToTable("mix_portal_page_role");

            entity.Property(e => e.RoleId).HasMaxLength(50);

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CreatedDateTime).HasColumnType("timestamp without time zone");

            entity.Property(e => e.LastModified).HasColumnType("timestamp without time zone");

            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Status)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<MixContentStatus>())
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Page)
                .WithMany(p => p.MixPortalPageRole)
                .HasForeignKey(d => d.PageId)
                .HasConstraintName("FK_mix_portal_page_role_mix_portal_page");
        }
    }
}