using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Guardian.OpenPlatform.Results.Entities;

namespace Guardian.OpenPlatform.Linq
{
    public class OpenPlatformQueryContext
    {
        public QueryableOpenPlatformData<Content> Content { get; set; }
        public OpenPlatformQueryContext()
        {
            Content = new QueryableOpenPlatformData<Content>();
        }
        // Executes the expression tree that is passed to it.
        internal static object Execute(Expression expression, bool IsEnumerable)
        {
            // The expression must represent a query over the data source.
            if (!IsQueryOverDataSource(expression))
                throw new InvalidProgramException("No query over the data source was specified.");

            // Find the call to Where() and get the lambda expression predicate.
            InnermostWhereFinder whereFinder = new InnermostWhereFinder();
            MethodCallExpression whereExpression = whereFinder.GetInnermostWhere(expression);
            LambdaExpression lambdaExpression = (LambdaExpression)((UnaryExpression)(whereExpression.Arguments[1])).Operand;

            // Send the lambda expression through the partial evaluator.
            lambdaExpression = (LambdaExpression)Evaluator.PartialEval(lambdaExpression);

            // Get the place name(s) to query the Web service with.
            SearchTermFinder termFinder = new SearchTermFinder(lambdaExpression.Body);
            List<string> terms = termFinder.Terms;
            

            // Call the Web service and get the results.
            var results = new OpenPlatformSearch().ContentSearch(new ContentSearchParameters {Query = terms.First()}).Results;
            

            // Copy the IEnumerable places to an IQueryable.
            IQueryable<Content> queryableResults = results.AsQueryable();

            // Copy the expression tree that was passed in, changing only the first
            // argument of the innermost MethodCallExpression.
            ExpressionTreeModifier treeCopier = new ExpressionTreeModifier(queryableResults);
            Expression newExpressionTree = treeCopier.Visit(expression);

            // This step creates an IQueryable that executes by replacing Queryable methods with Enumerable methods.
            if (IsEnumerable)
                return queryableResults.Provider.CreateQuery(newExpressionTree);
            else
                return queryableResults.Provider.Execute(newExpressionTree);
        }

        private static bool IsQueryOverDataSource(Expression expression)
        {
            // If expression represents an unqueried IQueryable data source instance,
            // expression is of type ConstantExpression, not MethodCallExpression.
            return (expression is MethodCallExpression);
        }

 
    }
}