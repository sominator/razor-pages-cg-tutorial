using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesCG.Data;
using System;
using System.Linq;

namespace RazorPagesCG.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesCGContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesCGContext>>()))
            {
                if (context.Character.Any())
                {
                    return;
                }

                context.Character.AddRange(
                        new Character
                        {
                            Name = "Eskander",
                            CreatedDate = DateTime.Parse("2021-5-12"),
                            Profession = "Nightpath",
                            Level = 1,
                            TimesPlayed = 1
                        }
                    );
                context.SaveChanges();
            }
        }
    }
}
