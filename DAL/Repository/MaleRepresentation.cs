using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Utilities.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace DAL.Repository
{
	public class MaleRepresentation : IRepresentationRepo
	{
		public Task<IList<Representation>> GetAllTeams()
		{
			return Task.Run(() =>
			{
				var restClient = new RestClient("https://world-cup-json-2018.herokuapp.com/teams/");

				var response = restClient.Execute<IList<Representation>>(new RestRequest());

				if ( response.StatusCode != HttpStatusCode.OK )
					return null;

				return JsonConvert.DeserializeObject< IList<Representation> >(response.Content);
			});
		}

		public Task<List<Player>> GetPlayers( string fifaCode )
		{
			return Task.Run(() =>
			{
				var restClient = new RestClient($"https://world-cup-json-2018.herokuapp.com/matches/country?fifa_code={fifaCode}");

				var response = restClient.Execute<List<Match>>(new RestRequest());

				List<Match> allMatches = JsonConvert.DeserializeObject<List<Match>>(response.Content);

				return GetRepresentationPlayers(allMatches[0], fifaCode);
			});
		}
		
		public Task<List<Match>> GetMatchesForCountry( Representation representation )
		{
			return Task.Run(() =>
			{
				var restClient = new RestClient($"https://world-cup-json-2018.herokuapp.com/matches/country?fifa_code={representation.FifaCode}");

				var response = restClient.Execute<List<Match>>(new RestRequest());

				List<Match> allMatches = JsonConvert.DeserializeObject<List<Match>>(response.Content);

				return allMatches;
			});
		}

		public static List<Player> GetRepresentationPlayers( Match match, string representationCode )
		{
			if (match.HomeTeam.Code == representationCode)
			{
				List<Player> allPlayers = match.HomeTeamStatistics.StartingEleven;
				allPlayers.AddRange(match.HomeTeamStatistics.Substitutes);
				return allPlayers;
			}
			else
			{
				List<Player> allPlayers = match.AwayTeamStatistics.StartingEleven;
				allPlayers.AddRange(match.AwayTeamStatistics.Substitutes);
				return allPlayers;
			}
		}
	}
}
