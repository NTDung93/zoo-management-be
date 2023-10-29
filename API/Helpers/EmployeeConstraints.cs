namespace API.Helpers
{
    public static class EmployeeConstraints
    {
        public const string ADMIN_ROLE = "admin";
        public const string STAFF_ROLE = "staff";
        public const string TRAINER_ROLE = "trainer";
        
        public const byte DELETED = 1;
        public const byte NOT_DELETED = 0;
        public const string DEFAULT_PASSWORD = "123";

        public const string EMPLOYEE_ID_FORMAT = @"^E\d{3}$";
        // For Vietnamese phone number
        public const string PHONE_NUMBER_FORMAT = @"(84|0[3|5|7|8|9])+([0-9]{8})\b";
        // Not specific for Vietnam
        public const string CITIZEN_ID_FORMAT = @"^(?!.*(\d)\1{8,12})\d{9,13}$";
    }
}
