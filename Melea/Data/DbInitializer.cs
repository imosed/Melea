using System.Linq;
using Melea.Models;

namespace Melea.Data
{
    public class DbInitializer
    {
        public static void Initialize(MeleaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Oils.Any()) return;

            var oils = new[]
            {
                new EssentialOil { Name = "Lavender" },
                new EssentialOil { Name = "Tea Tree" },
                new EssentialOil { Name = "Citronella" },
                new EssentialOil { Name = "Pine" },
                new EssentialOil { Name = "Spruce" },
                new EssentialOil { Name = "Cypress" },
                new EssentialOil { Name = "Rosemary" },
                new EssentialOil { Name = "Patchouli" },
                new EssentialOil { Name = "Sandalwood" },
                new EssentialOil { Name = "Cedarwood" },
                new EssentialOil { Name = "Frankincense" },
                new EssentialOil { Name = "Lemon" },
                new EssentialOil { Name = "Grapefruit" },
                new EssentialOil { Name = "Cardamom" },
                new EssentialOil { Name = "Wild Orange" },
                new EssentialOil { Name = "Eucalyptus" },
                new EssentialOil { Name = "Lemongrass" },
                new EssentialOil { Name = "Nutmeg" },
                new EssentialOil { Name = "Spearmint" },
                new EssentialOil { Name = "Peppermint" },
                new EssentialOil { Name = "Bergamot" },
                new EssentialOil { Name = "Blood Orange" },
                new EssentialOil { Name = "Clary Sage" },
                new EssentialOil { Name = "Geranium" },
                new EssentialOil { Name = "Ylang Ylang" },
                new EssentialOil { Name = "Ginger" },
                new EssentialOil { Name = "Basil" }
            };
            
            context.Oils.AddRange(oils);
            context.SaveChanges();
        }
    }
}