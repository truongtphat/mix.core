﻿using Mix.Database.Entities.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mix.Service.Models
{
    public class MixTenantSystemModel
    {
        public int Id { get; set; }

        public string PrimaryDomain { get; set; }

        public string SystemName { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public List<MixDomain> Domains { get; set; }

        public List<MixCulture> Cultures { get; set; } = new();

        public TenantConfigurationModel Configurations { get; set; }
    }
}