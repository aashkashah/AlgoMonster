

Requirements
	functional:
		User:	
			search for games
			set difficultly level
			join game
			return to backyard (leave game)
			respawn
		System:
			Create game VM
			Add players to new game start (capacity 4)
			Calculate/Increment player experience (out of scope)
			Start game
				spawn boss
			End game (after level 10)


	non-functional: (for HLD)
		durable (game hosted / VM - keep players connected)
		real time inputs (bi-directional) ->	web sockets 
			keep players of same game on same server

	Entites: (HLD)
		Game
		User
		Character

	API calls:
		
		User
		GET
			/search?difficulty=medium&region=west-us&active=true

		POST (join game)
			/game/{gameid}/players
			{
				userId="123"
			}

		PUT (set preferences)
			/user/{userId}/settings
			{
				difficulty="medium"
				character="sunflower"
			}

		DELETE (leave game)
			/game/{gameId}/players/{userId}

		PUT (change character)
			/game/{gameId}/players/{userId}
			{
				character="peashooter"
			}








