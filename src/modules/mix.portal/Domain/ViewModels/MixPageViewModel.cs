﻿using Mix.Database.Entities.Cms;
using Mix.Heart.Repository;
using Mix.Heart.UnitOfWork;
using Mix.Lib.Attributes;
using Mix.Lib.Base;

namespace Mix.Portal.Domain.ViewModels
{
    [GenerateRestApiController]
    public class MixPageViewModel
        : SiteDataWithContentViewModelBase
            <MixCmsContext, MixPage, int, MixPageViewModel, MixPageContent, MixPageContentViewModel>
    {
        #region Contructors

        public MixPageViewModel()
        {
        }

        public MixPageViewModel(MixPage entity, UnitOfWorkInfo uowInfo = null) : base(entity, uowInfo)
        {
        }

        public MixPageViewModel(UnitOfWorkInfo unitOfWorkInfo) : base(unitOfWorkInfo)
        {
        }

        #endregion

        #region Overrides


        #endregion
    }
}