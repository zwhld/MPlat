﻿using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Camc.MES53.ApiClient;
using Camc.MES53.Configuration;
using Camc.MES53.Core.Dependency;
using Camc.MES53.Core.Threading;
using Camc.MES53.Localization;
using Camc.MES53.Localization.Resources;
using Camc.MES53.UI;

namespace Camc.MES53.ViewModels.Base
{
    public static class UserConfigurationManager
    {
        private static readonly Lazy<IApplicationContext> AppContext = new Lazy<IApplicationContext>(
            DependencyResolver.Resolve<IApplicationContext>
        );

        private static IAccessTokenManager AccessTokenManager => DependencyResolver.IocManager.Resolve<IAccessTokenManager>();

        public static async Task GetIfNeedsAsync()
        {
            if (AppContext.Value.Configuration != null)
            {
                return;
            }

            await GetAsync();
        }

        public static async Task GetAsync(Func<Task> successCallback = null)
        {
            var userConfigurationService = DependencyResolver.IocManager.Resolve<UserConfigurationService>();
            userConfigurationService.OnAccessTokenRefresh = App.OnAccessTokenRefresh;
            userConfigurationService.OnSessionTimeOut = App.OnSessionTimeout;

            await WebRequestExecuter.Execute(
                async () => await userConfigurationService.GetAsync(AccessTokenManager.IsUserLoggedIn),
                async result =>
                {
                    AppContext.Value.Configuration = result;
                    SetCurrentCulture();
                    AppContext.Value.CurrentLanguage = result.Localization.CurrentLanguage;
                    WarnIfUserHasNoPermission();
                    if (successCallback != null)
                    {
                        await successCallback();
                    }
                },
                _ =>
                {
                    App.ExitApplication();
                    return Task.CompletedTask;
                },
                () => DependencyResolver
                    .IocManager
                    .Release(userConfigurationService)
            );
        }

        private static void WarnIfUserHasNoPermission()
        {
            if (!AccessTokenManager.IsUserLoggedIn)
            {
                return;
            }

            var hasAnyPermission = AppContext.Value.Configuration.Auth.GrantedPermissions != null &&
                                   AppContext.Value.Configuration.Auth.GrantedPermissions.Any();

            if (!hasAnyPermission)
            {
                UserDialogHelper.Warn("NoPermission");
            }
        }

        private static void SetCurrentCulture()
        {
            var locale = DependencyResolver.Resolve<ILocale>();
            var userCulture = GetUserCulture(locale);

            locale.SetLocale(userCulture);
            LocalTranslation.Culture = userCulture;
        }

        private static CultureInfo GetUserCulture(ILocale locale)
        {
            if (AppContext.Value.Configuration.Localization.CurrentCulture.Name == null)
            {
                return locale.GetCurrentCultureInfo();
            }

            try
            {
                return new CultureInfo(AppContext.Value.Configuration.Localization.CurrentCulture.Name);
            }
            catch (CultureNotFoundException)
            {
                return locale.GetCurrentCultureInfo();
            }
        }

    }
}