namespace AlgoMonster.Design
{   
    public class StockPrice
    {
        /// <summary>
        /// https://leetcode.com/problems/stock-price-fluctuation/
        /// Input
        /// ["StockPrice", "update", "update", "current", "maximum", "update", "maximum", "update", "minimum"]
        /// [[], [1, 10], [2, 5], [], [], [1, 3], [], [4, 2], []]
        /// Output
        /// [null, null, null, 5, 10, null, 5, null, 2]
        /// </summary>

        
        private Dictionary<int, int> timeToPrice = new Dictionary<int, int>();
        private PriorityQueue<(int price, int time), int> minHeap = new PriorityQueue<(int price, int time), int>
            ();

        private PriorityQueue<(int price, int time), int> maxHeap = new PriorityQueue<(int price, int time), int>
           ();


        private int latestTimestamp = 0;

         public StockPrice()
        {
            // issues -- 
            // random order
            // incorectness (another correction might might come later in the stream)
        }

        public void Update(int timestamp, int price)
        {
            latestTimestamp = Math.Max(latestTimestamp, timestamp);

            timeToPrice[timestamp] = price;

            minHeap.Enqueue((price, timestamp), price);
            maxHeap.Enqueue((price, timestamp), -price);
        }

        public int Current()
        {
            return timeToPrice[latestTimestamp];
        }

        public int Maximum()
        {
            // pop stale entries until top matches current map value
            // lazy deletion

            while(true)
            {
                var (price, time) = maxHeap.Peek();
                if (timeToPrice[time] == price) return price;
                maxHeap.Dequeue();
            }
            
        }

        public int Minimum()
        {
            while(true)
            {
                var (price, time) = minHeap.Peek();
                if(timeToPrice[time] == price) return price;
                minHeap.Dequeue();
            }
        }
    }
}
