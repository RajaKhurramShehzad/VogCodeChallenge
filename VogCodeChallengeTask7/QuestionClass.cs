using System.Collections.Generic;

namespace VogCodeChallengeTask7
{
    public class QuestionClass
    {
        public static List<string> NamesList = new List<string>()
        {
            "Jimmy",
            "Jeffrey",
            "John",
        };
        public List<string> IterateList()
        {
            var ret = new List<string>();
            using (var enumerator = NamesList.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var element = enumerator.Current;
                    ret.Add(element);
                }
            }
            return ret;
        }
    }

}
