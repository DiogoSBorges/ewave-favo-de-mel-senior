namespace FavoDeMel.Infrastructure.Extensions
{
    public static class AppExtensions
    {
        /// <summary>
        /// Verifica se o objeto é nulo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNull<T>(this T value) => value == null;

        /// <summary>
        /// Verifica se o objeto não é nulo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNotNull<T>(this T value) => !value.IsNull();

        /// <summary>
        /// Verifica se o número é menor ou igual a zero;
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsLessThanZero(this int number) => number <= 0;
    }
}
