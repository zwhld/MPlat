﻿using System;

namespace Camc.MES53.Url
{
    public class NullAppUrlService : IAppUrlService
    {
        public static IAppUrlService Instance { get; } = new NullAppUrlService();

        private NullAppUrlService()
        {
            
        }

        public string CreateEmailActivationUrlFormat(int? tenantId)
        {
            throw new NotImplementedException();
        }

        public string CreatePasswordResetUrlFormat(int? tenantId)
        {
            throw new NotImplementedException();
        }

        public string CreateEmailActivationUrlFormat(string tenancyName)
        {
            throw new NotImplementedException();
        }

        public string CreatePasswordResetUrlFormat(string tenancyName)
        {
            throw new NotImplementedException();
        }
    }
}