using FizzWare.NBuilder;
using Newtonsoft.Json.Linq;
using FakerDotNet;

namespace RESTSharpFW.Data
{
    public class RepositoryBuilder
    {
        public static JObject BuildRepository()
        {
            Repository jobj = Builder<Repository>.CreateNew()
                    .With(c => c.name = Faker.Hipster.Word())
                    .With(c => c.description = Faker.Hipster.Sentence(4, true, 6))
                    .With(c => c.homepage = "https://github.com")
                    .With(c => c._private = true)
                    .With(c => c.has_issues = true)
                    .With(c => c.has_projects = true)
                    .With(c => c.has_wiki = true)
                    .With(c => c.is_template = false)
                    .With(c => c.auto_init = true)
                    .With(c => c.gitignore_template = "VisualStudio")
                    .With(c => c.license_template = "mit")
                    .With(c => c.allow_squash_merge = true)
                    .With(c => c.allow_merge_commit = true)
                    .With(c => c.allow_rebase_merge = true)
                .Build();

            return Builder.ConvertBuilderToJObject(jobj);

        }
    }
}
