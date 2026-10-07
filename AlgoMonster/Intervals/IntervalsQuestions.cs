using System.ComponentModel;
using System.Text;

class IntervalQuestions
{
    public static int[][] MergeIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var merged = new List<int[]>();

        foreach(var interval in intervals)
        {
            var len = merged.Count;
            if(merged.Count == 0 || merged[len - 1][1] > interval[0])
            {
                // first or non-overlapping
                merged.Add(interval);
            }
            else
            {
                // overlapping
                merged[len - 1][1] =  Math.Max(interval[1], merged[len - 1][1]);
            }
        }

        return merged.ToArray();
    }

    public static int[][] InsertIntervals(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>();

        var newStart = newInterval[0];
        var newEnd = newInterval[1];

        var index = 0;
        var n = intervals.Length;

        // before new start
        while(index < n && intervals[index][1] < newStart)
        {
            result.Add(intervals[index]);
            index++;
        }

        // merge
        while(index < n && intervals[index][0] <= newEnd)
        {
            newStart = Math.Min(newStart, intervals[index][0]);
            newEnd = Math.Max(newEnd, intervals[index][1]);
            index++;
        }

        result.Add(new int[] { newStart, newEnd });

        // after
        while(index < n)
        {
            result.Add(intervals[index]);
            index++;
        }

        return result.ToArray();
    }

    /// <summary>
    /// docusign question 
    /// https://leetcode.com/problems/summary-ranges/
    /// </summary>
    public string SummaryRanges(int[] nums)
    {
        var res = new StringBuilder();
        var n = nums.Length;

        if (n == 0) return res.ToString();

        int index = 0;
        while(index < n)
        {
            int start = nums[index];
            int end = start;

            while(index + 1 < nums.Length && nums[index + 1 ] - nums[index] <= 1)
            {
                index++;
                end = nums[index];
            }

            if(start != end)
            {
                res.Append(start + "-" + end + ",");
            }
            else
            {
                res.Append(start + ",");
            }

            index++;
        }
        return res.ToString().TrimEnd(',');
    }
}