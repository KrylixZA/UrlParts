# URL Parts
A test-driven implementation of a URL parser which breaks down a URL into it's unique parts

## The Kata
We all know about URLs like http://www.tddbuddy.com. You are tasked to decompose a given URL into its parts. In the above example, we would get the result:
1. The protocol: "http"
2. The subdomain : ”www”
3. The domain name: "tddbuddy.com"
4. The port: 80 ( Default for HTTP )
5. The path: an empty string in our example.

Only handle top level domains like .com or .net. Do not attempt to handle second level domains like .co.uk or co.za.
Only handle the protocols specified in the default ports section below. Do not use built-in tools to solve this (i.e.: write your own function!).

### Default Ports
http: 80, https: 443, ftp: 21, sftp: 22

### Examples
* http://foo.bar.com/foobar.html
    * Protocol : http
    * Subdomain: foo
    * Domain name: bar.com
    * Port: 80
    * Path: foobar.html
* ftp://foo.com:9000/files
    * Protocol : ftp
    * Subdomain: empty string
    * Domain name: foo.com
    * Port: 9000
    * Path: files
* https://www.foobar.com:8080/download/install.exe
    * Protocol : https
    * Subdomain: www
    * Domain name: foobar.com
    * Port: 8080
    * Path: download/installer.exe
    
##### Credit
All credit goes to [Chillisoft](http://www.chillisoft.co.za/) who provided me with the Katas and the training to solve these problems.