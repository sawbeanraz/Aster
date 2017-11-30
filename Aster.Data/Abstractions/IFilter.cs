using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Aster.Data.Abstractions {
    //Same as ISpecification in eShopOnWeb
    public interface IFilter<T> {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }        
        List<string> IncludeStrings { get; }
    }
}