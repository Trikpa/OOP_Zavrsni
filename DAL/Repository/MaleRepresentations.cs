using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Utilities.Interfaces;

namespace DAL.Repository
{
	public class MaleRepresentations : IRepresentationRepo
	{
		public Task<IEnumerable<TeamResult>> GetAllRepresentations()
		{
			Uri uri = new Uri("https://worldcup.sfg.io/teams/");

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

			using ( HttpWebResponse response = (HttpWebResponse)Task. request.GetResponseAsync() )
			using ( Stream stream = response.GetResponseStream() )
			using ( StreamReader reader = new StreamReader(stream) )
			{
				return await reader.ReadToEndAsync();
			}
		}

		public Task<IEnumerable<Player>> GetPlayers( string fifaCode )
		{
			throw new NotImplementedException();
		}

		public Task<TeamResult> GetRepresentation( string fifaCode )
		{
			throw new NotImplementedException();
		}
	}
}
