using System;
using System.Collections.Generic;

namespace VogCodeChallengeTask7
{
    public static class QuestionClass
    {
        public static List<string> NamesList = new List<string>()
        {
            "Jimmy",
            "Jeffrey",
            "John",
        };
        public static void IterateList()
        {
            using (var enumerator = NamesList.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var element = enumerator.Current;
                    Console.WriteLine(element);
                }
            }
        }
    }

}
