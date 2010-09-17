
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Guardian.OpenPlatform.Results;

namespace Guardian.OpenPlatform.Linq
{
    internal class SearchTermFinder : ExpressionVisitor
    {
        private Expression expression;
        private List<string> terms;

        public SearchTermFinder(Expression exp)
        {
            this.expression = exp;
        }

        public List<string> Terms
        {
            get
            {
                if (terms == null)
                {
                    terms = new List<string>();
                    this.Visit(this.expression);
                }
                return this.terms;
            }
        }

        protected override Expression VisitBinary(BinaryExpression be)
        {
            if (be.NodeType == ExpressionType.Equal)
            {
                if (ExpressionTreeHelpers.IsMemberEqualsValueExpression(be, typeof(Content), "WebTitle"))
                {
                    terms.Add(ExpressionTreeHelpers.GetValueFromEqualsExpression(be, typeof(Content), "WebTitle"));
                    return be;
                }
                else if (ExpressionTreeHelpers.IsMemberEqualsValueExpression(be, typeof(Content), "Headline"))
                {
                    terms.Add(ExpressionTreeHelpers.GetValueFromEqualsExpression(be, typeof(Content), "Headline"));
                    return be;
                }
                else if (ExpressionTreeHelpers.IsMemberEqualsValueExpression(be, typeof(Content), "Body"))
                {
                    terms.Add(ExpressionTreeHelpers.GetValueFromEqualsExpression(be, typeof(Content), "Body"));
                    return be;
                }
                else if (ExpressionTreeHelpers.IsMemberEqualsValueExpression(be, typeof(Content), "Standfirst"))
                {
                    terms.Add(ExpressionTreeHelpers.GetValueFromEqualsExpression(be, typeof(Content), "Standfirst"));
                    return be;
                }
                else if (ExpressionTreeHelpers.IsMemberEqualsValueExpression(be, typeof(Content), "TrailText"))
                {
                    terms.Add(ExpressionTreeHelpers.GetValueFromEqualsExpression(be, typeof(Content), "TrailText"));
                    return be;
                }
                else
                    return base.VisitBinary(be);
            }
            else
                return base.VisitBinary(be);
        }
    }
}
