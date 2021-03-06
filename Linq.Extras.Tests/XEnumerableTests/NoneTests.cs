﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Linq.Extras.Tests.XEnumerableTests
{
    [TestFixture]
    class NoneTests
    {
        [Test]
        public void None_Throws_If_Source_Is_Null()
        {
            IEnumerable<int> source = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => source.None());
            ex.ParamName.Should().Be("source");
        }

        [Test]
        public void None_Returns_True_If_Source_Is_Empty()
        {
            IEnumerable<int> source = XEnumerable.Empty<int>().ForbidMultipleEnumeration();
            source.None().Should().BeTrue();
        }

        [Test]
        public void None_Returns_False_If_Source_Is_Not_Empty()
        {
            IEnumerable<int> source = XEnumerable.Unit(42).ForbidMultipleEnumeration();
            source.None().Should().BeFalse();
        }

        [Test]
        public void None_With_Predicate_Throws_If_Source_Is_Null()
        {
            IEnumerable<int> source = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => source.None(x => x % 2 == 0));
            ex.ParamName.Should().Be("source");
        }

        [Test]
        public void None_With_Predicate_Throws_If_Predicate_Is_Null()
        {
            IEnumerable<int> source = XEnumerable.Empty<int>().ForbidEnumeration();
            Func<int, bool> predicate = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => source.None(predicate));
            ex.ParamName.Should().Be("predicate");
        }

        [Test]
        public void None_With_Predicate_Returns_True_If_Source_Is_Empty()
        {
            var source = XEnumerable.Empty<int>().ForbidMultipleEnumeration();
            source.None(IsEven).Should().BeTrue();
        }

        [Test]
        public void None_With_Predicate_Returns_True_If_No_Item_Matches()
        {
            IEnumerable<int> source = new[] { 1, 3, 5 }.ForbidMultipleEnumeration();
            source.None(IsEven).Should().BeTrue();
        }

        [Test]
        public void None_With_Predicate_Returns_False_If_At_Least_One_Item_Matches()
        {
            IEnumerable<int> source = new[] {1, 2, 3 }.ForbidMultipleEnumeration();
            source.None(IsEven).Should().BeFalse();
        }

        private static bool IsEven(int x)
        {
            return x % 2 == 0;
        }
    }
}
