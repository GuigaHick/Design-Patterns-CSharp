﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTemplateMethod
{
    public abstract class Game
    {
        protected int currentPlayer;
        protected readonly int numberOfPlayers;

        protected Game(int numberOfPlayers)
        {
            this.numberOfPlayers = numberOfPlayers;
        }

        public void Run()
        {
            Start();
            while (!HaveWinner)
            {
                TakeTurn();
                Console.WriteLine($"Player {WinningPlayer} wins.");
            }
        }

        protected abstract void Start();
        protected abstract void TakeTurn();
        protected abstract bool HaveWinner { get; }
        protected abstract int WinningPlayer { get; }

    }

    public class Chess : Game
    {

        private int turn = 1;
        private int maxTurns = 10;

        public Chess() : base(2)
        {

        }

        protected override void Start()
        {
            Console.WriteLine($"Starting a game of chess with {numberOfPlayers} players");
        }

        protected override void TakeTurn()
        {
            Console.WriteLine($" Turn {turn++} taken by player {currentPlayer}.");
            currentPlayer = (currentPlayer + 1) % numberOfPlayers;
        }

        protected override bool HaveWinner => turn == maxTurns;
        protected override int WinningPlayer => currentPlayer;
    }




    class Program
    {
        static void Main(string[] args)
        {
            var chess = new Chess();
            chess.Run();
            Console.ReadKey();
        }
    }
}
