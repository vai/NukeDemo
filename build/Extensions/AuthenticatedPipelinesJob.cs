using System.Linq;
using Nuke.Common.CI.AzurePipelines.Configuration;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Extensions {
  class AuthenticatedPipelinesJob : AzurePipelinesJob {
    protected override void WriteSteps(CustomFileWriter writer) {
      // if (PublishArtifacts.Any()) {
      using (writer.WriteBlock("- task: NuGetAuthenticate@0")) { }
      // }

      DownloadArtifacts.ForEach(x =>
      {
        using (writer.WriteBlock("- task: DownloadBuildArtifacts@0")) {
          writer.WriteLine("displayName: Download Artifacts");
          using (writer.WriteBlock("inputs:")) {
            var parts = x.Split('/');
            var path = parts.SkipLast(1).Join('/').SingleQuote();
            writer.WriteLine("buildType: 'current'");
            writer.WriteLine("downloadType: 'single'");
            writer.WriteLine($"artifactName: {parts.Last()}");
            writer.WriteLine($"downloadPath: {path}");
          }
        }
      });

      base.WriteSteps(writer);
    }
  }
}