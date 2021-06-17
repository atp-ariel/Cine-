using DomainLayer;


namespace RepositoryLayer
{
    public class ConfigRepository
    {
        private ApplicationDbContext context;

        public ConfigRepository()
        {
            context = new ApplicationDbContext();
        }

        public Configurations Get(string keyConfig) => context.Configurations.Find(keyConfig);

        public void Set(string keyConfig, string value)
        {
            var config = Get(keyConfig);
            if (config == null)
                context.Configurations.Add(new Configurations() { KeyConfig = keyConfig, Value = value });
            else
            {
                config.Value = value;
                context.Configurations.Update(config);
            }
            context.SaveChanges();
        }
    }
}
