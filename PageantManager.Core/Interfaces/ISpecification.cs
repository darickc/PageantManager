using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PageantManager.Core.Interfaces
{
    public interface ISpecification<T>    
    {
        Expression<Func<T, bool>> Predicate { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}