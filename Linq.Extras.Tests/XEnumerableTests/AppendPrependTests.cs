﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Linq.Extras.Tests.XEnumerableTests
{
    [TestFixture]
    class AppendPrependTests
    {
        [Test]
        public void Append_Throws_If_Source_Is_Null()
        {
            IEnumerable<int> source = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            var ex = Assert.Throws<ArgumentNullException>(() => source.Append(42));
            ex.ParamName.Should().Be("source");
        }

        [Test]
        public void Append_Adds_Item_At_End_Of_Sequence()
        {
            var input = new[] { 4, 8, 15, 16, 23 }.ForbidMultipleEnumeration();
            var item = 42;
            var expected = new[] { 4, 8, 15, 16, 23, 42 };
            var actual = input.Append(item);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Prepend_Throws_If_Source_Is_Null()
        {
            IEnumerable<int> source = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            var ex = Assert.Throws<ArgumentNullException>(() => source.Prepend(42));
            ex.ParamName.Should().Be("source");
        }

        [Test]
        public void Prepend_Insert_Item_At_Beginning_Of_Sequence()
        {
            var input = new[] { 8, 15, 16, 23, 42 }.ForbidMultipleEnumeration();
            var item = 4;
            var expected = new[] { 4, 8, 15, 16, 23, 42 };
            var actual = input.Prepend(item);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
