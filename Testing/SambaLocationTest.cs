using TransmissionRemoteDotnet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Testing
{
    /// <summary>
    ///This is a test class for SambaLocation and is intended
    ///to contain all SambaLocation Unit Tests
    ///</summary>
    [TestClass()]
    public class SambaLocationTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        //     /ize/ > \\aaa\aa

        /// <summary>
        ///Testing if the torrent has more files than one.
        ///</summary>
        [TestMethod()]
        public void MoreFile()
        {
            Dictionary<string, string> mappings = new Dictionary<string,string>();
            mappings.Add("/data/torrent/", @"\\server\torrent");
            mappings.Add("/data/other/", @"\\server\other");
            mappings.Add("/data/torrent2/", @"\\server\torrent2");
            string downloadDir = "/data/torrent";
            string torrentname = "testtorrent";
            int fcount = 3;
            string expected = @"\\server\torrent\testtorrent\";
            string actual;
            actual = Toolbox.BuildSambaLocation(mappings, downloadDir, false, torrentname, fcount);
            Assert.AreEqual(expected, actual);
            expected = @"\\server\torrent\";
            actual = Toolbox.BuildSambaLocation(mappings, downloadDir, true, torrentname, fcount);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Testing if the torrent has only one file.
        ///</summary>
        [TestMethod()]
        public void OneFile()
        {
            Dictionary<string, string> mappings = new Dictionary<string, string>();
            mappings.Add("/data/torrent/", @"\\server\torrent");
            mappings.Add("/data/other/", @"\\server\other");
            mappings.Add("/data/torrent2/", @"\\server\torrent2");
            string downloadDir = "/data/torrent";
            string torrentname = "testtorrent";
            int fcount = 1;
            string expected = @"\\server\torrent\";
            string actual;
            actual = Toolbox.BuildSambaLocation(mappings, downloadDir, false, torrentname, fcount);
            Assert.AreEqual(expected, actual);
            expected = @"\\server\torrent\";
            actual = Toolbox.BuildSambaLocation(mappings, downloadDir, true, torrentname, fcount);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///Testing if the torrent has more files than one, and place in a subdir.
        ///</summary>
        [TestMethod()]
        public void MoreFileSubdir()
        {
            Dictionary<string, string> mappings = new Dictionary<string, string>();
            mappings.Add("/data/torrent/", @"\\server\torrent");
            mappings.Add("/data/other/", @"\\server\other");
            mappings.Add("/data/torrent2/", @"\\server\torrent2");
            string downloadDir = "/data/torrent/foo";
            string torrentname = "testtorrent";
            int fcount = 3;
            string expected = @"\\server\torrent\foo\testtorrent\";
            string actual;
            actual = Toolbox.BuildSambaLocation(mappings, downloadDir, false, torrentname, fcount);
            Assert.AreEqual(expected, actual);
            expected = @"\\server\torrent\foo\";
            actual = Toolbox.BuildSambaLocation(mappings, downloadDir, true, torrentname, fcount);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Testing if the torrent has only one file, and place in a subdir.
        ///</summary>
        [TestMethod()]
        public void OneFileSubdir()
        {
            Dictionary<string, string> mappings = new Dictionary<string, string>();
            mappings.Add("/data/torrent/", @"\\server\torrent");
            mappings.Add("/data/other/", @"\\server\other");
            mappings.Add("/data/torrent2/", @"\\server\torrent2");
            string downloadDir = "/data/torrent/foo";
            string torrentname = "testtorrent";
            int fcount = 1;
            string expected = @"\\server\torrent\foo\";
            string actual;
            actual = Toolbox.BuildSambaLocation(mappings, downloadDir, false, torrentname, fcount);
            Assert.AreEqual(expected, actual);
            expected = @"\\server\torrent\foo\";
            actual = Toolbox.BuildSambaLocation(mappings, downloadDir, true, torrentname, fcount);
            Assert.AreEqual(expected, actual);
        }
    }
}
