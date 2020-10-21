using System;
using Microsoft.Data.SqlClient;

namespace ImportCsvData
{
    public static class ExceptionExtension
    {
        public static void HandleSaveChangesSqlException(this Exception e, string id)
        {
            SqlException sqlException = e.InnerException as SqlException;

            if (sqlException != null && (sqlException.Number == 2601 || sqlException.Number == 2627))
            {
                Console.WriteLine($"Entry with id '{id}' already in database. Skipping.");
            }
            else
            {
                throw e;
            }
        }
    }
}