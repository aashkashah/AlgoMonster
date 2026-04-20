

Movie booking system

fandango style

	multiple theatres, select from a seat map, reserve tickets



Requirements
	- search for movie by title
	- browse movies by theatre
	- screens have same layout
	- manage movie reservation (cancel movie) -> releases seat
	- lookup available seats, select specific ones
	- concurrent booking (exactly one succeeds)
	

Core entities
	- theatre
	- movie
	- showtime
	- screen
	- seat
	- reservation
	- booking system

Booking system -> List<Theatre>
Theatre -> List<showtime>
Showtime -> Theatre (back-reference)
Showtime -> Movie (reference)
Reservation -> Showtime (back-reference)
Reservation -> List<string> 



