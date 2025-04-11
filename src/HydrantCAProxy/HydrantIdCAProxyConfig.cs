/*
Copyright © 2025 Keyfactor

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using Keyfactor.AnyGateway.Extensions;
using System.Collections.Generic;

namespace Keyfactor.Extensions.CAPlugin.HydrantId
{
    public class HydrantIdCAProxyConfig
    {
        public const int DefaultPageSize = 100;

        public class ConfigConstants
        {
            public static string HydrantIdBaseUrl = "HydrantIdBaseUrl";
            public static string HydrantIdAuthId = "AuthId";
            public static string HydrantIdAuthKey = "AuthKey";
            public static string DefaultPageSize = "DefaultPageSize";
        }

        public class Config
        {
            public string HydrantIdBaseUrl { get; set; }
            public string HydrantIdAuthId { get; set; }
            public string HydrantIdAuthKey { get; set; }
        }

        public static class EnrollmentParametersConstants
        {
            public const string ValidityPeriod = "ValidityPeriod";
            public const string ValidityUnits = "ValidityUnits";
        }

        public static Dictionary<string, PropertyConfigInfo> GetPluginAnnotations()
        {
            return new Dictionary<string, PropertyConfigInfo>()
            {
                [ConfigConstants.HydrantIdBaseUrl] = new PropertyConfigInfo()
                {
                    Comments = "The Base URL For the HydrantId Endpoint similar to https://acm-stage.hydrantid.com.  Get this from HydrantId.",
                    Hidden = false,
                    DefaultValue = "",
                    Type = "String"
                },
                [ConfigConstants.HydrantIdAuthId] = new PropertyConfigInfo()
                {
                    Comments = "The AuthId Obtained from HydrantId.",
                    Hidden = false,
                    DefaultValue = "",
                    Type = "Secret"
                },
                [ConfigConstants.HydrantIdAuthKey] = new PropertyConfigInfo()
                {
                    Comments = "The AuthKey Obtained from HydrantId.",
                    Hidden = false,
                    DefaultValue = "",
                    Type = "Secret"
                }
            };
        }

        public static Dictionary<string, PropertyConfigInfo> GetTemplateParameterAnnotations()
        {
            return new Dictionary<string, PropertyConfigInfo>()
            {
                [EnrollmentParametersConstants.ValidityPeriod] = new PropertyConfigInfo()
                {
                    Comments = $"The desired lifetime time period could be Days, Months or Years.",
                    Hidden = false,
                    DefaultValue = "Years",
                    Type = "String"
                },
                [EnrollmentParametersConstants.ValidityUnits] = new PropertyConfigInfo()
                {
                    Comments = $"The desired lifetime time value some number indicating days, months or years.",
                    Hidden = false,
                    DefaultValue = 1,
                    Type = "Number"
                }
            };
        }
    }
}
