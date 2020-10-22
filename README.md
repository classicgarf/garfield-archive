# garfield-archive

## Fork Notes
This is a somewhat sloppy and bodged fork to download from Professor Garfield. It also adds new features, including resizing the window, choosing a start date, toggling PNG conversion, converting file names to YYYY-MM-DD format, and sorting with month folders. This might be improved later, but it's unlikely. This is mainly released just as a quick way to download the 2x strips from Professor Garfield before it goes down as well. The extra features are just me being somewhat annoyed with how it works and trying to make it easier to fit in with anyone's current comic archive. Also, if the original dev of this program sees this, I'm very sorry for any horrendus code you read here

**The following is the unedited original (and outdated) description**

## Description
Downloads archive of Garfield strips on your computer. Written in C# using WinForms.

##Features
* Downloads sharp GIF strips (no JPEG) and converts them to PNG to reduce size.
* Every strip has width of 1200px.
* You can run program multiple times. It will download missing/new strips if needed.
* Uses multiple threads to speed up download and conversion.

##Build
You can download compiled program from repository [Releases](https://github.com/stil/garfield-archive/releases) tab.

##optiPNG
This program internally uses excellent [optipng](http://optipng.sourceforge.net/) utility to convert GIF images to PNG and reduce the size.
