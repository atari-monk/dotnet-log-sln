using System;
using Xunit;

namespace Log.Modern.Lib.Tests;

public class TaskFilterTests
{
    [Theory]
    [InlineData(null, null)]
    public void TestNullFilter(
        int? filterId
        , string? filterName)
    {
        var filterArg = new TaskFilterArgs
        { 
            CategoryId = filterId
            , Name = filterName
        };
        var filterExp = new TaskFilter().GetFilter(filterArg);
        Assert.Null(filterExp);
    }

    [Theory]
    [InlineData(2, 1, false)]
    [InlineData(1, 1, true)]
    public void TestIdFilter(
        int id
        , int? filterId
        , bool expected)
    {
        var filterArg = new TaskFilterArgs
        { 
            CategoryId = filterId 
        };
        var filterExp = new TaskFilter().GetFilter(filterArg);
        ArgumentNullException.ThrowIfNull(filterExp);
        var filter = filterExp.Compile();
        var data = new Data.Task
        { 
            CategoryId = id 
        };
        Assert.Equal(expected, filter(data));
    }

    [Theory]
    [InlineData("you shall not pass", "you my go", false)]
    [InlineData("you my go", "you my go", true)]
    public void TestNameFilter(
        string name
        , string filterName
        , bool expected)
    {
        var filterArg = new TaskFilterArgs
        { 
            Name = filterName 
        };
        var filterExp = new TaskFilter().GetFilter(filterArg);
        ArgumentNullException.ThrowIfNull(filterExp);
        var filter = filterExp.Compile();
        var data = new Data.Task
        { 
            Name = name 
        };
        Assert.Equal(expected, filter(data));
    }

    [Theory]
    [InlineData(1, 1, "you my go", "you my go", true)]
    [InlineData(2, 1, "you shall not pass", "you my go", false)]
    [InlineData(1, 1, "you shall not pass", "you my go", false)]
    [InlineData(2, 1, "you my go", "you my go", false)]
    public void TestIdAndNameFilter(
        int id
        , int? filterId
        , string name
        , string filterName
        , bool expected)
    {
        var filterArg = new TaskFilterArgs
        {
            CategoryId = filterId
            , Name = filterName 
        };
        var filterExp = new TaskFilter().GetFilter(filterArg);
        ArgumentNullException.ThrowIfNull(filterExp);
        var filter = filterExp.Compile();
        var data = new Data.Task 
        { 
            CategoryId = id
            , Name = name 
        };
        Assert.Equal(expected, filter(data));
    }
}