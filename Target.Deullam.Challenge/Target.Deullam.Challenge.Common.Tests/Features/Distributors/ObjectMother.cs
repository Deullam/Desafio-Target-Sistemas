using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Target.Deullam.Challenge.Domain.Features.Distributors;

namespace Target.Deullam.Challenge.Common.Tests.Features.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static Distributor GetNewValidDistributor()
        {
            return new Distributor()
            {
                DailyBillingList = new List<double>([3000, 0, 2000, 1000, 0]),

            };
        }

        public static Distributor GetNewInvalidDistributor()
        {
            return new Distributor()
            {
                DailyBillingList = new List<double>([0, 0, 0, 0, 0]),
            };
        }
    }
}
