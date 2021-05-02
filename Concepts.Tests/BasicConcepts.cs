using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Concepts.Tests
{
    public class UnitTest
    {
        private readonly ITestOutputHelper output;
        public UnitTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Fact]
        public void CheckMethodsWithoutArguments()
        {
            Concept hashable = new Concept(new Requires("GetHashCode"));
            
            Assert.True(hashable.Is<int>());
            Assert.True(hashable.Is<object>());
            Assert.True(hashable.Is<string>());
            Assert.True(hashable.Is<List<int>>());
        }
        
        [Fact]
        public void CheckMethodsWithArgument()
        {
            Concept equatable = new Concept(new Requires("Equals", typeof(int)));
            
            Assert.True(equatable.Is<int>());
            Assert.True(equatable.Is<object>());
            Assert.True(equatable.Is<string>());
            Assert.True(equatable.Is<List<int>>());
        }
        
        [Fact]
        public void CheckOriginalMethods()
        {
            Concept addable = new Concept(new Requires("Add", typeof(int)));
            
            Assert.True(addable.Is<List<int>>());
            Assert.False(addable.Is<List<float>>()); // Oooooh first problem, but c++ worse
            
            Assert.False(addable.Is<int>());
        }
        
        [Fact]
        public void BoolExpressionRequires()
        {
            Concept even = new Concept(
                new Requires(34 % 2 == 0), 
                new Requires(10 % 2 == 0), 
                new Requires(new Requires(true).Is<object>())
            );

            Assert.True(even.Is<object>()); // use all type
        }
    }
}