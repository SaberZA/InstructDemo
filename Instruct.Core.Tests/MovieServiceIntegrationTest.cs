using System;
using System.Net.NetworkInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Instruct.Core.Tests
{
    [TestClass]
    public class MovieServiceIntegrationTest
    {
        private string localServerAddress = "http://localhost:1337";

        [Test]
        public void MovieService_ShouldNotBeNull()
        {
            //---------------Set up test pack-------------------
            var movieService = CreateMovieService();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.IsNotNull(movieService);
        }
        
        [Test]
        public async void GetTop100Movies_GivenMovieService_ShouldReturn100Movies()
        {
            //---------------Set up test pack-------------------
            var movieService = new MovieService(localServerAddress);
            //---------------Assert Precondition----------------
            
            //---------------Execute Test ----------------------
            var movieList = await movieService.GetTop100MoviesOfAllTime();
            //---------------Test Result -----------------------
            Assert.AreEqual(100, movieList.Movies.Count);
        }


        private static MovieService CreateMovieService()
        {
            return new MovieService();
        }
    }
}
