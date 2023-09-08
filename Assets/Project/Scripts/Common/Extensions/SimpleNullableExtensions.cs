using System;

namespace PromoTest.Project.Common.Extensions
{
    public static class SimpleNullableExtensions
    {
        public static void VerifyNotNull<T>(this T nullable, string customErrorMessage = "")
            where T : class
        {
            if (nullable != null)
            {
                return;
            }
            
            throw customErrorMessage == string.Empty
                ? new ArgumentNullException(nameof(nullable))
                : new ArgumentNullException(nameof(nullable), customErrorMessage);
        }
    }
}