namespace FavoDeMel.Infrastructure.Extensions
{
    public static class AppExtensions
    {
        public static bool IsNull<T>(this T value) => value == null;
        public static bool IsNotNull<T>(this T value) => !value.IsNull();
    }
}
