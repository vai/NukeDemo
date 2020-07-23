using Nuke.Common;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

#region demo refs
using Nuke.Common.Tools.DocFX;
using Nuke.Common.Tools.Docker;
using Nuke.Common.ChangeLog;
using Nuke.Common.Tools.EntityFramework;
using Nuke.Common.Tools.GitReleaseManager;
using Nuke.Common.Tools.Helm;
using Nuke.Common.Tools.InspectCode;
using Nuke.Common.Tools.Kubernetes;
using Nuke.Common.Tools.NSwag;
using Nuke.Common.Tools.SpecFlow;
using Nuke.Common.Tools.TestCloud;
#endregion


[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
[AuthenticatedAzurePipeline(
    null,
    AzurePipelinesImage.WindowsLatest,
    AzurePipelinesImage.UbuntuLatest,
    AzurePipelinesImage.MacOsLatest,
    InvokedTargets = new[] {
        nameof(Compile)
    },
    NonEntryTargets = new[] {nameof(Restore)},
    PullRequestsBranchesInclude = new[] {
        "hotfix/*", "release/*", "master"
    },
    TriggerBranchesInclude = new[] {
        "feature/*", "hotfix/*", "release/*", "user/*", "master"
    }, TriggerPathsExclude = new[] {"docs"}, PullRequestsAutoCancel = true)]
[DotNetVerbosityMapping]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;
    
    [Solution] readonly Solution Solution;
    [GitRepository] readonly GitRepository GitRepository;
    [GitVersion(NoFetch = true)] readonly GitVersion GitVersion;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .SetAssemblyVersion(GitVersion.AssemblySemVer)
                .SetFileVersion(GitVersion.AssemblySemFileVer)
                .SetInformationalVersion(GitVersion.InformationalVersion)
                .EnableNoRestore());
        });

}
