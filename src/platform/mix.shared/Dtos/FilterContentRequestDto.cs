﻿using Microsoft.AspNetCore.Http;
using Mix.Constant.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Mix.Shared.Dtos
{
    public class FilterContentRequestDto : SearchRequestDto
    {
        public FilterContentRequestDto()
        {

        }
        public FilterContentRequestDto(SearchRequestDto req)
        {
            Culture = req.Culture;
            Keyword = req.Keyword;
            FromDate = req.FromDate;
            ToDate = req.ToDate;
            PageIndex = req.PageIndex;
            PageSize = req.PageSize;
            OrderBy = req.OrderBy;
            Direction = req.Direction;
            Status = req.Status;
        }

        public string MixDatabaseName { get; set; }
        public List<SearchQueryField> Queries { get; set; } = new();
    }
}