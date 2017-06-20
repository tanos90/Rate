namespace Rate.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    using global::DAL;
    using global::DAL.Models;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<RateflixContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RateflixContext context)
        {
            context.Flicks.AddOrUpdate(
                        new Flick
                        {
                            Title = "The Matrix",
                            Year = "1999",
                            Rated = "R",
                            Released = "31 Mar 1999",
                            Runtime = "136 min",
                            Genre = "Action, Sci-Fi",
                            Director = "Lana Wachowski, Lilly Wachowski",
                            Writer = "Lilly Wachowski, Lana Wachowski",
                            Actors = "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving",
                            Plot = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                            Language = "English",
                            Country = "USA",
                            Awards = "Won 4 Oscars. Another 33 wins & 43 nominations.",
                            Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg",
                            Metascore = "73",
                            ImdbRating = "8.7",
                            Id = "tt0133093",
                            Type = "movie",
                            Response = "True"
                        });
            context.Reviews.AddOrUpdate(
                new Review
                {
                    Flick_Id = "tt0133093",
                    Id = "1",
                    ReviewText = "Great sci-fi"
                });
            SaveChanges(context);
        }

        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
