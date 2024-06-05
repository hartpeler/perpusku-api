using perpusku_api.Model.Enum.MasterData;

namespace perpusku_api.Common
{
    public static class BookGenreExtensions
    {
        public static string GetStringValue(this BookGenre genre)
        {
            var fieldInfo = genre.GetType().GetField(genre.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            return attributes.Length > 0 ? attributes[0].Value : genre.ToString();
        }
    }
}
