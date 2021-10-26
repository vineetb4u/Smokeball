using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smokeball.Services;
using System;

namespace Smokeball.Tests
{
    [TestClass]
    public class SearchServiceTests
    {
        private ISearchService searchService;

        [TestInitialize]
        public void Initialize()
        {
            var services = new ServiceCollection();
            services.AddTransient<ISearchService, SearchService>();

            var serviceProvider = services.BuildServiceProvider();

            searchService = serviceProvider.GetService<ISearchService>();
        }


        [TestMethod]
        public void Test_when_has_search_url()
        {
            var res = searchService.GetSearchResult("http://www.google.com");

            Assert.IsNotNull(res);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_when_has_no_search_url()
        {
            var res = searchService.GetSearchResult(string.Empty);

            Assert.IsNotNull(res);
        }
    }
}
