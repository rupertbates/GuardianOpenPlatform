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

            foreach (var arg in node.Arguments)
            {
                Visit(arg);
            }
            //Visit(node.Arguments[0]);

            return node;
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            return base.VisitBinary(node);
        }
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            return base.VisitLambda<T>(node);
        }
        protected override Expression VisitUnary(UnaryExpression node)
        {
            return base.VisitUnary(node);
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            return base.VisitMember(node);
        }
    }
}
