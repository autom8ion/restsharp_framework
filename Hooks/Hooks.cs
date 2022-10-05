using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace RESTSharpFW.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private IConfigurationSection baseURLSection;
        private IConfigurationSection userNameSection;
        private IConfigurationSection passwordSection;
        private IConfigurationSection userResourceSection;
        private IConfigurationSection repositoryResourceSection;
        private IConfigurationSection tokenSection;
        private IConfigurationSection environmentSection;
        private IConfigurationSection clientidSection;
        private IConfigurationSection redirecturiSection;
        private IConfigurationSection responsetypeSection;
        private IConfigurationSection scopeSection;
        private ScenarioContext context;

        public Hooks(ScenarioContext injectedcontext)
        {
            context = injectedcontext;
        }
        

        public void GetSettings()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            baseURLSection = configuration.GetSection("API:BASE_URL");
            userNameSection = configuration.GetSection("API:UserName");
            passwordSection = configuration.GetSection("API:Password");
            userResourceSection = configuration.GetSection("API:UserResource");
            repositoryResourceSection = configuration.GetSection("API:RepositoryResource");
            tokenSection = configuration.GetSection("API:Token");
            environmentSection = configuration.GetSection("API:Environment");
            clientidSection = configuration.GetSection("API:Client_ID");
            redirecturiSection = configuration.GetSection("API:Redirect_URI");
            responsetypeSection = configuration.GetSection("API:Response_Type");
            scopeSection = configuration.GetSection("API:Scope");

        }

        public IConfiguration Configuration { get; }


        [BeforeScenario]
        public void BeforeScenario()
        {
            GetSettings();

            context.Set<string>(baseURLSection.Value, "BASE_URL");
            context.Set<string>(userNameSection.Value, "UserName");
            context.Set<string>(passwordSection.Value, "Password");
            context.Set<string>(userResourceSection.Value, "UserResource");
            context.Set<string>(repositoryResourceSection.Value, "RepositoryResource");
            context.Set<string>(tokenSection.Value, "Token");
            context.Set<string>(environmentSection.Value, "Environment");

        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
