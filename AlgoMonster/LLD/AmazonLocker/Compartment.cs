namespace AlgoMonster.LLD.AmazonLocker
{
    public enum Size
    {
        Small,
        Medium,
        Large
    }

    public enum CompartmentStatus
    {
        Available,
        Occupied,
        OutOfService
    }
    public class Compartment
    {
        public Size Size { get; set; }
        public bool Occupied { get; set; }

        public CompartmentStatus Status { get; set; }   

        public Compartment(Size size) 
        {
            Size = size;
            Occupied = false;   
        }

        public Size GetSize() 
        { 
            return Size; 
        }

        public bool IsOccupied() 
        {  
            return Occupied; 
        }

        public void MarkOccupied()
        {
            this.Status = CompartmentStatus.Occupied;
            Occupied = true;
        }

        public void MarkFree()
        {
            this.Status = CompartmentStatus.Available;
            Occupied = false; 
        }

        public void Open()
        { 

        }
    }
}
