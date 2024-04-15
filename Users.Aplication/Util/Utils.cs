using Users.Aplication.Contracts.Aplications;

namespace Users.Aplication.Util
{
    public class Utils : IUtils
    {
        public int CalculateAge(DateTime dateOfBirth)
        {


            if(dateOfBirth.Year<10) return 0;
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > currentDate.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
