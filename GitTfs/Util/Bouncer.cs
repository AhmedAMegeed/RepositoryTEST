using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sep.Git.Tfs.Util
{
    /// <summary>
    /// Determines if an item is included or excluded from a set.
    /// By default, everything is excluded.
    /// </summary>
    public class Bouncer
    {
        List<Regex> includes = new List<Regex>();
        List<Regex> excludes = new List<Regex>();

        /// <summary>
        /// Add a regular expression for inclusion in the set.
        /// </summary>
        public void Include(string expression)
        {
            Append(includes, expression);
        }

        /// <summary>
        /// Add a regular expression for exclusion from the set.
        /// </summary>
        public void Exclude(string expression)
        {
            Append(excludes, expression);
        }

        private void Append(List<Regex> set, string expression)
        {
            if (expression != null)
                set.Add(new Regex(expression, RegexOptions.IgnoreCase));
        }

        /// <summary>
        /// Checks if the string is included in the set.
        /// </summary>
        public bool IsIncluded(string s)
        {
            return includes.Any(r => r.IsMatch(s)) && !excludes.Any(r => r.IsMatch(s));
        }
    }
}
