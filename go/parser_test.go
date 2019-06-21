package main

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func TestParse_GivenBasicUrl_ShouldReturnExpectedProtocol(t *testing.T) {
	// Arrange
	input := "http://www.tddbuddy.com"

	expectedProtocol := "http"

	// Act
	url := Parse(input)

	// Assert
	assert.Equal(t, expectedProtocol, url.Protocol)
}

func TestParse_GivenBasicUrl_ShouldReturnExpectedSubDomain(t *testing.T) {
	// Arrange
	input := "http://www.tddbuddy.com"

	expectedSubDomain := "www"

	// Act
	url := Parse(input)

	// Assert
	assert.Equal(t, expectedSubDomain, url.SubDomain)
}

func TestParse_GivenBasicUrl_ShouldReturnExpectedDomainName(t *testing.T) {
	// Arrange
	input := "http://www.tddbuddy.com"

	expectedDomainName := "tddbuddy.com"

	// Act
	url := Parse(input)

	// Assert
	assert.Equal(t, expectedDomainName, url.DomainName)
}

func TestParse_GivenBasicUrl_ShouldReturnExpectedPort(t *testing.T) {
	// Arrange
	input := "http://www.tddbuddy.com"

	expectedDomainName := 80

	// Act
	url := Parse(input)

	// Assert
	assert.Equal(t, expectedDomainName, url.Port)
}

func TestParse_GivenBasicUrl_ShouldReturnExpectedPath(t *testing.T) {
	// Arrange
	input := "http://www.tddbuddy.com"

	expectedPath := ""

	// Act
	url := Parse(input)

	// Assert
	assert.Equal(t, expectedPath, url.Path)
}

func TestParse_GivenHttpFooBarUrl_ShouldReturnExpectedUrl(t *testing.T) {
	// Arrange
	input := "http://foo.bar.com/foobar.html"

	expectedUrl := Url{
		Protocol:   "http",
		SubDomain:  "foo",
		DomainName: "bar.com",
		Port:       80,
		Path:       "foobar.html",
	}

	// Act
	actualUrl := Parse(input)

	// Assert
	assert.Equal(t, expectedUrl, actualUrl)
}

func TestParse_GivenFtpUrlWithNoSubDomainAndCustomPort_ShouldReturnExpectedUrl(t *testing.T) {
	// Arrange
	input := "ftp://foo.com:9000/files"

	expectedUrl := Url{
		Protocol:   "ftp",
		SubDomain:  "",
		DomainName: "foo.com",
		Port:       9000,
		Path:       "files",
	}

	// Act
	actualUrl := Parse(input)

	// Assert
	assert.Equal(t, expectedUrl, actualUrl)
}

func TestParse_GivenHttpsUrl_ShouldReturnExpectedUrl(t *testing.T) {
	// Arrange
	input := "https://www.foobar.com/download/install.exe"

	expectedUrl := Url{
		Protocol:   "https",
		SubDomain:  "www",
		DomainName: "foobar.com",
		Port:       443,
		Path:       "download/install.exe",
	}

	// Act
	actualUrl := Parse(input)

	// Assert
	assert.Equal(t, expectedUrl, actualUrl)
}

func TestParse_GivenHttpsUrlWithCustomPort_ShouldReturnExpectedUrl(t *testing.T) {
	// Arrange
	input := "https://www.foobar.com:8080/download/install.exe"

	expectedUrl := Url{
		Protocol:   "https",
		SubDomain:  "www",
		DomainName: "foobar.com",
		Port:       8080,
		Path:       "download/install.exe",
	}

	// Act
	actualUrl := Parse(input)

	// Assert
	assert.Equal(t, expectedUrl, actualUrl)
}
