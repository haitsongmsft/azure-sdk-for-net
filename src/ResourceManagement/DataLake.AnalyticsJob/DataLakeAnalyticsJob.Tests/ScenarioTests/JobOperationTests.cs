﻿//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using Microsoft.Azure;
using Microsoft.Azure.Management.DataLake.Analytics;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using Microsoft.Azure.Management.DataLake.AnalyticsJob.Models;
using Microsoft.Azure.Management.DataLake.AnalyticsJob;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace DataLakeAnalyticsJob.Tests
{
    public class JobOperationTests : TestBase
    {
        [Fact] 
        public void SubmitGetListCancelTest()
        {
            TestUtilities.StartTest();
            try
            {
                UndoContext.Current.Start();
                CommonTestFixture commonData = new CommonTestFixture();
                var clientToUse = this.GetDataLakeAnalyticsJobManagementClient();
                var accountClient = this.GetDataLakeAnalyticsManagementClient();

                // Create a test account to submit the job to.
                AzureAsyncOperationResponse responseCreate =
                    accountClient.DataLakeAnalyticsAccount.Create(resourceGroupName: commonData.ResourceGroupName,
                        parameters: new DataLakeAnalyticsAccountCreateOrUpdateParameters
                        {
                            DataLakeAnalyticsAccount = new DataLakeAnalyticsAccount
                            {
                                Name = commonData.DataLakeAnalyticsAccountName,
                                Location = commonData.Location,
                                Properties = new DataLakeAnalyticsAccountProperties
                                {
                                    DefaultDataLakeStoreAccount = commonData.DataLakeAccountName,
                                    DataLakeStoreAccounts = new List<DataLakeStoreAccount>
                                    {
                                        {
                                            new DataLakeStoreAccount
                                            {
                                                Name = commonData.DataLakeAccountName,
                                                Properties = new DataLakeStoreAccountProperties
                                                {
                                                    Suffix = commonData.DataLakeAccountSuffix
                                                }
                                            }
                                        }
                                    }
                                },
                                Tags = new Dictionary<string, string>
                                {
                                    { "testkey","testvalue" }
                                }
                            }
                        });

                Assert.True(responseCreate.Status == OperationStatus.Succeeded);

                // wait for provisioning state to be Succeeded
                // we will wait a maximum of 15 minutes for this to happen and then report failures
                DataLakeAnalyticsAccountGetResponse getResponse = accountClient.DataLakeAnalyticsAccount.Get(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName);
                int timeToWaitInMinutes = 15;
                int minutesWaited = 0;
                while (getResponse.DataLakeAnalyticsAccount.Properties.ProvisioningState != DataLakeAnalyticsAccountStatus.Succeeded && getResponse.DataLakeAnalyticsAccount.Properties.ProvisioningState != DataLakeAnalyticsAccountStatus.Failed && getResponse.DataLakeAnalyticsAccount.Properties.ProvisioningState != DataLakeAnalyticsAccountStatus.Failed && minutesWaited <= timeToWaitInMinutes)
                {
                    TestUtilities.Wait(60000); // Wait for one minute and then go again.
                    minutesWaited++;
                    getResponse = accountClient.DataLakeAnalyticsAccount.Get(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName);
                }

                // Confirm that the account creation did succeed
                Assert.True(getResponse.DataLakeAnalyticsAccount.Properties.ProvisioningState == DataLakeAnalyticsAccountStatus.Succeeded);

                // TODO: Remove this sleep once defect 5022906 is fixed
                TestUtilities.Wait(120000); // Wait for two minutes to submit the job, which gives the CJS queue a chance to create.

                // We need to hardcode the job ID to use for the mocks.
                // TODO: come up with some way to re-generate this when necessary (i.e. re-running/running the test against the server).
                Guid jobId = new Guid("e9d3ac6f-86d0-476d-a1ce-e96d4777c053");
                var secondId = new Guid("a543af0e-166f-4e52-a1ae-70dd7b5a4723");
                // Submit a job to the account
                var jobToSubmit = new JobInformation
                {
                    Name = "azure sdk data lake analytics job",
                    JobId = jobId,
                    DegreeOfParallelism = 2,
                    Type = JobType.USql,
                    Properties = new USqlProperties
                    {
                        Type = JobType.USql,
                        Script = "DROP DATABASE IF EXISTS testdb; CREATE DATABASE testdb;"
                    }
                };

                var createOrBuildParams = new JobInfoBuildOrCreateParameters
                    {
                        Job = jobToSubmit
                    };

                JobInfoBuildOrCreateResponse jobCreateResponse = clientToUse.Jobs.Create(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName, createOrBuildParams);

                // TODO: Once the front end is no longer mocked, do response validation here as well as for all other requests
                Assert.NotNull(jobCreateResponse);

                // Cancel the job
                AzureOperationResponse cancelJobResponse = clientToUse.Jobs.Cancel(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName, jobCreateResponse.Job.JobId);

                // Verify the job was successfully cancelled
                Assert.NotNull(cancelJobResponse);

                // Resubmit the job
                createOrBuildParams.Job.JobId = secondId;
                jobCreateResponse = clientToUse.Jobs.Create(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName, createOrBuildParams);

                Assert.NotNull(jobCreateResponse);

                // Poll the job until it finishes
                JobInfoGetResponse getJobResponse = clientToUse.Jobs.Get(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName, jobCreateResponse.Job.JobId);
                Assert.NotNull(getJobResponse);

                int maxWaitInSeconds = 180; // 3 minutes should be long enough
                int curWaitInSeconds = 0;
                while (getJobResponse.Job.State != JobState.Ended && curWaitInSeconds < maxWaitInSeconds)
                {
                    // wait 5 seconds before polling again
                    TestUtilities.Wait(5000);
                    curWaitInSeconds += 5;
                    getJobResponse = clientToUse.Jobs.Get(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName, jobCreateResponse.Job.JobId);
                    Assert.NotNull(getJobResponse);
                }

                Assert.True(curWaitInSeconds <= maxWaitInSeconds);

                // Verify the job completes successfully
                Assert.True(
                    getJobResponse.Job.State == JobState.Ended && getJobResponse.Job.Result == JobResult.Succeeded,
                    string.Format("Job: {0} did not return success. Current job state: {1}. Actual result: {2}. Error (if any): {3}",
                        getJobResponse.Job.JobId, getJobResponse.Job.State, getJobResponse.Job.Result, getJobResponse.Job.ErrorMessage));

                JobInfoListResponse listJobResponse = clientToUse.Jobs.List(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName, null);
                Assert.NotNull(listJobResponse);

                Assert.True(listJobResponse.Value.Any(job => job.JobId == getJobResponse.Job.JobId));

                // Just compile the job
                var compileResponse = clientToUse.Jobs.Build(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName, createOrBuildParams);

                // list the jobs both with a hand crafted query string and using the parameters
                listJobResponse = clientToUse.Jobs.List(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName, new JobListParameters {Select = "jobId"} );
                Assert.NotNull(listJobResponse);

                Assert.True(listJobResponse.Value.Any(job => job.JobId == getJobResponse.Job.JobId));
                Assert.NotNull(compileResponse);

                listJobResponse = clientToUse.Jobs.ListWithQueryString(commonData.ResourceGroupName, commonData.DataLakeAnalyticsAccountName, "$select=jobId");
                Assert.NotNull(listJobResponse);

                Assert.True(listJobResponse.Value.Any(job => job.JobId == getJobResponse.Job.JobId));
                Assert.NotNull(compileResponse);
            }
            finally
            {
                // we don't catch any exceptions, those should all be bubbled up.
                UndoContext.Current.UndoAll();
                TestUtilities.EndTest();
            }
            
        }
    }
}