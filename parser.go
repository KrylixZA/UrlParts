package main

import (
	"strconv"
	"strings"
)

func Parse(input string) Url {
	// Protocol
	indexOfProtocolSubDomainSeparator := strings.Index(input, "://")
	protocol := input[0:indexOfProtocolSubDomainSeparator]
	input = input[indexOfProtocolSubDomainSeparator+3:]

	// Sub domain
	subDomain := ""
	if countNumberOfPoints(input) >= 2 {
		indexOfFirstPoint := strings.Index(input, ".")
		subDomain = input[0:indexOfFirstPoint]
		input = input[indexOfFirstPoint+1:]
	}

	// Domain name
	indexOfSlash := strings.Index(input, "/")
	if indexOfSlash == -1 {
		indexOfSlash = len(input)
	}
	domainName := input[0:indexOfSlash]

	// Port
	indexOfPort := strings.Index(domainName, ":")
	port := getDefaultPort(protocol)
	if indexOfPort != -1 {
		p, err := strconv.Atoi(domainName[indexOfPort+1:])
		if err != nil {
			panic(err)
		}
		port = p
		domainName = domainName[0:indexOfPort]
	}

	// Path
	if indexOfSlash != len(input) {
		input = input[indexOfSlash+1:]
	} else {
		input = ""
	}

	return Url{
		Protocol:   protocol,
		SubDomain:  subDomain,
		DomainName: domainName,
		Port:       port,
		Path:       input,
	}
}

func countNumberOfPoints(input string) int {
	counter := 0

	for _, char := range input {
		if char == rune('.') {
			counter++
		}
	}

	return counter
}

func getDefaultPort(protocol string) int {
	switch protocol {
	case "http":
		return 80
	case "https":
		return 443
	case "ftp":
		return 21
	default:
		return 80
	}
}
