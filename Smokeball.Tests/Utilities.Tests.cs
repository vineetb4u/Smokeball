using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smokeball.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smokeball.Tests
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        public void Test_when_pattern_not_matched()
        {
            var html = "<html><head><body></body></head></html>";
            var url = new Uri(@"http://www.smokeball.com.au");
            var result = Utils.FindPositions(html, @"(<a href=\""/url\?q=)(\w+[a-zA-Z0-9.-?=/]*)", url);

            Assert.IsTrue(result.Count == 0);
        }


        [TestMethod]
        public void Test_when_pattern_matched_position_1()
        {
            var url = new Uri(@"http://www.smokeball.com.au");
            var html = @"<html>
<head>
<body>
<a href=""/url?q=http://www.smokeball.com.au>
</body>
</head>
</html>";

            var result = Utils.FindPositions(html, @"(<a href=\""/url\?q=)(\w+[a-zA-Z0-9.-?=/]*)", url);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0] == 1);
        }

        [TestMethod]
        public void Test_when_pattern_matched_position_3()
        {
            var url = new Uri(@"http://www.smokeball.com.au");
            var html = @"<html>
<head>
<body>
<div><a href=""/url?q=http://www.google.com.au></div>
<div><a href=""/url?q=http://www.nrl.com.au></div>
<div><a href=""/url?q=http://www.smokeball.com.au></div>
</body>
</head>
</html>";

            var result = Utils.FindPositions(html, @"(<a href=\""/url\?q=)(\w+[a-zA-Z0-9.-?=/]*)", url);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0] == 3);
        }

        [TestMethod]
        public void Test_when_pattern_matched_position_3_5()
        {
            var url = new Uri(@"http://www.smokeball.com.au");
            var html = @"<html>
<head>
<body>
<div><a href=""/url?q=http://www.google.com.au></div>
<div><a href=""/url?q=http://www.nrl.com.au></div>
<div><a href=""/url?q=http://www.smokeball.com.au></div>
<div><a href=""/url?q=http://www.nrl.com.au></div>
<div><a href=""/url?q=http://www.smokeball.com.au></div>
</body>
</head>
</html>";

            var result = Utils.FindPositions(html, @"(<a href=\""/url\?q=)(\w+[a-zA-Z0-9.-?=/]*)", url);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0] == 3);
            Assert.IsTrue(result[1] == 5);

        }
    }
}
