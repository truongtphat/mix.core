﻿using Mix.Database.EntityConfigurations.MYSQL.Base;

namespace Mix.Database.EntityConfigurations.MYSQL
{
    public class MySqlMixPostContentConfiguration : MixPostContentConfiguration<MySqlDatabaseConstants>
    {
        public override void Configure(EntityTypeBuilder<MixPostContent> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.ClassName)
                .HasColumnType($"{Config.String}{Config.SmallLength}")
                .HasCharSet(Config.CharSet);
        }
    }
}