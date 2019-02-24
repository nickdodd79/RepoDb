﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepoDb.Attributes;
using RepoDb.Interfaces;
using RepoDb.UnitTests.CustomObjects;

namespace RepoDb.UnitTests.Interfaces
{
    [TestClass]
    public class ITraceForDbConnection
    {
        public class TraceEntity
        {
            [Primary, Identity]
            public int Id { get; set; }
            public string Name { get; set; }
        }

        // BatchQuery

        [TestMethod]
        public void TestBeforeBatchQuery()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.BeforeBatchQuery(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.BatchQuery<TraceEntity>(0, 10, null, null, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.BeforeBatchQuery(It.IsAny<CancellableTraceLog>()), Times.Once);
        }

        [TestMethod]
        public void TestAfterBatchQuery()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.AfterBatchQuery(It.IsAny<TraceLog>()));

            // Act
            connection.BatchQuery<TraceEntity>(0, 10, null, null, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.AfterBatchQuery(It.IsAny<TraceLog>()), Times.Once);
        }

        // Count

        [TestMethod]
        public void TestBeforeBulkInsert()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.BeforeCount(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.Count<TraceEntity>(trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.BeforeCount(It.IsAny<CancellableTraceLog>()), Times.Once);
        }

        [TestMethod]
        public void TestAfterCount()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.AfterCount(It.IsAny<TraceLog>()));

            // Act
            connection.Count<TraceEntity>(trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.AfterCount(It.IsAny<TraceLog>()), Times.Once);
        }

        // Delete

        [TestMethod]
        public void TestBeforeDelete()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.BeforeDelete(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.Delete<TraceEntity>(0, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.BeforeDelete(It.IsAny<CancellableTraceLog>()), Times.Once);
        }

        [TestMethod]
        public void TestAfterDelete()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.AfterDelete(It.IsAny<TraceLog>()));

            // Act
            connection.Delete<TraceEntity>(0, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.AfterDelete(It.IsAny<TraceLog>()), Times.Once);
        }

        // InlineInsert

        [TestMethod]
        public void TestBeforeInlineInsert()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.BeforeInlineInsert(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.InlineInsert<TraceEntity>(new { Id = 1, Name = "Name" }, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.BeforeInlineInsert(It.IsAny<CancellableTraceLog>()), Times.Once);
        }

        [TestMethod]
        public void TestAfterInlineInsert()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.AfterInlineInsert(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.InlineInsert<TraceEntity>(new { Id = 1, Name = "Name" }, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.AfterInlineInsert(It.IsAny<TraceLog>()), Times.Once);
        }

        // InlineMerge

        [TestMethod]
        public void TestBeforeInlineMerge()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.BeforeInlineMerge(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.InlineMerge<TraceEntity>(new { Id = 1, Name = "Name" }, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.BeforeInlineMerge(It.IsAny<CancellableTraceLog>()), Times.Once);
        }

        [TestMethod]
        public void TestAfterInlineMerge()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.AfterInlineMerge(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.InlineMerge<TraceEntity>(new { Id = 1, Name = "Name" }, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.AfterInlineMerge(It.IsAny<TraceLog>()), Times.Once);
        }

        // InlineUpdate

        [TestMethod]
        public void TestBeforeInlineUpdate()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.BeforeInlineUpdate(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.InlineUpdate<TraceEntity>(new { Name = "Name" }, te => te.Id == 1, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.BeforeInlineUpdate(It.IsAny<CancellableTraceLog>()), Times.Once);
        }

        [TestMethod]
        public void TestAfterInlineUpdate()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.AfterInlineUpdate(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.InlineUpdate<TraceEntity>(new { Name = "Name" }, te => te.Id == 1, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.AfterInlineUpdate(It.IsAny<TraceLog>()), Times.Once);
        }

        // Insert

        [TestMethod]
        public void TestBeforeInsert()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.BeforeInsert(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.Insert<TraceEntity>(new TraceEntity { Name = "Name" }, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.BeforeInsert(It.IsAny<CancellableTraceLog>()), Times.Once);
        }

        [TestMethod]
        public void TestAfterInsert()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.AfterInsert(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.Insert<TraceEntity>(new TraceEntity { Name = "Name" }, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.AfterInsert(It.IsAny<TraceLog>()), Times.Once);
        }

        // Merge

        [TestMethod]
        public void TestBeforeMerge()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.BeforeMerge(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.Merge<TraceEntity>(new TraceEntity { Id = 1, Name = "Name" }, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.BeforeMerge(It.IsAny<CancellableTraceLog>()), Times.Once);
        }

        [TestMethod]
        public void TestAfterMerge()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.AfterMerge(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.Merge<TraceEntity>(new TraceEntity { Id = 1, Name = "Name" }, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.AfterMerge(It.IsAny<TraceLog>()), Times.Once);
        }

        // Query

        [TestMethod]
        public void TestBeforeQuery()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.BeforeQuery(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.Query<TraceEntity>(te => te.Id == 1, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.BeforeQuery(It.IsAny<CancellableTraceLog>()), Times.Once);
        }

        [TestMethod]
        public void TestAfterQuery()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.AfterQuery(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.Query<TraceEntity>(te => te.Id == 1, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.AfterQuery(It.IsAny<TraceLog>()), Times.Once);
        }

        // QueryMultiple

        [TestMethod]
        public void TestBeforeQueryMultiple()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.BeforeQueryMultiple(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.QueryMultiple<TraceEntity, TraceEntity>(te => te.Id == 1, te => te.Id == 1, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.BeforeQueryMultiple(It.IsAny<CancellableTraceLog>()), Times.Once);
        }

        [TestMethod]
        public void TestAfterQueryMultiple()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.AfterQueryMultiple(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.QueryMultiple<TraceEntity, TraceEntity>(te => te.Id == 1, te => te.Id == 1, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.AfterQueryMultiple(It.IsAny<TraceLog>()), Times.Once);
        }

        // Truncate

        [TestMethod]
        public void TestBeforeTruncate()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.BeforeTruncate(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.Truncate<TraceEntity>(trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.BeforeTruncate(It.IsAny<CancellableTraceLog>()), Times.Once);
        }

        [TestMethod]
        public void TestAfterTruncate()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.AfterTruncate(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.Truncate<TraceEntity>(trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.AfterTruncate(It.IsAny<TraceLog>()), Times.Once);
        }

        // Update

        [TestMethod]
        public void TestBeforeUpdate()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.BeforeUpdate(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.Update<TraceEntity>(new TraceEntity { Id = 1, Name = "Name" }, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.BeforeUpdate(It.IsAny<CancellableTraceLog>()), Times.Once);
        }

        [TestMethod]
        public void TestAfterUpdate()
        {
            // Prepare
            var trace = new Mock<ITrace>();
            var connection = new CustomDbConnection();

            // Setup
            trace.Setup(t => t.AfterUpdate(It.IsAny<CancellableTraceLog>()));

            // Act
            connection.Update<TraceEntity>(new TraceEntity { Id = 1, Name = "Name" }, trace: trace.Object, statementBuilder: new SqlStatementBuilder());

            // Assert
            trace.Verify(t => t.AfterUpdate(It.IsAny<TraceLog>()), Times.Once);
        }
    }
}
