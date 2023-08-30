using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using Tamagotchi.Controller;
using Tamagotchi.Model;
using Tamagotchi.Service;
using Tamagotchi.View;

namespace Tamagotchi
{
    class Program
    {

        static void Main(string[] args)
        {
            TamagotchiContoller tamagotchiContoller = new TamagotchiContoller();
            tamagotchiContoller.Jogar();
        }
    }

}
