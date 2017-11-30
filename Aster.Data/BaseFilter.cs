using Aster.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Aster.Data {
    //same as BaseSpecification in eShopOnWeb
    public abstract class BaseFilter<T>: IFilter<T> {

        
        public BaseFilter(Expression<Func<T, bool>> criteria) {
            Criteria = criteria;
        }
        
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();
        
        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression) {
            Includes.Add(includeExpression);
        }
        protected virtual void AddInclude(string includeString) {
            IncludeStrings.Add(includeString);
        }

    }
}