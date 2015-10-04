# garfield-archive
Downloads archive of Garfield strips on your computer. Written in C# using WinForms.

![](https://raw.githubusercontent.com/stil/garfield-archive/master/demo.gif)

##Features
* Downloads sharp GIF strips (no JPEG) and converts them to PNG to reduce size.
* Every strip has width of 1200px.
* You can run program multiple times. It will download missing/new strips if needed.
* Uses multiple threads to speed up download and conversion.

##optiPNG
This program internally uses excellent [optipng](http://optipng.sourceforge.net/) utility to convert GIF images to PNG and reduce the size.
