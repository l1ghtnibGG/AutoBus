using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace AutoBusAppBLL.DTOModels
{
    public class UrlEditDto
    {
        public Guid Id { get; set; }
        public string LongUrl { get; set; }

        public string ShortUrl { get; set; }

        public uint ClickCount { get; set; }
    }
}
