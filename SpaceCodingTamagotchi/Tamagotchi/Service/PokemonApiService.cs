using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Model;

namespace Tamagotchi.Service
{
    public class PokemonApiService
    {
        public List<PokemonResult> ObterEspeciesDisponiveis()
        {
            try
            {
                // Obter a lista de espécies de Pokémons

                var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    var pokemonEspeciesResposta = JsonConvert.DeserializeObject<PokemonSpeciesResult>(response.Content);

                    return pokemonEspeciesResposta.Results;
                }
                Console.WriteLine($"Erro ao obter detalhes do Pokémon: {response.Content}");
                return null;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro de solicitação: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro inesperado: {e.Message}");
                return null;
            }
        }

        public PokemonDetailsResult ObterDetalhesDaEspecie(PokemonResult especie)
        {
            try
            {
                // Obter as características do Pokémon escolhido
                var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{especie.Name}");
                var request = new RestRequest(Method.GET);
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<PokemonDetailsResult>(response.Content);
                }
                Console.WriteLine($"Erro ao obter detalhes do Pokémon: {response.Content}");
                return null;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro de solicitação: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro inesperado: {e.Message}");
                return null;
            }
        }
    }
}
