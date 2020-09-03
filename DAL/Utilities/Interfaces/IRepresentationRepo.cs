using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Utilities.Interfaces
{
	public interface IRepresentationRepo
	{
		Task< IList<Representation> > GetAllTeams();
		Task< List<Player> > GetPlayers( string fifaCode );
		Task<List<Match>> GetMatchesForCountry( Representation representation );
	}
}
