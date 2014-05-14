μCSS
=====

A lightweight CSS parser for .NET programs.

##How to use

###Common
1.) Clone this repository, compile the project and copy the DLL to your application's folder.

2.) Add a reference to the mucss.dll.

3.) Initialize μCSS parser where it is need with the code:
`mucss.Stylesheet css = new mucss.Stylesheet(THE CSS)`
The argument is the content of the CSS file.

4.) After this, you may use μCSS.

###Get all selectors
	Dictionary<string, mucss.Selector> sels = css.GetAllSelectors();

###Get a selector
	mucss.Selector sel = css[SELECTOR_PATTERN];
*Note that the SELECTOR_PATTERN may be a RegExp mask, but currently only the first selector will be returned.*

###Get a declaration value of the selector
	string value = css[SELECTOR_PATTERN, PROPERTY_NAME].Value;

	string value = css[SELECTOR_PATTERN].Declarations[PROPERTY_NAME].Value;

	mucss.Selector sel = css[SELECTOR_PATTERN];
	string value = sel.Declarations[PROPERTY_NAME].Value;
*All ways are identical, but the third may be used to enlarge perfomace of the program if many declarations of one selector are used (no need to load selector every time).*

Please note that μCSS is too simple and lightweight to be an full CSS parser: it doesn't support @media, @import and other "pre-compilation instructions". Also it has some non-found bugs.
The more tips & tricks may be found in the wiki.