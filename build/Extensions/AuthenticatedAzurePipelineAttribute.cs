using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Extensions;
using JetBrains.Annotations;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.AzurePipelines.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;

[SuppressMessage("ReSharper", "CheckNamespace")]
public class AuthenticatedPipelineAttribute : AzurePipelinesAttribute {
  public AuthenticatedPipelineAttribute([CanBeNull] string suffix, AzurePipelinesImage image,
    params AzurePipelinesImage[] images)
    : base(suffix, image, images) { }

  protected override AzurePipelinesJob GetJob(ExecutableTarget executableTarget,
    LookupTable<ExecutableTarget, AzurePipelinesJob> jobs, IReadOnlyCollection<ExecutableTarget> relevantTargets) {
    var job = base.GetJob(executableTarget, jobs, relevantTargets);

    var downloads = (
      from pub in job.PublishArtifacts
      select pub).ToArray();

    return new AuthenticatedPipelinesJob {
      Name = job.Name,
      DisplayName = job.DisplayName,
      BuildCmdPath = job.BuildCmdPath,
      Dependencies = job.Dependencies,
      Parallel = job.Parallel,
      PartitionName = job.PartitionName,
      InvokedTargets = job.InvokedTargets,
      PublishArtifacts = job.PublishArtifacts,
      DownloadArtifacts = downloads
    };
  }
}