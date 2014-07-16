﻿namespace WebUI.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Hosting;
    using System.Xml.Linq;

    public class Config
    {
        private const string ConfigFile = "/config/ContentPackage.config";

        private string FileNameWithPath { get; set; }

        public Dictionary<Guid, string> GetDataTypes()
        {
            FileNameWithPath = HostingEnvironment.MapPath(ConfigFile);

            var result = new Dictionary<Guid, string>();

            if (File.Exists(FileNameWithPath))
            {
                var config = XDocument.Load(FileNameWithPath);

                if (config.Root != null)
                {
                    result = config.Root.Elements()
                        .ToDictionary(dt => new Guid(dt.Attribute("guid").Value), dt => dt.Attribute("type").Value);
                }
            }

            return result;
        }
    }
}