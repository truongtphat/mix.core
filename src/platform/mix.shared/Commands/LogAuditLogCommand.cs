﻿
using Mix.Shared.Models;

namespace Mix.Shared.Commands
{
    public class LogAuditLogCommand
    {
        public LogAuditLogCommand()
        {

        }
        public LogAuditLogCommand(string userName, ParsedRequestModel request, Exception ex = null)
        {
            UserName = userName;
            Request = request;
            Exception = ex;
        }
        public string UserName { get; set; }
        public ParsedRequestModel Request { get; set; }
        public Exception Exception { get; set; }

        
    }
}