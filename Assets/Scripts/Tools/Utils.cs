namespace Tools
{
    /// <summary>
    /// Class which implements general purpose tools.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Returns a random element from the given array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="rand"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T RandomElementUsing<T>(this T[] array, System.Random rand)
        {
            return array[rand.Next(array.Length)];
        }
    }
}
