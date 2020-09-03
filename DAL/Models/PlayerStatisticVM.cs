using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models.Enums;

namespace DAL.Models
{
	public class PlayerStatisticVM
	{
		public PlayerVM Player { get; }
		public int NumOfYellowCards { get; }
		public int NumOfScoredGoals { get; }

		public PlayerStatisticVM( PlayerVM player, List<Match> matches, Representation representation )
		{
			Player = player;

			foreach ( var match in matches )
			{
				if ( match.HomeTeam.Code == representation.FifaCode )
				{
					foreach ( var matchEvent in match.HomeTeamEvents )
						if ( matchEvent.Player == player.Player.Name )
						{
							if ( matchEvent.TypeOfEvent == TypeOfEvent.YellowCard )
								++NumOfYellowCards;

							if ( matchEvent.TypeOfEvent == TypeOfEvent.Goal || matchEvent.TypeOfEvent == TypeOfEvent.GoalPenalty )
								++NumOfScoredGoals;
						}
				}
				else if ( match.AwayTeam.Code == representation.FifaCode )
				{
					foreach ( var matchEvent in match.AwayTeamEvents )
						if ( matchEvent.Player == player.Player.Name )
						{
							if ( matchEvent.TypeOfEvent == TypeOfEvent.YellowCard )
								++NumOfYellowCards;

							if ( matchEvent.TypeOfEvent == TypeOfEvent.Goal || matchEvent.TypeOfEvent == TypeOfEvent.GoalPenalty )
								++NumOfScoredGoals;
						}
				}
			}
		}
	}
}
