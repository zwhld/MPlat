﻿using System;
using System.Collections.Generic;

namespace Camc.MES53.Sessions.Dto
{
    public class ApplicationInfoDto
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Currency { get; set; }

        public string CurrencySign { get; set; }

        public bool AllowTenantsToChangeEmailSettings { get; set; }

        public Dictionary<string, bool> Features { get; set; }
    }
}