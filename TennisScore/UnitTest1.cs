﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class UnitTest1
    {
        private IRepository<Game> repo = Substitute.For<IRepository<Game>>();

        [TestMethod]
        public void Love_All()
        {
            var gameId = 1;

            GivenPlayerScore(gameId, 0, 0);
            TennisGame tennisGame = new TennisGame(repo);


            ScoreShouldBe("Love All", gameId);
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 1, SecondPlayerScore = 0 });

            TennisGame tennisGame = new TennisGame(repo);

            ScoreShouldBe("Fifteen Love", gameId);
        }

        [TestMethod]
        public void Thirty_Love()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 2, SecondPlayerScore = 0 });

            TennisGame tennisGame = new TennisGame(repo);

            ScoreShouldBe("Thirty Love", gameId);
        }

        [TestMethod]
        public void Forty_Love()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 3, SecondPlayerScore = 0 });

            TennisGame tennisGame = new TennisGame(repo);

            ScoreShouldBe("Forty Love", gameId);
        }

        [TestMethod]
        public void Love_Fifteen()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 0, SecondPlayerScore = 1 });

            TennisGame tennisGame = new TennisGame(repo);

            ScoreShouldBe("Love Fifteen", gameId);
        }

        [TestMethod]
        public void Fifteen_All()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 1, SecondPlayerScore = 1 });

            TennisGame tennisGame = new TennisGame(repo);

            ScoreShouldBe("Fifteen All", gameId);
        }

        [TestMethod]
        public void Deuce()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 3, SecondPlayerScore = 3 });

            TennisGame tennisGame = new TennisGame(repo);

            ScoreShouldBe("Deuce", gameId);
        }

        [TestMethod]
        public void DeuceWith4()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 4, SecondPlayerScore = 4 });

            TennisGame tennisGame = new TennisGame(repo);

            ScoreShouldBe("Deuce", gameId);
        }

        [TestMethod]
        public void Joey_Adv()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 4, SecondPlayerScore = 3, FirstPlayName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            ScoreShouldBe("Joey Adv", gameId);
        }

        [TestMethod]
        public void Tom_Adv()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 3, SecondPlayerScore = 4, FirstPlayName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            ScoreShouldBe("Tom Adv", gameId);
        }

        [TestMethod]
        public void Joey_Win()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 5, SecondPlayerScore = 3, FirstPlayName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            ScoreShouldBe("Joey Win", gameId);
        }

        [TestMethod]
        public void Tom_Win()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 3, SecondPlayerScore = 5, FirstPlayName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            ScoreShouldBe("Tom Win", gameId);
        }

        [TestMethod]
        public void Joey_Win_with_4_0()
        {
            var gameId = 1;

            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 4, SecondPlayerScore = 0, FirstPlayName = "Joey", SecondPlayerName = "Tom" });

            TennisGame tennisGame = new TennisGame(repo);

            ScoreShouldBe("Joey Win", gameId);
        }

        private void GivenPlayerScore(int gameId, int firstPlayerScore, int secondPlayerScore)
        {
            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = firstPlayerScore, SecondPlayerScore = secondPlayerScore });
        }

        private void ScoreShouldBe(string expected, int id)
        {
            TennisGame tennisGame = new TennisGame(repo);
            Assert.AreEqual(expected, tennisGame.ScoreResult(id));
        }
    }
}