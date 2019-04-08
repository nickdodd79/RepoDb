﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoDb.Attributes;
using RepoDb.Enumerations;
using System;

namespace RepoDb.UnitTests.StatementBuilders
{
    [TestClass]
    public class SqlDbProviderCreateQueryTest
    {
        private class TestSqlDbProviderCreateQueryWithoutMappingsClass
        {
            public int Field1 { get; set; }
            public string Field2 { get; set; }
            public DateTime Field3 { get; set; }
        }

        [TestMethod]
        public void TestSqlDbProviderCreateQueryWithoutMappings()
        {
            // Setup
            var statementBuilder = new SqlStatementBuilder();
            var queryBuilder = new QueryBuilder();
            var queryGroup = (QueryGroup)null;

            // Act
            var actual = statementBuilder.CreateQuery<TestSqlDbProviderCreateQueryWithoutMappingsClass>(queryBuilder, queryGroup);
            var expected = $"" +
                $"SELECT [Field1], [Field2], [Field3] " +
                $"FROM [TestSqlDbProviderCreateQueryWithoutMappingsClass] ;";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Map("ClassName")]
        private class TestSqlDbProviderCreateQueryWithClassMappingClass
        {
            public int Field1 { get; set; }
            public string Field2 { get; set; }
            public DateTime Field3 { get; set; }
        }

        [TestMethod]
        public void TestSqlDbProviderCreateQueryWithClassMapping()
        {
            // Setup
            var statementBuilder = new SqlStatementBuilder();
            var queryBuilder = new QueryBuilder();
            var queryGroup = (QueryGroup)null;

            // Act
            var actual = statementBuilder.CreateQuery<TestSqlDbProviderCreateQueryWithClassMappingClass>(queryBuilder, queryGroup);
            var expected = $"" +
                $"SELECT [Field1], [Field2], [Field3] " +
                $"FROM [ClassName] ;";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private class TestSqlDbProviderCreateQueryWithFieldMappingClass
        {
            public int Field1 { get; set; }
            public string Field2 { get; set; }
            [Map("Field4")]
            public DateTime Field3 { get; set; }
        }

        [TestMethod]
        public void TestSqlDbProviderCreateQueryWithFieldMapping()
        {
            // Setup
            var statementBuilder = new SqlStatementBuilder();
            var queryBuilder = new QueryBuilder();
            var queryGroup = (QueryGroup)null;

            // Act
            var actual = statementBuilder.CreateQuery<TestSqlDbProviderCreateQueryWithFieldMappingClass>(queryBuilder, queryGroup);
            var expected = $"" +
                $"SELECT [Field1], [Field2], [Field4] " +
                $"FROM [TestSqlDbProviderCreateQueryWithFieldMappingClass] ;";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private class TestSqlDbProviderCreateQueryWithTopClass
        {
            public int Field1 { get; set; }
            public string Field2 { get; set; }
            public DateTime Field3 { get; set; }
        }

        [TestMethod]
        public void TestSqlDbProviderCreateQueryWithTop()
        {
            // Setup
            var statementBuilder = new SqlStatementBuilder();
            var queryBuilder = new QueryBuilder();
            var queryGroup = (QueryGroup)null;

            // Act
            var actual = statementBuilder.CreateQuery<TestSqlDbProviderCreateQueryWithTopClass>(queryBuilder, queryGroup, top: 10);
            var expected = $"" +
                $"SELECT TOP (10) [Field1], [Field2], [Field3] " +
                $"FROM [TestSqlDbProviderCreateQueryWithTopClass] ;";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private class TestSqlDbProviderCreateQueryWithTableHintClass
        {
            public int Field1 { get; set; }
            public string Field2 { get; set; }
            public DateTime Field3 { get; set; }
        }

        [TestMethod]
        public void TestSqlDbProviderCreateQueryWithTableHint()
        {
            // Setup
            var statementBuilder = new SqlStatementBuilder();
            var queryBuilder = new QueryBuilder();
            var queryGroup = (QueryGroup)null;

            // Act
            var actual = statementBuilder.CreateQuery<TestSqlDbProviderCreateQueryWithTableHintClass>(queryBuilder, queryGroup, null, null, "WITH (INDEX(ANYINDEX), NOLOCK)");
            var expected = $"" +
                $"SELECT [Field1], [Field2], [Field3] " +
                $"FROM [TestSqlDbProviderCreateQueryWithTableHintClass] WITH (INDEX(ANYINDEX), NOLOCK) ;";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSqlDbProviderCreateQueryWithTableHintViaSqlTableHints()
        {
            // Setup
            var statementBuilder = new SqlStatementBuilder();
            var queryBuilder = new QueryBuilder();
            var queryGroup = (QueryGroup)null;

            // Act
            var actual = statementBuilder.CreateQuery<TestSqlDbProviderCreateQueryWithTableHintClass>(queryBuilder, queryGroup, null, null, SqlTableHints.ReadUncommitted);
            var expected = $"" +
                $"SELECT [Field1], [Field2], [Field3] " +
                $"FROM [TestSqlDbProviderCreateQueryWithTableHintClass] {SqlTableHints.ReadUncommitted} ;";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private class TestSqlDbProviderCreateQueryWithWhereForDynamicClass
        {
            public int Field1 { get; set; }
            public string Field2 { get; set; }
            public DateTime Field3 { get; set; }
        }

        [TestMethod]
        public void TestSqlDbProviderCreateQueryWithWhereForDynamic()
        {
            // Setup
            var statementBuilder = new SqlStatementBuilder();
            var queryBuilder = new QueryBuilder();
            var expression = new { Field1 = 1 };
            var queryGroup = QueryGroup.Parse(expression);

            // Act
            var actual = statementBuilder.CreateQuery<TestSqlDbProviderCreateQueryWithWhereForDynamicClass>(queryBuilder, queryGroup);
            var expected = $"" +
                $"SELECT [Field1], [Field2], [Field3] " +
                $"FROM [TestSqlDbProviderCreateQueryWithWhereForDynamicClass] " +
                $"WHERE ([Field1] = @Field1) ;";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /*******************************/

        /*
         * We should allow the developers to write whatever fields they would like to be
         * written at the query expression and ordering. We will only map back the object
         * fields back to the Data Entity properties. If any exception occurs because of
         * missing fields, then, simply show the exception
         */

        private class TestSqlDbProviderCreateQueryWithAscendingOrderFieldsClass
        {
            public int Field1 { get; set; }
            public string Field2 { get; set; }
            public DateTime Field3 { get; set; }
        }

        [TestMethod]
        public void TestSqlDbProviderCreateQueryWithAscendingOrderFields()
        {
            // Setup
            var statementBuilder = new SqlStatementBuilder();
            var queryBuilder = new QueryBuilder();
            var queryGroup = (QueryGroup)null;
            var orderBy = OrderField.Parse(new { OrderField = Order.Ascending });

            // Act
            var actual = statementBuilder.CreateQuery<TestSqlDbProviderCreateQueryWithAscendingOrderFieldsClass>(queryBuilder, queryGroup, orderBy);
            var expected = $"" +
                $"SELECT [Field1], [Field2], [Field3] " +
                $"FROM [TestSqlDbProviderCreateQueryWithAscendingOrderFieldsClass] " +
                $"ORDER BY [OrderField] ASC ;";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private class TestSqlDbProviderCreateQueryWithDescendingOrderFieldsClass
        {
            public int Field1 { get; set; }
            public string Field2 { get; set; }
            public DateTime Field3 { get; set; }
        }

        [TestMethod]
        public void TestSqlDbProviderCreateQueryWithDescendingOrderFields()
        {
            // Setup
            var statementBuilder = new SqlStatementBuilder();
            var queryBuilder = new QueryBuilder();
            var queryGroup = (QueryGroup)null;
            var orderBy = OrderField.Parse(new { OrderField = Order.Descending });

            // Act
            var actual = statementBuilder.CreateQuery<TestSqlDbProviderCreateQueryWithDescendingOrderFieldsClass>(queryBuilder, queryGroup, orderBy);
            var expected = $"" +
                $"SELECT [Field1], [Field2], [Field3] " +
                $"FROM [TestSqlDbProviderCreateQueryWithDescendingOrderFieldsClass] " +
                $"ORDER BY [OrderField] DESC ;";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private class TestSqlDbProviderCreateQueryWithAscendingAndDescendingOrderFieldsClass
        {
            public int Field1 { get; set; }
            public string Field2 { get; set; }
            public DateTime Field3 { get; set; }
        }

        [TestMethod]
        public void TestSqlDbProviderCreateQueryWithAscendingAndDescendingOrderFields()
        {
            // Setup
            var statementBuilder = new SqlStatementBuilder();
            var queryBuilder = new QueryBuilder();
            var queryGroup = (QueryGroup)null;
            var orderBy = OrderField.Parse(new
            {
                AscendingField = Order.Ascending,
                DescendingField = Order.Descending
            });

            // Act
            var actual = statementBuilder.CreateQuery<TestSqlDbProviderCreateQueryWithAscendingAndDescendingOrderFieldsClass>(queryBuilder, queryGroup, orderBy);
            var expected = $"" +
                $"SELECT [Field1], [Field2], [Field3] " +
                $"FROM [TestSqlDbProviderCreateQueryWithAscendingAndDescendingOrderFieldsClass] " +
                $"ORDER BY [AscendingField] ASC, [DescendingField] DESC ;";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private class TestSqlDbProviderCreateQueryWithDescendingAndAscendingOrderFieldsClass
        {
            public int Field1 { get; set; }
            public string Field2 { get; set; }
            public DateTime Field3 { get; set; }
        }

        [TestMethod]
        public void TestSqlDbProviderCreateQueryWithDescendingAndAscendingOrderFields()
        {
            // Setup
            var statementBuilder = new SqlStatementBuilder();
            var queryBuilder = new QueryBuilder();
            var queryGroup = (QueryGroup)null;
            var orderBy = OrderField.Parse(new
            {
                DescendingField = Order.Descending,
                AscendingField = Order.Ascending
            });

            // Act
            var actual = statementBuilder.CreateQuery<TestSqlDbProviderCreateQueryWithDescendingAndAscendingOrderFieldsClass>(queryBuilder, queryGroup, orderBy);
            var expected = $"" +
                $"SELECT [Field1], [Field2], [Field3] " +
                $"FROM [TestSqlDbProviderCreateQueryWithDescendingAndAscendingOrderFieldsClass] " +
                $"ORDER BY [DescendingField] DESC, [AscendingField] ASC ;";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private class TestSqlDbProviderCreateQueryWithUnknownFieldAsPartOfWhereForDynamicClass
        {
            public int Field1 { get; set; }
            public string Field2 { get; set; }
            public DateTime Field3 { get; set; }
        }

        [TestMethod]
        public void TestSqlDbProviderCreateQueryWithUnknownFieldAsPartOfWhereForDynamic()
        {
            // Setup
            var statementBuilder = new SqlStatementBuilder();
            var queryBuilder = new QueryBuilder();
            var expression = new { AnyField = 1 };
            var queryGroup = QueryGroup.Parse(expression);

            // Act
            var actual = statementBuilder.CreateQuery<TestSqlDbProviderCreateQueryWithUnknownFieldAsPartOfWhereForDynamicClass>(queryBuilder, queryGroup);
            var expected = $"" +
                $"SELECT [Field1], [Field2], [Field3] " +
                $"FROM [TestSqlDbProviderCreateQueryWithUnknownFieldAsPartOfWhereForDynamicClass] " +
                $"WHERE ([AnyField] = @AnyField) ;";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /*******************************/

        private class ThrowExceptionOnSqlDbProviderCreateQueryIfThereAreNoQueryableFieldsClass
        {
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void ThrowExceptionOnSqlDbProviderCreateQueryIfThereAreNoQueryableFields()
        {
            // Setup
            var statementBuilder = new SqlStatementBuilder();
            var queryBuilder = new QueryBuilder();
            var queryGroup = (QueryGroup)null;

            // Act/Assert
            statementBuilder.CreateQuery<ThrowExceptionOnSqlDbProviderCreateQueryIfThereAreNoQueryableFieldsClass>(queryBuilder, queryGroup);
        }
    }
}
