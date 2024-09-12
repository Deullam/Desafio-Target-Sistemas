using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Target.Deullam.Challenge.Common.Tests.Features.ObjectMothers;
using Target.Deullam.Challenge.Domain.Exceptions;
using Target.Deullam.Challenge.Domain.Features.Distributors;

namespace Target.Deullam.Challenge.Domain.Tests.Features.Distribuidoras
{
    [TestFixture]
    public class DistributorTests
    {
        private Distributor distributor;

        [SetUp]
        public void Initialize()
        {
            distributor = new Distributor();
        }

        [Test]
        public void Test_Distributor_CalculateMinimumBilling_ShouldBe_Ok()
        {
            double expectedminimumValue = 1000;
            distributor = ObjectMother.GetNewValidDistributor();

            double result = distributor.CalculateMinimumBilling();

            result.Should().Be(expectedminimumValue);
            result.Should().NotBe(0);
            result.Should().BeGreaterThan(0);

        }

        [Test]
        public void Test_Distributor_CalculateMinimumBilling_ShouldBe_ThrowException()
        {
            distributor = ObjectMother.GetNewInvalidDistributor();

            Action comparation = () => distributor.CalculateMinimumBilling();
            comparation.Should().Throw<ValuesUndefinedException>();

        }


        [Test]
        public void Test_Distributor_CalculateMaximumBilling_ShouldBe_Ok()
        {
            double expectedmaximumValue = 3000;
            distributor = ObjectMother.GetNewValidDistributor();

            double result = distributor.CalculateMaximumBilling();

            result.Should().Be(expectedmaximumValue);
            result.Should().NotBe(0);
            result.Should().BeGreaterThan(0);

        }

        [Test]
        public void Test_Distributor_CalculateMaximumBilling_ShouldBe_ThrowException()
        {
            distributor = ObjectMother.GetNewInvalidDistributor();

            Action comparation = () => distributor.CalculateMaximumBilling();
            comparation.Should().Throw<ValuesUndefinedException>();
        }


        [Test]
        public void Test_Distributor_CalculateAverageBilling_ShouldBe_Ok()
        {
            double expectedAverageValue = 2000;
            distributor = ObjectMother.GetNewValidDistributor();

            double result = distributor.CalculateAverageBilling();

            result.Should().Be(expectedAverageValue);
            result.Should().NotBe(0);
            result.Should().BeGreaterThan(0);

        }

        [Test]
        public void Test_Distributor_CalculateAverageBilling_ShouldBe_ThrowException()
        {
            distributor = ObjectMother.GetNewInvalidDistributor();

            Action comparation = () => distributor.CalculateDaysAboveAverageBilling();
            comparation.Should().Throw<ValuesUndefinedException>();
        }

        [Test]
        public void Test_Distributor_CalculateDaysAboveAvgBilling_ShouldBe_Ok()
        {
            int daysAboveAvgValue = 1;
            distributor = ObjectMother.GetNewValidDistributor();

            int result = distributor.CalculateDaysAboveAverageBilling();

            result.Should().Be(daysAboveAvgValue);
            result.Should().NotBe(0);
            result.Should().BeGreaterThan(0);

        }
    }
}