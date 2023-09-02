namespace Refrigerator.Api.Data.SqlConstants
{
    internal class StockSqlConstants
    {
        internal const string SelectStocks = @"SELECT [Id]
                                                     ,[ProductId]
                                                     ,[Quantity]
                                                     ,[PurchaseDate]
                                                     ,[IsExpired]
                                               FROM [dbo].[Stocks]";

        internal const string SelectStockById = @"SELECT [Id]
                                                     ,[ProductId]
                                                     ,[Quantity]
                                                     ,[PurchaseDate]
                                                     ,[IsExpired]
                                                  FROM [dbo].[Stocks]
                                                  WHERE ProductId = @ProductId";

        internal const string SelectStockItemsToUpdateExpiration = @"SELECT [Id]
                                                                           ,[ProductId]
                                                                           ,[Quantity]
                                                                           ,[PurchaseDate]                                                                         
                                                                     FROM
                                                                         Stocks
                                                                     WHERE
                                                                         IsExpired = 0";

        internal const string SelectExpiredStocks = @"SELECT [Id]
                                                     ,[ProductId]
                                                     ,[Quantity]
                                                     ,[PurchaseDate]
                                               FROM [dbo].[Stocks]
                                               WHERE IsExpired = 1";

    }
}
