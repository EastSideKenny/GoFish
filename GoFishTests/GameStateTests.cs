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
    }     
}
