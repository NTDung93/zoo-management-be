namespace API.Helpers
{
    public static class EmpParams
    {
        public const string ADMIN_ROLE = "Admin";
        public const string STAFF_ROLE = "Staff";
        public const string TRAINER_ROLE = "Trainer";

        public const byte DELETED = 1;
        public const byte NOT_DELETED = 0;
        public const string DEFAULT_PASSWORD = "123";

        public const string EMPLOYEE_ID_FORMAT = @"^E\d{3}$";
        public const string PHONE_NUMBER_FORMAT = @"^\d{10,12}$";
        public const string CITIZEN_ID_FORMAT = @"^\d{9,13}$";
        
    }
}
