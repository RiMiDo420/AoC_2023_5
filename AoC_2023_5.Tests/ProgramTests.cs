
using Microsoft.VisualStudio.TestPlatform.TestHost;
using AoC_2023_5;

namespace AoC_2023_5.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ParseSeedsTest()
        {
            //arrange
            string input = "seeds: 72 92 11 51";
            List<int> expected = new List<int>{72,92,11,51};

            //act
            List<long> actual = Program.ParseSeedsEasy(input);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseMapTest() 
        {
            //arrange
            List<string> input = new List<string> { "soil-to-fertilizer map:","0 15 37","37 52 2","39 0 15" };
            List<(int, int, int)> expected = new List<(int, int, int)> { (0, 15, 37), (37, 52, 2), (39, 0, 15) };

            //act
            List<(int, int, int)> actual = Program.ParseMapEasy(input);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MapTest()
        {
            //arrange
            List<int> input = new List<int> { 34, 68, 3, 88 };
            List<(int, int, int)> map = new List<(int, int, int)> { (0, 42, 9), (92, 66, 8), (39, 0, 33) };
            List<long> expected = new List<long> { 34, 42, 88, 94 };

            //act
            List<long> actual = Program.EasyMap(input, map);
            actual.Sort(); 

            //assert
            Assert.AreEqual(expected, actual);
        }
        
        //[TestMethod]
        //public void EasyTest
    }
}