using eCommerceWebApiBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWebApiBackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Title = "A Tale of Two Cities",
                        Description = "A Tale of Two Cities is a historical novel published in 1859 by Charles Dickens, set in London and Paris before and during the French Revolution. The novel tells the story of the French Doctor Manette, his 18-year-long imprisonment in the Bastille in Paris, and his release to live in London with his daughter Lucie whom he had never met. The story is set against the conditions that led up to the French Revolution and the Reign of Terror.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3c/Tales_serial.jpg",
                        Price = 100
                    },
                    new Product
                    {
                        Id = 2,
                        Title = "The Little Prince",
                        Description = "The Little Prince (French: Le Petit Prince, pronounced is a novella written and illustrated by French writer, and military pilot, Antoine de Saint-Exupéry. It was first published in English and French in the United States by Reynal & Hitchcock in April 1943 and was published posthumously in France following liberation; Saint-Exupéry's works had been banned by the Vichy Regime.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/05/Littleprince.JPG",
                        Price = 200
                    },
                    new Product
                    {
                        Id = 3,
                        Title = "Nineteen Eighty-Four",
                        Description = "Nineteen Eighty-Four (also published as 1984) is a dystopian novel and cautionary tale by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance, and repressive regimentation of people and behaviours within society.[3][4] Orwell, a staunch believer in democratic socialism and member of the anti-Stalinist Left, modelled the Britain under authoritarian socialism in the novel on the Soviet Union in the era of Stalinism and on the very similar practices of both censorship and propaganda in Nazi Germany.[5] More broadly, the novel examines the role of truth and facts within societies and the ways in which they can be manipulated.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/51/1984_first_edition_cover.jpg",
                        Price = 300
                    }
                );
        }

        public DbSet<Product> Products { get; set; }
    }
}
