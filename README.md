# LircSharpAPI #

LircSharpAPI is a basic ASP.NET API that allows you to control your LIRC devices using GET and POST requests. It is designed to be a standalone API or to use as a resource to write an ASP.NET page to control your devices.

## What is LIRC? ##
[LIRC](http://www.lirc.org/) stands for **L**inux **I**nfrared **R**emote **C**ontrol. LIRC itself allows you to send infra-red signals that are generally used in remote controls. LIRC also lets you record remote signals to send back later (which this application does not support).

## Why C# ##
I chose C# mainly because I wanted to use it for a Linux utility I use daily. With the release of ASP.NET 5, it is now possible to run ASP.NET on Linux devices. So why not?!

## What is this magic? Iow do I run this? ##
I suggest going to the [ASP.Net Documentation site](http://docs.asp.net/en/latest/getting-started/installing-on-linux.html) to get a good start on installing the .Net Execution Environment (DNX). You also can install [Visual Studio Code](https://code.visualstudio.com/) which happens to be in the Arch AUR. 

## Did you think this up all on your own? ##
Of course not! Big kudos to [alexbain](https://github.com/alexbain) for [writing this first in Node.JS](https://github.com/alexbain/lirc_web). If you'd rather use Node, then his project is great.