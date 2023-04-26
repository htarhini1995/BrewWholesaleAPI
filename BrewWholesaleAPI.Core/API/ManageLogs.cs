using BrewWholesaleAPI.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewWholesaleAPI.Core.API
{
    public static class ManageLogs
    {
        #region Public Methods

        public static void InsertLog(Exception ex)
        {
            var sb = new StringBuilder();
            sb.AppendLine(ex.Message).AppendLine(ex.StackTrace);

            var innerException = ex.InnerException;
            while (innerException != null)
            {
                sb.Append(Environment.NewLine).AppendLine(innerException.Message).AppendLine(ex.StackTrace);
                innerException = innerException.InnerException;
            }

            var log = new Log()
            {
                Date = DateTime.Now,
                Message = ex.Message,
                Exception = sb.ToString()
            };
            log.Insert();
        } 

        #endregion

    }
}
