using System;
using AutoFixture;
using GreenFoxFinalHomework.Database;
using Microsoft.EntityFrameworkCore;
using GreenFoxFinalHomework.Models;
using Moq;

namespace GreenFoxFinalHomework_UnitTests
{
    public class MoqDataSetup
    {
        public static Mock<DbSet<T>> SetupMockSet<T>(IQueryable<T> data) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();

            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }
    }
}

