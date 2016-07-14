using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpToTsModelConverter
{
    public static class Patterns
    {
        // matches any amount of characters, followed by a (space)class(space)
        // intended to match things like public class ClassName
        public static string CLASS_PATTERN = @".*\sclass\s";

        // matches [Required] (and only if that is the content of the entire line)
        // intended to determine which fields are [Required]
        public static string REQUIRED_PATTERN = @"^\[Required\]$";

        // matches anything in braces [] 
        public static string ANNOTATION_PATTERN = @"^\[.*\]$";

        // matches bool or Boolean, follwed by any text, followed by { get; set; }(spaces optional)
        // intended to catch boolean types
        public static string BOOL_PATTERN = @"(bool|Boolean)(\[\])?\s.*\s{\s?get;\s?set;\s?}";

        // matches numeric variables
        public static string NUMBER_PATTERN = @"[^\s]*((I|i)nt.*|(D|d)ecimal|(S|s)ingle|(D|d)ouble|(B|b)yte)(\[\])?\s.*\s{\s?get;\s?set;\s?}";

        //matches string variables nad datetimes
        public static string STRING_PATTERN = @"[^\s]*((S|s)tring|(C|c)har|DateTime)(\[\])?\s.*\s{\s?get;\s?set;\s?}";

        // matches varname {get;set;}(spaces optional)
        // intended to catch all variables in case the specific ones didn't catch them
        public static string VAR_PATTERN = @"[^\s]*\s{\s?get;\s?set;\s?}";
    }
}
