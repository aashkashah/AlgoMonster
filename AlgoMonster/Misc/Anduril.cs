
class Solution {

    static int findClosest(int[] locations, int[] towers) { 
        
        var maxSoFar = int.MinValue;
        
        for(int i = 0; i < locations.Length; i++)
        {
            var minForThisLocation = FindMinDistance(towers, locations[i]);
            //var minForThisLocation = int.MaxValue;
            // for(int j = 0; j < towers.Length; j++)
            // {
            //     minForThisLocation = Math.Min(minForThisLocation, Math.Abs(locations[i] - towers[j]));
            // }
            maxSoFar = Math.Max(maxSoFar, minForThisLocation);
        }
        
        return maxSoFar;
    }
    
    static int FindMinDistance(int[] towers, int location)
    {
        
        var left = 0;
        var right = towers.Length - 1;
        
        while(left < right)
        {
            var mid = (left + right) / 2;
            
            if(location == towers[mid])
                return 0;

            if(towers[mid] < location)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        int minDistance = int.MaxValue;

        if(left < towers.Length)
        {
            minDistance = Math.Min(minDistance, Math.Abs(towers[left] - location));
        }

        if(right >= 0)
        {
            minDistance = Math.Min(minDistance, Math.Abs(towers[right] - location));
        }
        
        return minDistance;
    }

    static int FindMaxRange(int[] locations, int[] towers)
    {
        int towerIdx = 0;
        int answer = 0;

        foreach(var location in locations)
        {
            while(towerIdx + 1 < towers.Length &&
            Math.Abs(towers[towerIdx + 1] - location) <= Math.Abs(towers[towerIdx] - location))
            {
                towerIdx++;
            }

            answer = Math.Max(answer, Math.Abs(towers[towerIdx] - location));
        }

        return answer;
    }

    static void Main(String[] args) {
        
        var locations = new int[] { 1, 2, 3, 10, 12 };
        var towers = new int[] { 1, 4, 6 };
        
        int max = findClosest(locations, towers);
        
        Console.WriteLine(max);
    }
}      

/**


what
    detection towers -> locations
        towers have sensors (fixed range)
        
        out:
            min range border crossing locations
       
examples

sorted 
 
 maxsofar = 3
 
 1 2 3  10 12 (locations)
        ^   
 
   1  5 7 
 
  
 
 out:
    5
    
    
0, 6 -> max = 6

max

O(n2) time
O(1) space

code, tests

**/
