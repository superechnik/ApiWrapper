using System.Collections.Generic;

namespace Lib.Services.Validation
{
    public static class ResponseMessages
    {
        public static string GetResponseMessage(int code)
        {
            responseMessage.TryGetValue(code, out var value);

            return value is not null ? value : string.Empty;

        }

        private static readonly Dictionary<int, string> responseMessage =
            new Dictionary<int, string>()
            {
                {200, "Ok"},
                {400, "The request is missing parameters. The required parameters are address and zipcode or address, city and state"}
            };
    }
}