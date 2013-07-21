﻿using System;
using Sitecore.Ship.Core.Domain;

namespace Sitecore.Ship.Core.Services
{
    public class ZipEntryDataParser
    {
        public static PackageManifestEntry GetManifestEntry(string dataKey)
        {
            if (dataKey.EndsWith("}"))
            {
                var elements = dataKey.Split(new[] { "_{" }, 2, StringSplitOptions.None);

                return new PackageManifestEntry
                    {
                        ID = new Guid(elements[1].Trim(new[] { '{', '}' })),
                        Path = elements[0]
                    };
            }
            
            if (dataKey.EndsWith("/xml"))
            {
                var elements = dataKey.Split(new[] { "/{" }, 2, StringSplitOptions.None);
                
                return new PackageManifestEntry
                    {
                        ID = new Guid(elements[1].Split(new[] { '}' })[0]),
                        Path = elements[0]
                    };
            }

            return new PackageManifestEntryNotFound();
        }
    }
}