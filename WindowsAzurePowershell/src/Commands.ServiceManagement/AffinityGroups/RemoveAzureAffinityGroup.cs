﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.AffinityGroups
{
    using System.Management.Automation;
    using AutoMapper;
    using Commands.Utilities.Common;
    using Management;
    using Management.Models;

    /// <summary>
    /// Deletes an affinity group.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureAffinityGroup"), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzureAffinityGroup : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Affinity Group name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        internal void ExecuteCommand()
        {
            Mapper.Initialize(m => m.AddProfile<ServiceManagementProfile>());

            ExecuteClientActionNewSM(null, CommandRuntime.ToString(), () => this.ManagementClient.AffinityGroups.Delete(this.Name),
                (s, r) => ContextFactory<OperationStatusResponse, ManagementOperationContext>(s));
        }

        protected override void OnProcessRecord()
        {
            ExecuteCommand();
        }
    }
}
