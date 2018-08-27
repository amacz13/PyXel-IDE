Imports FastColoredTextBoxNS

Public Class AutoCompleteTools

    Public Shared Sub LoadDefaultItems(menu As AutocompleteMenu, lang As MainForm.Languages)
        Dim list As New ImageList
        list.Images.Add(0, My.Resources.keyword)
        list.Images.Add(1, My.Resources.Method)
        list.Images.Add(2, My.Resources.snippet)
        menu.ImageList = list

        Dim Keywords As String() = {}
        Dim Methods As String() = {}
        Dim snippets As String() = {}
        Dim KeywordsTip As String() = {}
        Dim MethodsTip As String() = {}
        Dim snippetsTip As String() = {}

        Select Case lang
            Case MainForm.Languages.Python
                Keywords = {"int()", "long()", "float()", "complex()", "str()", "tuple()", "list()", "set()", "dict()", "frozenset()", "chr()", "unichr()", "ord()", "hex()", "oct()"}
                KeywordsTip = {"Delare or cast to an integer number", "Delare or cast to a long number", "Delare or cast to a float number", "Delare or cast to a complex number", "Delare or cast to a string", "Delare or cast to a tuple", "Delare or cast to a list", "Delare or cast to a set", "Delare or cast to a dictionnary", "Delare or cast to a frozenset", "Delare or cast to a character", "Delare or cast a unicode character", "Cast a character to its integer value", "Delare or cast to a hexadecimal number", "Delare or cast to a octal number"}
                Methods = {"abs()", "all()", "any()", "ascii()", "bytearray()", "bytes()", "callable()", "chr()", "classmethod()", "compile()", "complex()", "delattr()", "dir()", "divmod()", "enumerate()", "eval()", "exec()", "filter()", "format()", "getattr()", "globals()", "hasattr()", "hash()", "help()", "hex()", "id()", "input()", "isinstance()", "issubclass()", "iter()", "len()", "locals()", "map()", "max()", "memoryview()", "min()", "next()", "oct()", "open()", "ord()", "pow()", "print()", "range()", "repr()", "reversed()", "round()", "setattr()", "sorted()", "sum()", "super()", "vars()", "zip()"}
                MethodsTip = {"Get the absolute value of a number", "Return True if all elements of the iterable are true", "Return True if any element of the iterable is true", "Return a string containing a printable representation of an objec", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
                snippets = {"if ^ :" + vbNewLine, "elif ^ :" + vbNewLine, "else :" + vbNewLine, "while ^ :" + vbNewLine, "for ^ :" + vbNewLine}
            Case MainForm.Languages.HTML
                snippets = {"<html>" + vbNewLine + "^" + vbNewLine + "</html>", "<head>" + vbNewLine + "^" + vbNewLine + "</head>", "<body>" + vbNewLine + "^" + vbNewLine + "</body>", "<div>" + vbNewLine + "^" + vbNewLine + "</div>", "<nav>" + vbNewLine + "^" + vbNewLine + "</nav>", "<p>" + vbNewLine + "^" + vbNewLine + "</p>", "<table>" + vbNewLine + "^" + vbNewLine + "</table>", "<meta>^</meta>", "<title>^</title>", "<h1>^</h1>", "<h2>^</h2>", "<h3>^</h3>", "<h4>^</h4>", "<h5>^</h5>", "<h6>^</h6>", "<b>^</b>", "<i>^</i>", "<script>" + vbNewLine + "^" + vbNewLine + "</script>", "<button>^</button>", "<input>^</input>", "<ul>" + vbNewLine + "^" + vbNewLine + "</ul>", "<ol>" + vbNewLine + "^" + vbNewLine + "</ol>", "<li>^</li>"}
            Case MainForm.Languages.C, MainForm.Languages.CPP
                Keywords = {"int", "char", "void", "float", "unsigned", "long"}
                KeywordsTip = {"Declare an integer number", "Declare a character", "Declare a void variable", "Declare a decimal number", "Declare an unsigned number", "Declare a long number"}
        End Select

        menu.SearchPattern = "[\w\.:=!<>]"

        Dim i As Integer = 0
        Dim items As New List(Of AutocompleteItem)()
        For Each item As String In Keywords
            items.Add(New AutocompleteItem(item) With {.ImageIndex = 0, .ToolTipText = KeywordsTip(i), .ToolTipTitle = item})
            i += 1
        Next
        i = 0
        For Each item As String In Methods
            items.Add(New AutocompleteItem(item) With {.ImageIndex = 1, .ToolTipText = MethodsTip(i), .ToolTipTitle = item})
            i += 1
        Next
        i = 0
        For Each item As String In snippets
            items.Add(New SnippetAutocompleteItem(item) With {.ImageIndex = 2})
            'i += 1, .ToolTipText = snippetsTip(i)
        Next

        menu.Items.SetAutocompleteItems(items)
    End Sub

End Class
