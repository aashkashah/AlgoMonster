namespace AlgoMonster.Arrays.Sorting
{
    public class Sorting
    {
        //937. Reorder Data in Log Files
        public string[] ReorderLogFiles(string[] logs)
        {
           var letterLogs = new List<string>();
            var digitLogs = new List<string>();

            foreach(string log in logs)
            {
                int space = log.IndexOf(' ');
                if (char.IsDigit(log[space + 1]))
                {
                    digitLogs.Add(log);
                }
                else
                {
                    letterLogs.Add(log);
                }
            }

            letterLogs.Sort(CompareLetterLogs);

            var res = new List<string>();
            res.AddRange(letterLogs);
            res.AddRange(digitLogs);
            return res.ToArray();
            
        }

        private int CompareLetterLogs(string a, string b)
        {
            int splitA = a.IndexOf(' ');
            int splitB = b.IndexOf(' ');

            string bodyA = a.Substring(splitA + 1);
            string bodyB = b.Substring(splitB + 1);

            int cmp = string.Compare(bodyA, bodyB, StringComparison.Ordinal);
            if (cmp != 0) return cmp;

            string idA = a.Substring(0, splitA);
            string idB = b.Substring(0, splitB);
            return string.Compare(idA, idB, StringComparison.Ordinal);
        }
    }
}
