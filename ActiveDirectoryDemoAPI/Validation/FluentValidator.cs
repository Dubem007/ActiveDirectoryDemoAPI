using ActiveDirectoryDemoAPI.Model;
using FluentValidation;

namespace ActiveDirectoryDemoAPI.Validation
{
    public class FluentValidator : AbstractValidator<UserDetail>
    {
        public FluentValidator()
        {
           
        }
    }
}
