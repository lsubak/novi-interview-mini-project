using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace NoviInterviewMiniProject.Services
{
    public interface IGlobalSettings
    {
        string ApiKey { get; }
        string ApiUrl { get; }
    }
    public class GlobalSettings : IGlobalSettings
    {
        public string ApiKey => ConfigurationManager.AppSettings["ApiKey"];
        public string ApiUrl => ConfigurationManager.AppSettings["ApiUrl"];

    }
}