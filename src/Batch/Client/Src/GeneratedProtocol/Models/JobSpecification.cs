// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Batch.Protocol.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Specifies details of the jobs to be created on a schedule.
    /// </summary>
    public partial class JobSpecification
    {
        /// <summary>
        /// Initializes a new instance of the JobSpecification class.
        /// </summary>
        public JobSpecification() { }

        /// <summary>
        /// Initializes a new instance of the JobSpecification class.
        /// </summary>
        /// <param name="poolInfo">The pool on which the Batch service runs the tasks of jobs created under this schedule.</param>
        /// <param name="priority">The priority of jobs created under this schedule.</param>
        /// <param name="displayName">The display name for jobs created under this schedule.</param>
        /// <param name="usesTaskDependencies">The flag that determines if this job will use tasks with dependencies.</param>
        /// <param name="constraints">The execution constraints for jobs created under this schedule.</param>
        /// <param name="jobManagerTask">The details of a Job Manager task to be launched when a job is started under this schedule.</param>
        /// <param name="jobPreparationTask">The Job Preparation task for jobs created under this schedule.</param>
        /// <param name="jobReleaseTask">The Job Release task for jobs created under this schedule.</param>
        /// <param name="commonEnvironmentSettings">A list of common environment variable settings. These environment variables are set for all tasks in jobs created under this schedule (including the Job Manager, Job Preparation and Job Release tasks).</param>
        /// <param name="metadata">A list of name-value pairs associated with each job created under this schedule as metadata.</param>
        public JobSpecification(PoolInformation poolInfo, int? priority = default(int?), string displayName = default(string), bool? usesTaskDependencies = default(bool?), JobConstraints constraints = default(JobConstraints), JobManagerTask jobManagerTask = default(JobManagerTask), JobPreparationTask jobPreparationTask = default(JobPreparationTask), JobReleaseTask jobReleaseTask = default(JobReleaseTask), IList<EnvironmentSetting> commonEnvironmentSettings = default(IList<EnvironmentSetting>), IList<MetadataItem> metadata = default(IList<MetadataItem>))
        {
            Priority = priority;
            DisplayName = displayName;
            UsesTaskDependencies = usesTaskDependencies;
            Constraints = constraints;
            JobManagerTask = jobManagerTask;
            JobPreparationTask = jobPreparationTask;
            JobReleaseTask = jobReleaseTask;
            CommonEnvironmentSettings = commonEnvironmentSettings;
            PoolInfo = poolInfo;
            Metadata = metadata;
        }

        /// <summary>
        /// Gets or sets the priority of jobs created under this schedule.
        /// </summary>
        /// <remarks>
        /// Priority values can range from -1000 to 1000, with -1000 being
        /// the lowest priority and 1000 being the highest priority. The
        /// default value is 0.
        /// </remarks>
        [JsonProperty(PropertyName = "priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// Gets or sets the display name for jobs created under this schedule.
        /// </summary>
        /// <remarks>
        /// The name need not be unique and can contain any Unicode characters
        /// up to a maximum length of 1024.
        /// </remarks>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the flag that determines if this job will use tasks
        /// with dependencies.
        /// </summary>
        [JsonProperty(PropertyName = "usesTaskDependencies")]
        public bool? UsesTaskDependencies { get; set; }

        /// <summary>
        /// Gets or sets the execution constraints for jobs created under this
        /// schedule.
        /// </summary>
        [JsonProperty(PropertyName = "constraints")]
        public JobConstraints Constraints { get; set; }

        /// <summary>
        /// Gets or sets the details of a Job Manager task to be launched when
        /// a job is started under this schedule.
        /// </summary>
        [JsonProperty(PropertyName = "jobManagerTask")]
        public JobManagerTask JobManagerTask { get; set; }

        /// <summary>
        /// Gets or sets the Job Preparation task for jobs created under this
        /// schedule.
        /// </summary>
        [JsonProperty(PropertyName = "jobPreparationTask")]
        public JobPreparationTask JobPreparationTask { get; set; }

        /// <summary>
        /// Gets or sets the Job Release task for jobs created under this
        /// schedule.
        /// </summary>
        [JsonProperty(PropertyName = "jobReleaseTask")]
        public JobReleaseTask JobReleaseTask { get; set; }

        /// <summary>
        /// Gets or sets a list of common environment variable settings. These
        /// environment variables are set for all tasks in jobs created under
        /// this schedule (including the Job Manager, Job Preparation and Job
        /// Release tasks).
        /// </summary>
        [JsonProperty(PropertyName = "commonEnvironmentSettings")]
        public IList<EnvironmentSetting> CommonEnvironmentSettings { get; set; }

        /// <summary>
        /// Gets or sets the pool on which the Batch service runs the tasks of
        /// jobs created under this schedule.
        /// </summary>
        [JsonProperty(PropertyName = "poolInfo")]
        public PoolInformation PoolInfo { get; set; }

        /// <summary>
        /// Gets or sets a list of name-value pairs associated with each job
        /// created under this schedule as metadata.
        /// </summary>
        [JsonProperty(PropertyName = "metadata")]
        public IList<MetadataItem> Metadata { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (PoolInfo == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "PoolInfo");
            }
            if (this.JobManagerTask != null)
            {
                this.JobManagerTask.Validate();
            }
            if (this.JobPreparationTask != null)
            {
                this.JobPreparationTask.Validate();
            }
            if (this.JobReleaseTask != null)
            {
                this.JobReleaseTask.Validate();
            }
            if (this.CommonEnvironmentSettings != null)
            {
                foreach (var element in this.CommonEnvironmentSettings)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
            if (this.PoolInfo != null)
            {
                this.PoolInfo.Validate();
            }
            if (this.Metadata != null)
            {
                foreach (var element1 in this.Metadata)
                {
                    if (element1 != null)
                    {
                        element1.Validate();
                    }
                }
            }
        }
    }
}