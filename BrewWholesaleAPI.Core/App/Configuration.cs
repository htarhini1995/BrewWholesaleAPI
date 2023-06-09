﻿using BrewWholesaleAPI.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace BrewWholesaleAPI.Core
{
    public static class Configuration
    {

        #region Properties

        public static string? DbConnectionString { get; set; }

        #endregion

        #region Ctor

        static Configuration()
        {
        }

        #endregion

        #region Public Methods

        internal static BrewWholesaleContext OpenContext(bool enableChangeTracking = true)
        {
            var ctx = new BrewWholesaleContext();
            ctx.Database.SetCommandTimeout(180);
            if (!enableChangeTracking)
            {
                ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }
            return ctx;
        }

        #endregion

    }
}
