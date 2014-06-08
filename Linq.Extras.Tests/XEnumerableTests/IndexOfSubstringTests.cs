﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Linq.Extras.Tests.XEnumerableTests
{
    [TestFixture]
    class IndexOfSubstringTests
    {
        [Test]
        public void IndexOfSubstring_Throws_If_Source_Is_Null()
        {
            IEnumerable<int> source = null;
            var substring = Enumerable.Empty<int>();
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => source.IndexOfSubstring(substring));
            ex.ParamName.Should().Be("source");
        }

        [Test]
        public void IndexOfSubstring_Throws_If_Substring_Is_Null()
        {
            var source = Enumerable.Empty<int>();
            IEnumerable<int> substring = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            var ex = Assert.Throws<ArgumentNullException>(() => source.IndexOfSubstring(substring));
            ex.ParamName.Should().Be("substring");
        }

        [Test]
        public void IndexOfSubstring_Returns_Zero_If_Source_And_Substring_Are_Empty()
        {
            var source = Enumerable.Empty<int>();
            var substring = Enumerable.Empty<int>();
            int index = source.IndexOfSubstring(substring);
            index.Should().Be(0);
        }

        [Test]
        public void IndexOfSubstring_Returns_Zero_If_Source_Is_Not_Empty_And_Substring_Is_Empty()
        {
            var source = new[] { 1, 2, 3 };
            var substring = Enumerable.Empty<int>();
            int index = source.IndexOfSubstring(substring);
            index.Should().Be(0);
        }

        [Test]
        public void IndexOfSubstring_Returns_MinusOne_If_Source_Is_Empty_And_Substring_Is_Not_Empty()
        {
            var source = Enumerable.Empty<int>();
            var substring = new[] { 1, 2, 3 };
            int index = source.IndexOfSubstring(substring);
            index.Should().Be(-1);
        }

        [Test]
        public void IndexOfSubstring_Returns_MinusOne_If_Substring_Is_Not_Found()
        {
            var source = new[] { 4, 8, 15, 16, 23, 42 };
            var substring = new[] { 1, 2, 3 };
            int index = source.IndexOfSubstring(substring);
            index.Should().Be(-1);
        }

        [Test]
        public void IndexOfSubstring_Returns_Index_Of_First_Substring()
        {
            var source = new[] { 4, 8, 15, 16, 23, 42 };
            var substring = new[] { 15, 16, 23 };
            int index = source.IndexOfSubstring(substring);
            index.Should().Be(2);
        }

        [Test]
        public void IndexOfSubstring_Returns_Index_Of_First_Substring_When_Substring_Starts_In_The_Middle_Of_An_Incomplete_Match()
        {
            var source = new[] { 4, 8, 15, 16, 15, 16, 23, 42 };
            var substring = new[] { 15, 16, 23 };
            int index = source.IndexOfSubstring(substring);
            index.Should().Be(4);
        }
    }
}
