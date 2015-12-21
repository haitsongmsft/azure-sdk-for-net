// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.13.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Resources.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Policy assignment.
    /// </summary>
    public partial class PolicyAssignment : IResource
    {
        /// <summary>
        /// Initializes a new instance of the PolicyAssignment class.
        /// </summary>
        public PolicyAssignment() { }

        /// <summary>
        /// Initializes a new instance of the PolicyAssignment class.
        /// </summary>
        public PolicyAssignment(string name = default(string), string scope = default(string), string displayName = default(string), string policyDefinitionId = default(string))
        {
            Name = name;
            Scope = scope;
            DisplayName = displayName;
            PolicyDefinitionId = policyDefinitionId;
        }

        /// <summary>
        /// Gets or sets the policy assignment name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the policy assignment scope.
        /// </summary>
        [JsonProperty(PropertyName = "properties.scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment display name.
        /// </summary>
        [JsonProperty(PropertyName = "properties.displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the policy definition Id.
        /// </summary>
        [JsonProperty(PropertyName = "properties.policyDefinitionId")]
        public string PolicyDefinitionId { get; set; }

    }
}