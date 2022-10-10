using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace WebNangCao_MVC.Models.Idol
{
    public class IdolProfile
    {
        public IdolProfile()
        {

        }
        public IdolProfile(string id, string fullName, string avatar, string description)
        {
            this.id = id;
            this.fullName = fullName;
            this.avatar = avatar;
            this.description = description;
        }
        
        public string id { get; set; }
        public string fullName { get; set; } = string.Empty;
        public string avatar { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
    }
}
