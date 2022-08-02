using System.Linq.Dynamic.Core;
using System.Text;

namespace Autho.Core.Extensions
{
    public static class QueryableExtensions
    {
        private static string CHARACTER_CONTAINS = "*";

        public static IOrderedQueryable<T> Order<T>(this IQueryable<T> source, string statement)
        {
            return source.OrderBy(statement);
        }

        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> source, string propertyName, IEnumerable<string> propertyValues)
        {
            var predicate = new StringBuilder();
            var parameters = new List<string>();

            foreach (var property in propertyValues.Select((value, index) => new { value, index }))
            {
                string statement;

                if (property.value.StartsWith(CHARACTER_CONTAINS) && property.value.EndsWith(CHARACTER_CONTAINS))
                {
                    statement = "{0}.ToLower().Contains(@{1})";
                    parameters.Add(property.value[1..^1].ToLower());
                }
                else if (property.value.StartsWith(CHARACTER_CONTAINS))
                {
                    statement = "{0}.ToLower().EndsWith(@{1})";
                    parameters.Add(property.value[1..].ToLower());
                }
                else if (property.value.EndsWith(CHARACTER_CONTAINS))
                {
                    statement = "{0}.ToLower().StartsWith(@{1})";
                    parameters.Add(property.value[0..^1].ToLower());
                }
                else
                {
                    statement = "{0}.Equals(@{1})";
                    parameters.Add(property.value);
                }

                if (predicate.Length > 0)
                {
                    var orStatement = string.Format(" OR {0}", statement);
                    predicate.Append(string.Format(orStatement, propertyName, property.index));
                }
                else
                {
                    predicate.Append(string.Format(statement, propertyName, property.index));
                }
            }

            return source.Where(predicate.ToString(), parameters.ToArray());
        }

        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> source, string propertyName, int propertyValue)
        {
            var predicate = string.Format("{0} = @0", propertyName);
            return source.Where(predicate, propertyValue);
        }

        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> source, string propertyName, int? minPropertyValue, int? maxPropertyValue)
        {
            if (minPropertyValue != null)
            {
                var predicate = string.Format("{0} >= @0", propertyName);
                source = source.Where(predicate, minPropertyValue);
            }

            if (maxPropertyValue != null)
            {
                var predicate = string.Format("{0} <= @0", propertyName);
                source = source.Where(predicate, maxPropertyValue);
            }

            return source;
        }

        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> source, string propertyName, double? minPropertyValue, double? maxPropertyValue)
        {
            if (minPropertyValue != null)
            {
                var predicate = string.Format("{0} >= @0", propertyName);
                source = source.Where(predicate, minPropertyValue);
            }

            if (maxPropertyValue != null)
            {
                var predicate = string.Format("{0} <= @0", propertyName);
                source = source.Where(predicate, maxPropertyValue);
            }

            return source;
        }

        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> source, string propertyName, bool propertyValue)
        {
            var predicate = string.Format("{0}.Equals(@0)", propertyName);
            return source.Where(predicate, propertyValue);
        }

        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> source, string propertyName, DateTime? minPropertyValue, DateTime? maxPropertyValue)
        {
            if (minPropertyValue != null)
            {
                var predicate = string.Format("{0} >= @0", propertyName);
                source = source.Where(predicate, minPropertyValue);
            }

            if (maxPropertyValue != null)
            {
                var predicate = string.Format("{0} <= @0", propertyName);
                source = source.Where(predicate, maxPropertyValue);
            }

            return source;
        }
    }
}
