# CS2TSModels
A .NET application for converting C# EF models into TS model files. 

This purpose of this project is to convert C# models (written in entity framework) to TypeScript model files using regular expressions.

Here is an example of a C# file that would go into the program:

``` csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
```

And the resulting TS:

``` typescript
class LoginViewModel {

// [Required]
// [EmailAddress]
email: string;

// [Required]
// [DataType(DataType.Password)]
password: string;

// [Display(Name = "Remember me?")]
rememberMe: boolean;

}
```

As you can see, data annotations currently get turned into comments in the ts code.

##Project Goals

- [x] Convert CS to TS
- [ ] Take in multiple files at once
- [ ] Generate services for typescript
- [ ] Use the required tag to mark inputs as required in TS
- [ ] Make the UI fancier
