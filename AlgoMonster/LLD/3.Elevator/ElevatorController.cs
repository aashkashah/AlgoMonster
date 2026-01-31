namespace AlgoMonster.LLD._3.Elevator
{
    using System;
    using System.Collections.Generic;

    public class ElevatorController
    {
        private readonly List<Elevator> _elevators;

        public ElevatorController()
        {
            _elevators = new List<Elevator>
        {
            new Elevator(),
            new Elevator(),
            new Elevator()
        };
        }

        public bool RequestElevator(int floor, Direction direction)
        {
            if (floor < 0 || floor > 9)
            {
                return false;
            }
            if (direction != Direction.Up && direction != Direction.Down)
            {
                return false;
            }

            var best = SelectBestElevator(floor, direction);
            var type = direction == Direction.Up ? RequestType.PICKUP_UP : RequestType.PICKUP_DOWN;
            return best.AddRequest(floor, type);
        }

        public void Step()
        {
            foreach (var elevator in _elevators)
            {
                elevator.Step();
            }
        }

        private Elevator SelectBestElevator(int floor, Direction direction)
        {
            var best = FindCommittedToFloor(floor, direction);
            if (best != null)
            {
                return best;
            }

            best = FindNearestIdle(floor);
            if (best != null)
            {
                return best;
            }

            return FindNearest(floor);
        }

        private Elevator? FindCommittedToFloor(int floor, Direction direction)
        {
            Elevator? nearest = null;
            var minDistance = int.MaxValue;

            foreach (var e in _elevators)
            {
                if (e.Direction != direction)
                {
                    continue;
                }

                var isMovingToward =
                    (direction == Direction.Up && e.CurrentFloor < floor) ||
                    (direction == Direction.Down && e.CurrentFloor > floor);

                if (!isMovingToward)
                {
                    continue;
                }

                if (!e.HasRequestsAtOrBeyond(floor, direction))
                {
                    continue;
                }

                var distance = Math.Abs(e.CurrentFloor - floor);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = e;
                }
            }

            return nearest;
        }

        private Elevator? FindNearestIdle(int floor)
        {
            Elevator? nearest = null;
            var minDistance = int.MaxValue;

            foreach (var e in _elevators)
            {
                if (e.Direction != Direction.Idle)
                {
                    continue;
                }

                var distance = Math.Abs(e.CurrentFloor - floor);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = e;
                }
            }

            return nearest;
        }

        private Elevator FindNearest(int floor)
        {
            var nearest = _elevators[0];
            var minDistance = Math.Abs(_elevators[0].CurrentFloor - floor);

            foreach (var e in _elevators)
            {
                var distance = Math.Abs(e.CurrentFloor - floor);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = e;
                }
            }

            return nearest;
        }
    }


}
