// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.ServiceBus.Models;

namespace Microsoft.WindowsAzure.Management.ServiceBus
{
    /// <summary>
    /// The Service Bus Management API includes operations for managing Service
    /// Bus namespaces.
    /// </summary>
    public partial interface INamespaceOperations
    {
        /// <summary>
        /// Checks the availability of the given service namespace across all
        /// Windows Azure subscriptions. This is useful because the domain
        /// name is created based on the service namespace name.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj870968.aspx
        /// for more information)
        /// </summary>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response to a query for the availability status of a namespace
        /// name.
        /// </returns>
        Task<CheckNamespaceAvailabilityResponse> CheckAvailabilityAsync(string namespaceName, CancellationToken cancellationToken);
        
        /// <summary>
        /// Creates a new service namespace. Once created, this namespace's
        /// resource manifest is immutable. This operation is idempotent.
        /// (see http://msdn.microsoft.com/en-us/library/windowsazure/jj856303.aspx
        /// for more information)
        /// </summary>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <param name='region'>
        /// The namespace region.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response to a request for a particular namespace.
        /// </returns>
        Task<ServiceBusNamespaceResponse> CreateAsync(string namespaceName, string region, CancellationToken cancellationToken);
        
        /// <summary>
        /// The create namespace authorization rule operation creates an
        /// authorization rule for a namespace
        /// </summary>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <param name='rule'>
        /// The shared access authorization rule.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A response to a request for a particular authorization rule.
        /// </returns>
        Task<ServiceBusAuthorizationRuleResponse> CreateAuthorizationRuleAsync(string namespaceName, ServiceBusSharedAccessAuthorizationRule rule, CancellationToken cancellationToken);
        
        /// <summary>
        /// Creates a new service namespace. Once created, this namespace's
        /// resource manifest is immutable. This operation is idempotent.
        /// (see http://msdn.microsoft.com/en-us/library/windowsazure/jj856303.aspx
        /// for more information)
        /// </summary>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <param name='namespaceEntity'>
        /// The service bus namespace.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response to a request for a particular namespace.
        /// </returns>
        Task<ServiceBusNamespaceResponse> CreateNamespaceAsync(string namespaceName, ServiceBusNamespaceCreateParameters namespaceEntity, CancellationToken cancellationToken);
        
        /// <summary>
        /// Deletes an existing namespace. This operation also removes all
        /// associated entities including queues, topics, relay points, and
        /// messages stored under the namespace.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj856296.aspx
        /// for more information)
        /// </summary>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        Task<OperationResponse> DeleteAsync(string namespaceName, CancellationToken cancellationToken);
        
        /// <summary>
        /// The delete namespace authorization rule operation deletes an
        /// authorization rule for a namespace
        /// </summary>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <param name='ruleName'>
        /// The rule name.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        Task<OperationResponse> DeleteAuthorizationRuleAsync(string namespaceName, string ruleName, CancellationToken cancellationToken);
        
        /// <summary>
        /// Returns the description for the specified namespace.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/dn140232.aspx
        /// for more information)
        /// </summary>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response to a request for a particular namespace.
        /// </returns>
        Task<ServiceBusNamespaceResponse> GetAsync(string namespaceName, CancellationToken cancellationToken);
        
        /// <summary>
        /// The get authorization rule operation gets an authorization rule for
        /// a namespace by name.
        /// </summary>
        /// <param name='namespaceName'>
        /// The namespace to get the authorization rule for.
        /// </param>
        /// <param name='entityName'>
        /// The entity name to get the authorization rule for.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A response to a request for a particular authorization rule.
        /// </returns>
        Task<ServiceBusAuthorizationRuleResponse> GetAuthorizationRuleAsync(string namespaceName, string entityName, CancellationToken cancellationToken);
        
        /// <summary>
        /// The namespace description is an XML AtomPub document that defines
        /// the desired semantics for a service namespace. The namespace
        /// description contains the following properties.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj873988.aspx
        /// for more information)
        /// </summary>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A response to a request for a list of namespaces.
        /// </returns>
        Task<ServiceBusNamespaceDescriptionResponse> GetNamespaceDescriptionAsync(string namespaceName, CancellationToken cancellationToken);
        
        /// <summary>
        /// Lists the available namespaces.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/dn140232.asp
        /// for more information)
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response to the request for a listing of namespaces.
        /// </returns>
        Task<ServiceBusNamespacesResponse> ListAsync(CancellationToken cancellationToken);
        
        /// <summary>
        /// The get authorization rules operation gets the authorization rules
        /// for a namespace.
        /// </summary>
        /// <param name='namespaceName'>
        /// The namespace to get the authorization rule for.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A response to a request for a list of authorization rules.
        /// </returns>
        Task<ServiceBusAuthorizationRulesResponse> ListAuthorizationRulesAsync(string namespaceName, CancellationToken cancellationToken);
        
        /// <summary>
        /// The update authorization rule operation updates an authorization
        /// rule for a namespace.
        /// </summary>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <param name='rule'>
        /// Updated access authorization rule.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A response to a request for a particular authorization rule.
        /// </returns>
        Task<ServiceBusAuthorizationRuleResponse> UpdateAuthorizationRuleAsync(string namespaceName, ServiceBusSharedAccessAuthorizationRule rule, CancellationToken cancellationToken);
    }
}
