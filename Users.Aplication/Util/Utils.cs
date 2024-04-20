namespace Users.Aplication.Util ;
using Contracts.Aplications;

    public class Utils : IUtils
    {
        public int CalculateAge(DateTime dateOfBirth)
        {
            if (dateOfBirth.Year < 10)
            {
                return 0;
            }
            var currentDate = DateTime.Today;
            var age = currentDate.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > currentDate.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
