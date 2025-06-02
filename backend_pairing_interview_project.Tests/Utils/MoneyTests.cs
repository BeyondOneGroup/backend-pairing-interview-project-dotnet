using backend_pairing_interview_project.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;

namespace backend_pairing_interview_project.Tests.Utils
{
    public class MoneyTests
    {
        [Fact]
        public void Constructor_ShouldCreateMoney_WhenValueIsValid()
        {
            var money1 = new Money(1.0m);
            Assert.Equals(1.0m, money1.Value);

            var money2 = new Money(0.0m);
            Assert.Equals(0.0m, money2.Value);
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenValueIsNegative()
        {
            Assert.ThrowsException<ArgumentException>(() => new Money(-1.0m));
        }
    }
}
