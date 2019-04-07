using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Models
{
    public class SettingsModel: AuditoryBaseModel
    {
        public string DomainName { get; set; }
        public string SiteTitle { get; set; }
        public string ContactEmail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactServerName { get; set; }
        public int ContactServerPort { get; set; }
        public bool ContactUseSSL { get; set; }
        public string ContactBodyHtml { get; set; }
        public string ContactUser { get; set; }
        public string ContactPassword { get; set; }
        public string GoogleMapsLink { get; set; }
        public string Addresses { get; set; }
        public string Phones { get; set; }
        public string GoogleAnalitycs { get; set; }
        public string ShareIt { get; set; }
        public string AdminUser { get; set; }
        public string AdminPassword { get; set; }
    }
}
