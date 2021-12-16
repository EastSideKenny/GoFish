using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GoFish;

namespace GoFishTests
{
    [TestClass]
    public class GameStateTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            var computerPlayerNames = new List<string>()
            {
                "Computer1",
                "Computer2",
                "Computer3",
            };
            var gameState = new GameState("Human", computerPlayerNames, new Deck());

            CollectionAssert.AreEqual(
                new List<string> { "Human", "Computer1", "Computer2", "Computer3"},
                gameState.Players.Select(player => player.Name).ToList());

            Assert.AreEqual(5, gameState.HumanPlayer.Hand.Count());
        }

        [TestMethod]
        public void TestRandomPlayer()
        {
            var computerPlayerNames = new List<string>()
            {
                "Computer1",
                "Computer2",
                "Computer3",
            };

            var gameState = new GameState("Human", computerPlayerNames, new Deck());
            Player.Random = new MockRandom() { ValueToReturn = 1 };
            Assert.AreEqual("Computer2", gameState.RandomPlayer(gameState.Players.ToList()[0]).Name);

            Player.Random = new MockRandom() { ValueToReturn = 0 };
            Assert.AreEqual("Human", gameState.RandomPlayer(gameState.Players.ToList()[1]).Name);
            Assert.AreEqual("Computer1", gameState.RandomPlayer(gameState.Players.ToList()[0]).Name);
        }
    }     
}
