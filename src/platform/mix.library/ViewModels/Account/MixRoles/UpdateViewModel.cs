﻿using Microsoft.EntityFrameworkCore.Storage;
using Mix.Heart.Infrastructure.ViewModels;
using Mix.Heart.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Mix.Lib.Entities.Account;

namespace Mix.Lib.ViewModels.Account.MixRoles
{
    public class UpdateViewModel : ViewModelBase<MixCmsAccountContext, AspNetRoles, UpdateViewModel>
    {
        #region Properties

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("concurrencyStamp")]
        public string ConcurrencyStamp { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("normalizedName")]
        public string NormalizedName { get; set; }

        #region Views

        // TODO: Update later
        //[JsonProperty("permissions")]
        //public List<MixPortalPages.UpdateRolePermissionViewModel> Permissions { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public UpdateViewModel() : base()
        {
        }

        public UpdateViewModel(AspNetRoles model, MixCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override AspNetRoles ParseModel(MixCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString();
            }
            return base.ParseModel(_context, _transaction);
        }

        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(UpdateViewModel view, MixCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await UserRoleViewModel.Repository.RemoveListModelAsync(false, ur => ur.RoleId == Id, _context, _transaction);
            return new RepositoryResponse<bool>()
            {
                IsSucceed = result.IsSucceed,
                Errors = result.Errors,
                Exception = result.Exception
            };
        }

        // TODO: Update later
        //public async Task LoadPermissions(MixCmsContext _context = null
        //    , IDbContextTransaction _transaction = null)
        //{
        //    var getPermissions = await MixPortalPages.UpdateRolePermissionViewModel.Repository.GetModelListByAsync(
        //        p => p.Level == 0, _context, _transaction);
        //    if (getPermissions.IsSucceed)
        //    {
        //        Permissions = getPermissions.Data;
        //        foreach (var item in Permissions)
        //        {
        //            item.NavPermission = MixPortalPageRoles.ReadViewModel.Repository.GetSingleModel(
        //                n => n.PageId == item.Id && n.RoleId == Id, _context, _transaction)
        //                .Data;
        //            if (item.NavPermission == null)
        //            {
        //                var nav = new MixPortalPageRole()
        //                {
        //                    PageId = item.Id,
        //                    RoleId = Id,
        //                    Status = MixContentStatus.Published
        //                };
        //                item.NavPermission = new MixPortalPageRoles.ReadViewModel(nav) { IsActived = false };
        //            }
        //            else
        //            {
        //                item.NavPermission.IsActived = true;
        //            }

        //            foreach (var child in item.ChildPages)
        //            {
        //                child.PortalPage.NavPermission = MixPortalPageRoles.ReadViewModel.Repository.GetSingleModel(
        //                    n => n.PageId == child.PortalPage.Id && n.RoleId == Id, _context, _transaction)
        //                    .Data;
        //                if (child.PortalPage.NavPermission == null)
        //                {
        //                    var nav = new MixPortalPageRole()
        //                    {
        //                        PageId = child.PortalPage.Id,
        //                        RoleId = Id,
        //                        Status = MixContentStatus.Published
        //                    };
        //                    child.PortalPage.NavPermission = new MixPortalPageRoles.ReadViewModel(nav) { IsActived = false };
        //                }
        //                else
        //                {
        //                    child.PortalPage.NavPermission.IsActived = true;
        //                }
        //            }
        //        }
        //    }
        //}

        // TODO: Update later
        //public async Task<RepositoryResponse<bool>> SavePermissionsAsync(AspNetRoles parent, MixCmsContext _context = null, IDbContextTransaction _transaction = null)
        //{
        //    UnitOfWorkHelper<MixCmsContext>.InitTransaction(_context, _transaction, out MixCmsContext context, out IDbContextTransaction transaction, out bool isRoot);
        //    var result = new RepositoryResponse<bool>() { IsSucceed = true };
        //    try
        //    {
        //        foreach (var item in Permissions)
        //        {
        //            if (result.IsSucceed)
        //            {
        //                result = await HandlePermission(item, context, transaction);
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //        UnitOfWorkHelper<MixCmsContext>.HandleTransaction(result.IsSucceed, isRoot, transaction);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return UnitOfWorkHelper<MixCmsContext>.HandleException<bool>(ex, isRoot, transaction);
        //    }
        //    finally
        //    {
        //        UnitOfWorkHelper<MixCmsContext>.CloseDbContext(ref context, ref transaction);
        //    }
        //}

        #endregion Overrides

        #region Expands

        // TODO: Update later
        //private List<MixPortalPageRoles.ReadViewModel> GetPermission()
        //{
        //    using (MixCmsContext context = new MixCmsContext())
        //    {
        //        var transaction = context.Database.BeginTransaction();
        //        var query = context.MixPortalPage
        //        .Include(cp => cp.MixPortalPageRole)
        //        .Select(Category =>
        //        new MixPortalPageRoles.ReadViewModel(
        //              new MixPortalPageRole()
        //              {
        //                  RoleId = Id,
        //                  PageId = Category.Id,
        //              }, context, transaction));

        //        var result = query.ToList();
        //        result.ForEach(nav =>
        //        {
        //            nav.IsActived = context.MixPortalPageRole.Any(
        //                    m => m.PageId == nav.PageId && m.RoleId == Id);
        //        });
        //        transaction.Commit();
        //        return result.OrderBy(m => m.Priority).ToList();
        //    }
        //}
        // TODO: Update later

        // TODO: Update later
        //private async Task<RepositoryResponse<bool>> HandlePermission(MixPortalPages.UpdateRolePermissionViewModel item, MixCmsContext context, IDbContextTransaction transaction)
        //{
        //    var result = new RepositoryResponse<bool>() { IsSucceed = true };

        //    if (item.NavPermission.IsActived)
        //    {
        //        item.NavPermission.CreatedBy = item.CreatedBy;
        //        var saveResult = await item.NavPermission.SaveModelAsync(false, context, transaction);
        //        result.IsSucceed = saveResult.IsSucceed;
        //        /* skip child nav
        //        if (result.IsSucceed)
        //        {
        //            foreach (var child in item.ChildPages)
        //            {
        //                result = await HandlePermission(child.Page, context, transaction);
        //                if (!result.IsSucceed)
        //                {
        //                    break;
        //                }
        //            }
        //        }*/

        //        if (!result.IsSucceed)
        //        {
        //            result.Exception = saveResult.Exception;
        //            Errors.AddRange(saveResult.Errors);
        //        }
        //    }
        //    else
        //    {
        //        var saveResult = await item.NavPermission.RemoveModelAsync(false, context, transaction);
        //        /* skip child nav */
        //        result.IsSucceed = saveResult.IsSucceed;
        //        if (result.IsSucceed)
        //        {
        //            foreach (var child in item.ChildPages)
        //            {
        //                child.PortalPage.NavPermission.IsActived = false;
        //                result = await HandlePermission(child.PortalPage, context, transaction);
        //            }
        //        }

        //        if (!result.IsSucceed)
        //        {
        //            result.Exception = saveResult.Exception;
        //            Errors.AddRange(saveResult.Errors);
        //        }
        //    }

        //    return result;
        //}

        #endregion Expands
    }
}