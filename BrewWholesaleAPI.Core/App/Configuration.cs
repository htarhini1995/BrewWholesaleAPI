﻿using BrewWholesaleAPI.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace BrewWholesaleAPI.Core
{
    public static class Configuration
    {
        #region Properties

        public static string? DbConnectionString { get; set; }

        #endregion

        static Configuration()
        {
        }

        #region Public Methods

        internal static BrewWholesaleAPIDbContext OpenContext(bool enableChangeTracking = true)
        {
            var ctx = new BrewWholesaleAPIDbContext();
            //ctx.database.setcommandtimeout(180);
            if (!enableChangeTracking)
            {
                ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }
            return ctx;
        }

        #endregion
    }
}
