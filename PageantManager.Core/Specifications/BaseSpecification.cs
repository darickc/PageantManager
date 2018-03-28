using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PageantManager.Core.Interfaces;

namespace PageantManager.Core.Specifications
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        protected BaseSpecification()
        {
            
        }
        
        protected BaseSpecification(Expression<Func<T, bool>> predicate)
        {
            Predicate = predicate;
        }
       
        
        public Expression<Func<T, bool>> Predicate { get; protected set; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
    }
}

