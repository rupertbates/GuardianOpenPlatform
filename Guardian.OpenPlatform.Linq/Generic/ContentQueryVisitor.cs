using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Guardian.OpenPlatform.Linq.Generic
{
    public class ContentQueryVisitor : ExpressionVisitor
    {
        private ContentSearchParameters _searchParameter = new ContentSearchParameters();
        public ContentSearchParameters Translate(Expression ex)
        {
            Visit(ex);
            return _searchParameter;
        }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Where")
                //innermostWhereExpression = expression;

            Visit(node.Arguments[0]);

            return node;
        }
    }
}
