﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BeetleX.Http.Clients
{
    [AttributeUsage(AttributeTargets.Method)]
    class RouteTemplateAttribute : Attribute
    {
        public RouteTemplateAttribute(string template)
        {
            Templete = template;
        }
        public string Templete { get; set; }

        public string Analysis(string parent)
        {
            if (string.IsNullOrEmpty(Templete))
                return null;
            if (string.IsNullOrEmpty(parent))
                parent = "/";
            if (parent[parent.Length - 1] != '/')
                parent += "/";
            if (!Regex.IsMatch(Templete, @"(\{[A-Za-z0-9]+\})"))
            {
                return null;

            }
            return parent + Templete;
        }
    }
}
