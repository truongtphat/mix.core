﻿using Mix.Lib.Publishers;
using Mix.Portal.Domain.ViewModels;
using Mix.Queue.Engines.MixQueue;

namespace Mix.Portal.Publishers
{
    public class PageContentPublisherService : PublisherService
    {
        static string topicId = typeof(MixPageContentViewModel).FullName;
        public PageContentPublisherService(
            IQueueService<MessageQueueModel> queueService, 
            IConfiguration configuration, IWebHostEnvironment environment,
            MixMemoryMessageQueue<MessageQueueModel> queueMessage) 
            : base(topicId, queueService, configuration, environment, queueMessage)
        {
        }
    }
}