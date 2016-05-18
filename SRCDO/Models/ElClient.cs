using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRCDO.Models
{
    public class ElClient
    {
        public int iduser{get;set;}
        public string nickname { get; set; }
        public string password { get; set; }
        public string role{get;set;}
        public string name{get;set;}
        public string lastname{get;set;}
        public string address{get;set;}
        public string email{get;set;}
    }
}