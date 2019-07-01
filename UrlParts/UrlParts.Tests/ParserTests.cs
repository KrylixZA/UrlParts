using FluentAssertions;
using NUnit.Framework;

namespace UrlParts.Tests
{
    [TestFixture]
    public class ParserTests
    {
        [Test]
        public void Decompose_GivenGoogleUrl_ShouldReturnProtocolOfHttps()
        {
            // Arrange
            var url = "https://google.com";
            var expectedProtocol = "https";

            // Act
            var urlParts = Parser.Decompose(url);

            // Assert
            Assert.AreEqual(expectedProtocol, urlParts.Protocol);
        }

        [Test]
        public void Decompose_GivenTddBuddyUrl_ShouldReturnProtocolOfHttp()
        {
            // Arrange
            var url = "http://wwww.tddbuddy.com";
            var expectedProtocol = "http";

            // Act
            var urlParts = Parser.Decompose(url);

            // Assert
            Assert.AreEqual(expectedProtocol, urlParts.Protocol);
        }

        [Test]
        public void Decompose_GivenGoogleUrl_ShouldReturnGoogleDomain()
        {
            // Arrange
            var url = "https://google.com";
            var expectedDomain = "google.com";

            // Act
            var urlParts = Parser.Decompose(url);

            // Assert
            Assert.AreEqual(expectedDomain, urlParts.Domain);
        }

        [Test]
        public void Decompose_GivenTddyBuddyUrl_ShouldReturnTddBuddyDomain()
        {
            // Arrange
            var url = "http://www.tddbuddy.com";
            var expectedDomain = "tddbuddy.com";

            // Act
            var urlParts = Parser.Decompose(url);

            // Assert
            Assert.AreEqual(expectedDomain, urlParts.Domain);
        }

        [Test]
        public void Decompose_GivenGoogleUrl_ShouldReturnEmptySubDomain()
        {
            // Arrange
            var url = "https://google.com";

            // Act
            var urlParts = Parser.Decompose(url);

            // Assert
            Assert.AreEqual(string.Empty, urlParts.SubDomain);
        }

        [Test]
        public void Decompose_GivenTddyBuddyUrl_ShouldReturnWwwSubDomain()
        {
            // Arrange
            var url = "http://www.tddbuddy.com";
            var expectedSubDomain = "www";

            // Act
            var urlParts = Parser.Decompose(url);

            // Assert
            Assert.AreEqual(expectedSubDomain, urlParts.SubDomain);
        }

        [Test]
        public void Decompose_GivenGoogleUrl_ShouldReturnPort443()
        {
            // Arrange
            var url = "https://google.com";
            var expectedPort = "443";

            // Act
            var urlParts = Parser.Decompose(url);

            // Assert
            Assert.AreEqual(expectedPort, urlParts.Port);
        }

        [Test]
        public void Decompose_GivenTddyBuddyUrl_ShouldReturnPort80()
        {
            // Arrange
            var url = "http://www.tddbuddy.com";
            var expectedPort = "80";

            // Act
            var urlParts = Parser.Decompose(url);

            // Assert
            Assert.AreEqual(expectedPort, urlParts.Port);
        }

        [Test]
        public void Decompose_GivenFooBarUrlWithFoobarDotHtmlPath_ShouldReturnFooBarDotHtmlPath()
        {
            // Arrange
            var url = "http://foo.bar.com/foobar.html";
            var expectedPath = "foobar.html";

            // Act
            var urlParts = Parser.Decompose(url);

            // Assert
            Assert.AreEqual(expectedPath, urlParts.Path);
        }

        [Test]
        public void Decompose_GivenFtpFooBarUrlWith9000PortAndFilesPath_ShouldReturn9000PortAndFilesPath()
        {
            // Arrange
            var url = "ftp://foo.com:9000/files";
            var expectedPort = "9000";
            var expectedPath = "files";

            // Act
            var urlParts = Parser.Decompose(url);

            // Assert
            Assert.AreEqual(expectedPort, urlParts.Port);
            Assert.AreEqual(expectedPath, urlParts.Path);
        }

        [Test]
        public void Decompose_GivenGoogleUrl_ShouldReturnExpectedUrlParts()
        {
            // Arrange
            var url = "https://google.com";
            var expectedParts = new UrlParts
            {
                Protocol = "https",
                SubDomain = string.Empty,
                Domain = "google.com",
                Port = "443",
                Path = string.Empty
            };

            // Act
            var actualParts = Parser.Decompose(url);

            // Assert
            actualParts.Should().BeEquivalentTo(expectedParts);
        }

        [Test]
        public void Decompose_GivenTddBuddy_ShouldReturnExpectedUrlParts()
        {
            // Arrange
            var url = "http://www.tddbuddy.com";
            var expectedParts = new UrlParts
            {
                Protocol = "http",
                SubDomain = "www",
                Domain = "tddbuddy.com",
                Port = "80",
                Path = string.Empty
            };

            // Act
            var actualParts = Parser.Decompose(url);

            // Assert
            actualParts.Should().BeEquivalentTo(expectedParts);
        }

        [Test]
        public void Decompose_GivenFooBarUrlWithFooBarDotHtmlPath_ShouldReturnExpectedUrlParts()
        {
            // Arrange
            var url = "http://foo.bar.com/foobar.html";
            var expectedParts = new UrlParts
            {
                Protocol = "http",
                SubDomain = "foo",
                Domain = "bar.com",
                Port = "80",
                Path = "foobar.html"
            };

            // Act
            var actualParts = Parser.Decompose(url);

            // Assert
            actualParts.Should().BeEquivalentTo(expectedParts);
        }

        [Test]
        public void Decompose_GivenFtpFooBarUrlWith9000PortAndFilesPath_ShouldReturnExpectedUrlParts()
        {
            // Arrange
            var url = "ftp://foo.com:9000/files";
            var expectedParts = new UrlParts
            {
                Protocol = "ftp",
                SubDomain = string.Empty,
                Domain = "foo.com",
                Port = "9000",
                Path = "files"
            };

            // Act
            var actualParts = Parser.Decompose(url);

            // Assert
            actualParts.Should().BeEquivalentTo(expectedParts);
        }

        [Test]
        public void Decompose_GivenFtpFooBarUrlWith8080PortAndDownloadSlashInstallsPath_ShouldReturnExpectedUrlParts()
        {
            // Arrange
            var url = "https://www.foobar.com:8080/download/install.exe";
            var expectedParts = new UrlParts
            {
                Protocol = "https",
                SubDomain = "www",
                Domain = "foobar.com",
                Port = "8080",
                Path = "download/install.exe"
            };

            // Act
            var actualParts = Parser.Decompose(url);

            // Assert
            actualParts.Should().BeEquivalentTo(expectedParts);
        }
    }
}
