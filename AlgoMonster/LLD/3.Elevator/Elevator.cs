namespace AlgoMonster.LLD._3.Elevator
{
    using System;
    using System.Collections.Generic;

    public enum Direction
    {
        Up,
        Down,
        Idle
    }

    public class Elevator
    {
        private int _currentFloor;
        private Direction _direction;
        private readonly HashSet<Request> _requests;

        public Elevator()
        {
            _currentFloor = 0;
            _direction = Direction.Idle;
            _requests = new HashSet<Request>();
        }

        public bool AddRequest(int floor, RequestType type)
        {
            if (floor < 0 || floor > 9)
            {
                return false;
            }
            if (floor == _currentFloor)
            {
                return true;
            }
            var request = new Request(floor, type);
            if (_requests.Contains(request))
            {
                return false;
            }
            _requests.Add(request);
            return true;
        }

        public void Step()
        {
            if (_requests.Count == 0)
            {
                _direction = Direction.Idle;
                return;
            }

            if (_direction == Direction.Idle)
            {
                // Find nearest request to establish initial direction (deterministic)
                Request nearest = null;
                int minDistance = int.MaxValue;

                foreach (var req in _requests)
                {
                    int distance = Math.Abs(req.GetFloor() - _currentFloor);
                    if (distance < minDistance || (distance == minDistance && (nearest == null || req.GetFloor() < nearest.GetFloor())))
                    {
                        minDistance = distance;
                        nearest = req;
                    }
                }

                _direction = nearest.GetFloor() > _currentFloor ? Direction.Up : Direction.Down;
            }

            var pickupType = _direction == Direction.Up ? RequestType.PICKUP_UP : RequestType.PICKUP_DOWN;
            var pickupRequest = new Request(_currentFloor, pickupType);
            var destinationRequest = new Request(_currentFloor, RequestType.DESTINATION);

            if (_requests.Contains(pickupRequest) || _requests.Contains(destinationRequest))
            {
                _requests.Remove(pickupRequest);
                _requests.Remove(destinationRequest);

                if (_requests.Count == 0)
                {
                    _direction = Direction.Idle;
                    return;
                }
                if (!HasRequestsAhead(_direction))
                {
                    _direction = _direction == Direction.Up ? Direction.Down : Direction.Up;
                }
                return;
            }

            if (!HasRequestsAhead(_direction))
            {
                _direction = _direction == Direction.Up ? Direction.Down : Direction.Up;
                return;
            }

            if (_direction == Direction.Up)
            {
                _currentFloor++;
            }
            else if (_direction == Direction.Down)
            {
                _currentFloor--;
            }
        }

        public bool HasRequestsAhead(Direction dir)
        {
            foreach (var request in _requests)
            {
                if (dir == Direction.Up && request.GetFloor() > _currentFloor)
                {
                    return true;
                }
                if (dir == Direction.Down && request.GetFloor() < _currentFloor)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasRequestsAtOrBeyond(int floor, Direction dir)
        {
            foreach (var request in _requests)
            {
                if (dir == Direction.Up && request.GetFloor() >= floor)
                {
                    if (request.GetType() == RequestType.PICKUP_UP || request.GetType() == RequestType.DESTINATION)
                    {
                        return true;
                    }
                }
                if (dir == Direction.Down && request.GetFloor() <= floor)
                {
                    if (request.GetType() == RequestType.PICKUP_DOWN || request.GetType() == RequestType.DESTINATION)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int CurrentFloor => _currentFloor;

        public Direction Direction => _direction;
    }


}
