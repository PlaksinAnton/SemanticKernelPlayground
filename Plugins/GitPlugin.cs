using Microsoft.SemanticKernel;
//using Microsoft.SemanticKernel.SkillDefinition;
using LibGit2Sharp;
using System.ComponentModel;
using System.Text;

namespace SemanticKernelPlayground.Plugins;

public class GitPlugin
{
    private string _repoPath = "."; // По умолчанию текущая папка

    //[KernelFunction]
    //public void SetRepoPath(string path)
    //{
    //    _repoPath = path;
    //}

    [KernelFunction, Description("Gets last commits for repository if it exists")]
    public string GetLatestCommitsForRepository(string repository, int count = 5)
    {
        if (!Directory.Exists(repository))
        {
            return $"Directory '{repository}' does not exist.";
        }

        if (!Repository.IsValid(repository))
        {
            return $"Directory '{repository}' is not a valid Git repository.";
        }

        try
        {
            using var repo = new Repository(repository);
            var commits = repo.Commits.Take(count);

            var sb = new StringBuilder();
            foreach (var commit in commits)
            {
                sb.AppendLine($"{commit.Author.Name}: {commit.MessageShort}");
            }

            return sb.ToString();
        }
        catch (Exception ex)
        {
            return $"Failed to read commits: {ex.Message}";
        }
    }
}
