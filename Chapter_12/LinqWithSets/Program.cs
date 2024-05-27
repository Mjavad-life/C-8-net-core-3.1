using System.Collections.Generic; // IEnumerable<T> برای 
using System.Linq; // LINQ برای تابع های ملحق شده
using static System.Console;

namespace LinqWithSets
{
    public class Program
    {
        static void Output(IEnumerable<string> cohort,
            string description = "")
            {
                if (!string.IsNullOrEmpty(description))
                {
                    WriteLine(description);
                }
                Write("  ");
                WriteLine(string.Join(", ", cohort.ToArray()));
            }

        
        static void Main(string[] args)
        {
            var cohort1 = new string[]
                {"Rafael", "Ghatreh", "Jojoba", "Gorg"};
            var cohort2 = new string[]
                {"Jack", "Sololo", "Dandi", "Jack", "Jaro"};
            var cohort3 = new string[]
                {"Dedam", "Jack", "Jack", "Jamil", "Coko"};

            Output(cohort1, "Cohort 1");
            Output(cohort2, "Cohort 2");
            Output(cohort3, "Cohort 3");
            WriteLine();
            Output(cohort2.Distinct(), "cohort2.Distinct():");
            WriteLine();
            Output(cohort2.Union(cohort3), "cohort2.Union(cohort3):");
            WriteLine();
            Output(cohort2.Concat(cohort3), "cohort2.Concat(cohort3):");
            WriteLine();
            Output(cohort2.Intersect(cohort3), "cohort2.Concat(cohort3):");
            WriteLine();
            Output(cohort2.Except(cohort3), "cohort2.Except(cohort3):");
            WriteLine();
            Output(cohort1.Zip(cohort2,(c1, c2) => $"{c1} mikhone ba {c2}"),
                "cohort1.Zip(cohort2):");
        }
    }

}