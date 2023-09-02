using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator.Api.Data.SqlConstants
{
    internal class FridgeActivityLogSqlConstants
    {
        internal const string SelectLogs = @"SELECT [Id]
                                                   ,[ProductId]
                                                   ,[Type]
                                                   ,[ActivityDate]
                                                   ,[Quantity]
                                             FROM [dbo].[FridgeActivityLogs]";
    }
}
