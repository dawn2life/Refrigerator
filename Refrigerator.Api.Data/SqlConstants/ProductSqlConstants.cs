using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator.Api.Data.SqlConstants
{
    internal class ProductSqlConstants
    {
        internal const string SelectProducts = @"SELECT [Id]
                                                       ,[Name]
                                                       ,[BaseUnit]
                                                       ,[ExpirationDate]
                                                 FROM [dbo].[Products]";

        internal const string SelectProductById = @"SELECT [Id]
                                                       ,[Name]
                                                       ,[BaseUnit]
                                                       ,[ExpirationDate]
                                                 FROM [dbo].[Products]
                                                 WHERE Id = @Id";
    }
}
