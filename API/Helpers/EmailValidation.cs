using System.ComponentModel.DataAnnotations;

namespace API.Helpers
{
    public static class EmailValidation
    {
        public static bool IsValid(string email)
        {
            bool result = false;

            var checkEmail = new EmailAddressAttribute();
            result = checkEmail.IsValid(email);

            return result;
        }
    }
}
