namespace AngularAsyncValidator.Api.Data
{
    public static class SeedData
    {
        public static void Seed(AngularAsyncValidatorDbContext context)
        {
            context.Profiles.Add(new()
            {
                Email = "quinntynebrown@gmail.com"
            });

            context.SaveChanges();
        }
    }
}
