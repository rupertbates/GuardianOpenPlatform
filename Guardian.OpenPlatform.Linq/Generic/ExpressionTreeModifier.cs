using System;
using System.Linq;
using System.Linq.Expressions;
using Guardian.OpenPlatform.Results.Entities;


namespace Guardian.OpenPlatform.Linq
{

    

        internal class ExpressionTreeModifier : ExpressionVisitor
        {
            private IQueryable<Content> queryableContents;

            internal ExpressionTreeModifier(IQueryable<Content> contents)
            {
                this.queryableContents = contents;
            }

            protected override Expression VisitConstant(ConstantExpression c)
            {
                // Replace the constant QueryableTerraServerData arg with the queryable Content collection.
                if (c.Type == typeof(QueryableOpenPlatformData<Content>))
                    return Expression.Constant(this.queryableContents);
                else
                    return c;
            }
        }

}
