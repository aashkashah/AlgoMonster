The Only LLD Framework You Need (Interview-Sized)

Think in 4 passes, not 40 pages:

1️. Clarify scope (2–3 minutes)

Don’t dive in. Lock the boundaries.

Ask:

	Single building or multiple?

	How many elevators / floors / slots (roughly)?

	Do we need payments / pricing / optimization?

	Is concurrency required?

👉 Then state assumptions and freeze scope.

	“I’ll assume a single building, fixed number of floors, no payment system, and focus on core functionality.”

Interviewers love this.


2️. Identify Core Entities (this is the heart ❤️)

For any LLD, there are only 3 categories:

Category	What it means
Actors		Who interacts with system
Objects		Things that hold state
Managers	Classes that coordinate

Example: Parking Lot

Actors

	Driver

Objects

	ParkingLot

	Floor

	ParkingSpot

	Vehicle

	Ticket

Managers

	ParkingLotManager

	SpotAllocationStrategy

👉 If you can identify 5–7 classes, you’re in the sweet spot.


3️. Define Responsibilities (not code yet)

For each class, answer one sentence:

	“What is this class responsible for?”

Example:

	ParkingSpot → Knows if it’s free & what vehicle is parked

	Floor → Owns spots

	ParkingLotManager → Assigns and releases spots

❗ Avoid logic leakage
❌ ParkingSpot.assignVehicle() deciding strategy
✅ Strategy lives in a Strategy class


4️. Sketch Code (interfaces > implementations)

You are not expected to write full implementations.

Focus on:

	Class names

	Fields

	Method signatures


class ParkingLot {
    List<Floor> floors;
}

class Floor {
    List<ParkingSpot> spots;
}

abstract class ParkingSpot {
    bool IsFree;
    Vehicle Vehicle;
}

class ParkingLotManager {
    ISpotAllocationStrategy strategy;

    ParkingSpot Park(Vehicle vehicle);
    void Unpark(Ticket ticket);
}


Elevator Design 

Core Entities

Actors

	Passenger

Objects

	Elevator

	Floor

	Request

Managers

	ElevatorController

	SchedulingStrategy

Key interviewer signal 🚨

They want to see:

	State modeling (MovingUp, Idle, MovingDown)

	Separation of scheduling logic


class Elevator {
    int currentFloor;
    Direction direction;
    ElevatorState state;
}

class ElevatorController {
    List<Elevator> elevators;
    ISchedulingStrategy strategy;

    void RequestElevator(int floor, Direction dir);
}



What Interviewers Actually Evaluate (Truth bomb 💣)

They are NOT checking:

	Edge-case completeness

	Thread safety

	Full implementations

	20+ classes

They ARE checking:

	Can you model real-world systems

	Can you separate responsibilities

	Can you explain why a class exists

	Can you adapt when requirements change