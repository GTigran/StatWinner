using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatWinner.CommonExtensions
{
    public static class PersonFullNameBuilder
    {
        public static string BuildFullName(string firstName,string middleName, string lastName)
        {
            string fullNameTemplate = "{0} {1}";
            string fullName;

            if (middleName != String.Empty)
            {
                var firstMiddleNames = String.Format(fullNameTemplate, firstName, middleName);
                fullName = String.Format(fullNameTemplate, firstMiddleNames, lastName);
            }
            else
            {
                fullName = String.Format(fullNameTemplate, firstName, lastName);
            }

            return fullName;
        }
    }
}
