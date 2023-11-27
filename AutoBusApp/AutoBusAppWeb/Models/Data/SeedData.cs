using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoBusAppWeb.Models.Data
{
    public class SeedData
    {
        public static void EnsureData(IApplicationBuilder app)
        {
            UrlDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<UrlDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.UrlModels.Any())
            {
                context.AddRange(
                    new UrlModel
                    {
                        LongUrl = "https://firstLongUrlExample",
                        ShortUrl = "https://wbcerw1",
                        CreateDate = DateTime.Now,
                        ClickCount = 1
                    },
                    new UrlModel
                    {
                        LongUrl = "https://secondLongUrlExample",
                        ShortUrl = "https://wq2rwq1",
                        CreateDate = DateTime.Now,
                        ClickCount = 0
                    },
                    new UrlModel
                    {
                        LongUrl = "https://thirdLongUrlExample",
                        ShortUrl = "https://fda2wq1",
                        CreateDate = DateTime.Now.AddDays(-2),
                        ClickCount = 5
                    });

                context.SaveChanges();
            }
        }
    }
}
