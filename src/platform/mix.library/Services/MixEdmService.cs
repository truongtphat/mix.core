﻿using Google.Api;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mix.Communicator.Models;
using Mix.Communicator.Services;
using MySqlX.XDevAPI.Relational;
using System.Net.WebSockets;

namespace Mix.Lib.Services
{
    public sealed class MixEdmService : TenantServiceBase
    {
        private readonly IQueueService<MessageQueueModel> _queueService;
        private readonly UnitOfWorkInfo<MixCmsContext> _uow;
        public MixEdmService(
            IHttpContextAccessor httpContextAccessor,
            UnitOfWorkInfo<MixCmsContext> uow,
            IQueueService<MessageQueueModel> queueService) : base(httpContextAccessor)
        {
            _uow = uow;
            _queueService = queueService;
        }

        public async Task<string?> GetEdmTemplate(string filename)
        {
            var edmTemplate = await MixTemplateViewModel.GetRepository(_uow).GetSingleAsync(
               m => m.MixTenantId == CurrentTenant.Id
                        && m.FolderType == MixTemplateFolderType.Edms
                        && m.FileName == filename);
            return edmTemplate?.Content;
        }

        public async Task SendMailWithEdmTemplate(string subject, string templateName, JObject data, string to, string? from = null)
        {
            var template = await GetEdmTemplate(templateName);
            if (template == null)
            {
                MixService.LogError("Edm Template nout found:", templateName);
                return;
            }

            foreach (var prop in data.Properties().ToList())
            {
                if (data.ContainsKey(prop.Name))
                {
                    template = template.Replace($"[[{prop.Name.ToTitleCase()}]]", data.GetValue(prop.Name).ToString());
                }
            }

            EmailMessageModel msg = new()
            {
                Subject = subject,
                Message = template,
                From = from,
                To = to
            };
            _queueService.PushQueue(MixQueueTopics.MixBackgroundTasks, MixQueueActions.SendMail, msg);
        }
    }
}