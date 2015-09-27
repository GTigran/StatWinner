
namespace StatWinner.CommonExtensions
{
    /// <summary>
    /// Integer Extensions
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Checks whether given number is equal to 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="numsToCheck"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static bool In(this int num, params int[] numsToCheck)
        {
            if (numsToCheck == null)
            {
                return false;
            }

            foreach (var numToCheck in numsToCheck)
            {
                if (numToCheck == num)
                {
                    return true;
                }
            }
            return false;
        }
    }
}