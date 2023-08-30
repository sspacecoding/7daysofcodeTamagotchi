using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    public class Menu
    {
        public void MostrarMensagemDeBoasVindas()
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Bem-vindo ao jogo de adoção de mascotes!");
            Console.Write("Por favor, digite seu nome: ");
            string nomeJogador = Console.ReadLine();
            Console.WriteLine("Olá, " + nomeJogador + "! Vamos começar!");
        }

        public void MostrarMenuPrincipal()
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("1. Adoção de Mascotes");
            Console.WriteLine("2. Ver Mascotes Adotados");
            Console.WriteLine("3. Sair do Jogo");
            Console.Write("Escolha uma opção: ");

        }

        public int ObterEscolhaDoJogador()
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 4)
            {
                Console.Write("Escolha inválida. Por favor, escolha uma opção entre 1 e 4: ");
            }
            return escolha;
        }

        public void MostrarMenuDeAdocao()
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Menu de Adoção de Mascotes:");
            Console.WriteLine("1. Ver Espécies Disponíveis");
            Console.WriteLine("2. Ver Detalhes de uma Espécie");
            Console.WriteLine("3. Adotar um Mascote");
            Console.WriteLine("4. Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");
        }

        public void MostrarEspeciesDisponiveis(List<PokemonResult> especies)
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Espécies Disponíveis para Adoção:");
            for (int i = 0; i < especies.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + especies[i].Name);
            }
        }

        public void MostrarDetalhesDaEspecie(PokemonDetailsResult detalhes)
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Detalhes da Espécie:");
            Console.WriteLine("Nome: " + detalhes.Name);
            Console.WriteLine("Altura: " + detalhes.Height);
            Console.WriteLine("Peso: " + detalhes.Weight);
            Console.WriteLine("Habilidades:");
            foreach (var habilidade in detalhes.Abilities)
            {
                Console.WriteLine("- " + habilidade.Ability.Name);
            }
        }

        public bool ConfirmarAdocao()
        {
            Console.WriteLine("\n ──────────────");
            Console.Write("Você gostaria de adotar este mascote? (s/n): ");
            string resposta = Console.ReadLine();
            return resposta.ToLower() == "s";
        }

        public void MostrarMascotesAdotados(List<PokemonDetailsResult> mascotesAdotados)
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Mascotes Adotados:");
            if (mascotesAdotados.Count == 0)
            {
                Console.WriteLine("Você ainda não adotou nenhum mascote.");
            }
            else
            {
                for (int i = 0; i < mascotesAdotados.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + mascotesAdotados[i].Name);
                }
            }
        }
        public int ObterEspecieEscolhida(List<PokemonResult> especies)
        {
            Console.WriteLine("\n ──────────────");
            int escolha;
            while (true)
            {
                Console.Write("Escolha uma espécie pelo número (1-" + especies.Count + "): ");
                if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= especies.Count)
                {
                    break;
                }
                Console.WriteLine("Escolha inválida.");
            }
            return escolha - 1;
            // Ajuste para índice baseado em 0
        }
    }

}
