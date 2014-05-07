μCSS
=====

A lightweight CSS parser for .NET programs.

##How to use

1.) Clone this repository, compile the project and copy the DLL to your application's folder

2.) Add a reference to the mucss.dll

3.) Initialize μCSS where it is need with the code:
`mucss.Parser p = new mucss.Parser(THE BODY OF CSS)`

4.) Then you may get all selectors using `List<mucss.Selector> selectors = p.GetAllStyles()` or only one that is required: `mucss.Selector style = p.Get(THE SELECTOR NAME OR REGEXP MASK)`

Please note that μCSS is too simple and lightweight to be an full CSS parser: it doesn't support @media, @import and other "pre-compilation instructions". Also it has some non-found bugs.
