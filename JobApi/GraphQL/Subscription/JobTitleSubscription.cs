using JobApiApp.JobApi.Models;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JobApiApp.JobApi.GraphQL
{
    public class JobTitleSubscription
    {

        [Subscribe]
        public async ValueTask<ISourceStream<JobTitle>> OnJobTitleGet([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {   
            return await eventReceiver.SubscribeAsync<JobTitle>("ReturnedJobTitle", cancellationToken);
        }
    }
}