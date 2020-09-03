using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Utilities.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace DAL.Repository
{
	public class FemaleRepresentation : IRepresentationRepo
	{
		public Task<IList<Representation>> GetAllTeams()
		{
			return Task.Run(() =>
			{
				var restClient = new RestClient("https://worldcup.sfg.io/teams/");

				var response = restClient.Execute<IList<Representation>>(new RestRequest());

				if ( response.StatusCode != HttpStatusCode.OK )
					return null;

				return JsonConvert.DeserializeObject<IList<Representation>>(response.Content);
			});
		}

		public Task<List<Player>> GetPlayers( string fifaCode )
		{
			return Task.Run(() =>
			{
				var restClient = new RestClient($"https://worldcup.sfg.io/matches/country?fifa_code={fifaCode}");

				var response = restClient.Execute<List<Match>>(new RestRequest());

				List<Match> allMatches = JsonConvert.DeserializeObject<List<Match>>(response.Content);

				return MaleRepresentation.GetRepresentationPlayers(allMatches[0], fifaCode);
			});
		}

		public Task<List<Match>> GetMatchesForCountry( Representation representation )
		{
			return Task.Run(() =>
			{
				var restClient = new RestClient($"https://worldcup.sfg.io/matches/country?fifa_code={representation.FifaCode}");

				var response = restClient.Execute<List<Match>>(new RestRequest());

				List<Match> allMatches = JsonConvert.DeserializeObject<List<Match>>(response.Content);

				return allMatches;
			});
		}
	}
}
