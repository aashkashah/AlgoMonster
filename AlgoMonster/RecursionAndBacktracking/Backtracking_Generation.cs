namespace AlgoMonster.RecursionAndBacktracking
{
    public static class Backtracking_Generation
    {
        /// <summary>
        /// Input: { "Jane", "Marty", "Joe", "Susan" }
        /// </summary>
        /// <returns></returns>
        public static void GenerateAllCombinationOfSublists()
        {
             GenerateSublistHelper(
                new List<string>() { "Jane", "Marty", "Joe", "Susan" }, 
                new List<string>()
                );
        }

        public static void GenerateSublistHelper(List<string> list, List<string> chosen)
        {
            //base case
            if (list.Count == 0) Console.WriteLine(chosen);

            // recursion
            for (int i = 0; i < list.Count; i++) 
            {
                string s = list[i];

                // choose
                list.RemoveAt(i);

                // explore with
                chosen.Add(s);
                GenerateSublistHelper(list, chosen);

                // explore without
                chosen.RemoveAt(i);
                GenerateSublistHelper(list, chosen);

                //unchoose
                list.Add(s);
            }

        }

    }
}
