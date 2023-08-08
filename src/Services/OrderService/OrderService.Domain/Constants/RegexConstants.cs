using System.Text.RegularExpressions;

namespace OrderService.Domain.Constants
{
    public static partial class RegexConstants
    {
        [GeneratedRegex("^\\S+@\\S+\\.\\S+$")]
        public static partial Regex EmailFormatRegex();

        [GeneratedRegex(@"^\d+$")]
        public static partial Regex PositiveNumberRegex();
    }
}