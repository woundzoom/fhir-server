// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System;

namespace Microsoft.Health.Fhir.Core.Features.Operations.ConvertData.Models
{
    public class ContainerRegistryArtifact
    {
        public string LoginServer { get; set; }

        public string ImageName { get; set; }

        public string Digest { get; set; }

        /// <summary>
        /// Determines whether current artifact contains the target artifact
        /// </summary>
        /// <param name="target">Target artifact</param>
        /// <returns>A boolean value indicates whether this artifact contains the target.</returns>
        public bool Contains(ContainerRegistryArtifact target)
        {
            if (!string.Equals(LoginServer, target.LoginServer, StringComparison.OrdinalIgnoreCase)
                || (!string.IsNullOrEmpty(ImageName) && !string.Equals(ImageName, target.ImageName, StringComparison.OrdinalIgnoreCase))
                || (!string.IsNullOrEmpty(Digest) && !string.Equals(Digest, target.Digest, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return $"{LoginServer}/{ImageName}@{Digest}";
        }
    }
}
