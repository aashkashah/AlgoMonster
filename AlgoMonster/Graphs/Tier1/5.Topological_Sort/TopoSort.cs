namespace AlgoMonster.Graphs.TopologicalSort
{

    /// <summary>
    /// Kahn's algorithm is only for DAG (directly acyclic graph)
    /// </summary>
    public static class TopoSort
    {
        /// <summary>
        /// Course schedule II
        /// https://leetcode.com/problems/course-schedule-ii/description
        /// Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
        /// Output: [0, 2, 1, 3]
        /// BFS (indegree + Kahn)
        /// Todo: with DFS (white (unvisited), grey(visiting), black(visited)) 
        /// </summary>
        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            // [[2,3],[1,2],[0,1],[0,4],[4,5],[5,1]]

            // create adj list, indegree, topo
            var adjList = new Dictionary<int, List<int>>();
            var indegree = new int[numCourses];
            var topo = new int[numCourses];

            // build graph + indegree
            for (int i = 0; i < prerequisites.Length; i++)
            {
                int dest = prerequisites[i][0];
                int source = prerequisites[i][1];

                if (!adjList.TryGetValue(source, out var neighbours))
                {
                    neighbours = new List<int>();
                    adjList[source] = neighbours;
                }
                neighbours.Add(dest);
                indegree[dest]++;
            }

            // build queue
            var q = new Queue<int>();
            for (int course = 0; course < numCourses; course++)
            {
                if (indegree[course] == 0)
                    q.Enqueue(course);
            }

            // itterate queue to try decouple dependencies 
            int idx = 0;
            while (q.Count > 0)
            {
                int node = q.Dequeue();
                topo[idx++] = node;

                if (adjList.TryGetValue(node, out var neighbors))
                {
                    foreach (int next in neighbors)
                    {
                        indegree[next]--;
                        if (indegree[next] == 0)
                            q.Enqueue(next);
                    }
                }
            }

            // If we scheduled all courses, return the ordering; otherwise cycle exists
            return (idx == numCourses) ? topo : Array.Empty<int>();
        }

        /// <summary>
        /// Course Schedule
        /// https://leetcode.com/problems/course-schedule/
        /// BFS (indegree + Kahn)
        /// </summary>
        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {  
            var adjList = new Dictionary<int, List<int>>();
            var indegree = new int[numCourses];
            var topo = new int[numCourses];

            // create agj. list + indegree
            for(int i = 0; i < numCourses; i++)
            {
                var dest = prerequisites[i][0];
                var src = prerequisites[i][1];

                if(!adjList.TryGetValue(src, out var neighbors))
                {
                    neighbors = new List<int>();
                    adjList[src] = neighbors;
                }
                neighbors.Add(dest);
                indegree[dest]++;
            }

            // build queue
            var q = new Queue<int>();
            for(int i = 0; i < numCourses;i++)
            {
                if (indegree[i] == 0)
                    q.Enqueue(i);
            }

            // iterate queue to untangle and build dependency
            int indx = 0;
            while(q.Count > 0)
            {
                var node = q.Dequeue();
                topo[indx] = node;
                indx++;
                
                if(!adjList.TryGetValue(node, out var neighbours))
                {
                    foreach(var n in neighbours)
                    {
                        indegree[n]--;
                        if (indegree[n] == 0)
                            q.Enqueue(n);
                    }
                }
            }

            if (indx == numCourses) return true;
            else return false;
        }


    }
}
