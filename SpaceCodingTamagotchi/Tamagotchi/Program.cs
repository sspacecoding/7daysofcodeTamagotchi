
using Newtonsoft.Json;
using RestSharp;
using System;
using Tamagotchi;

public class Program
{
    public static void Main(string[] args)
    {
        // Obter a lista de espécies de Pokémons

        var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
        var request = new RestRequest(Method.GET);
        IRestResponse response = client.Execute(request);

        var pokemonEspeciesResposta = JsonConvert.DeserializeObject<PokemonSpeciesResult>(response.Content);

        // Apresentar as opções ao jogador
        Console.WriteLine("Escolha um Tamagotchi:");
        for (int i = 0; i < pokemonEspeciesResposta.Results.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pokemonEspeciesResposta.Results[i].Name}");
        }

        // Obter a escolha do jogador
        int escolha;


        while (true)
        {
            Console.WriteLine("\n");
            Console.Write("Escolha um número: ");
            if (!int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= pokemonEspeciesResposta.Results.Count)
            {
                Console.WriteLine("Escolha inválida. Tente novamente.");
            }
            else
                break;
        }

        // Obter as características do Pokémon escolhido
        client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{escolha}");
        request = new RestRequest(Method.GET);
        response = client.Execute(request);

        // Mostrar as características ao jogador
        Console.WriteLine(response.Content);


    }
}