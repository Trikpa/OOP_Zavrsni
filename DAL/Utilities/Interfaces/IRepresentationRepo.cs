using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Utilities.Interfaces
{
	public interface IRepresentationRepo
	{
		Task< IEnumerable<TeamResult> > GetAllRepresentations();
		Task<TeamResult> GetRepresentation( string fifaCode );
		Task<IEnumerable<Player>> GetPlayers( string fifaCode );
	}
}
