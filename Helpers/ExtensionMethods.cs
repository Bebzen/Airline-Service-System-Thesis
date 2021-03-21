using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AirlineServiceSoftware.Entities;

namespace AirlineServiceSoftware.Helpers
{
    public static class ExtensionMethods
    {
        public static char[] LetterValues =
        {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z'};
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            if (users == null)
            {
                return null;
            }

            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            if (user == null) return null;
            user.Password = null;
            return user;
        }

        public static bool IsValidPESEL(this string input)
        {
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            bool result = false;
            if (input.Length == 11)
            {
                int controlSum = CalculateControlSum(input, weights);
                int controlNum = controlSum % 10;
                controlNum = 10 - controlNum;
                if (controlNum == 10)
                {
                    controlNum = 0;
                }
                int lastDigit = int.Parse(input[input.Length - 1].ToString());
                result = controlNum == lastDigit;
            }
            return result;
        }

        private static int CalculateControlSum(string input, int[] weights, int offset = 0)
        {
            int controlSum = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                controlSum += weights[i + offset] * int.Parse(input[i].ToString());
            }
            return controlSum;
        }

        private static int GetLetterValue(char letter)
        {

            int i;
            for (i = 0; i < LetterValues.Length; i++)
            {
                if (letter == LetterValues[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool IsValidID(this string id)
        {
            int checkSum;

            if (id.Length != 9)
            {
                return false;
            }

            for (int i = 0; i < 3; i++)
            {
                if (GetLetterValue(id[i]) < 10)
                {
                    return false;
                }
            }
            for (int i = 3; i < 9; i++)
            {
                if (GetLetterValue(id[i]) < 0 || GetLetterValue(id[i]) > 9)
                {
                    return false;
                }
            }

            checkSum = 7 * GetLetterValue(id[0]);
            checkSum += 3 * GetLetterValue(id[1]);
            checkSum += 1 * GetLetterValue(id[2]);
            checkSum += 7 * GetLetterValue(id[4]);
            checkSum += 3 * GetLetterValue(id[5]);
            checkSum += 1 * GetLetterValue(id[6]);
            checkSum += 7 * GetLetterValue(id[7]);
            checkSum += 3 * GetLetterValue(id[8]);
            checkSum %= 10;
            if (checkSum != GetLetterValue(id[3]))
            {
                return false;
            }

            return true;

        }

        public static bool IsValidPassword(this string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            var isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password) && hasSymbols.IsMatch(password);
            return isValidated;
        }
    }
}
