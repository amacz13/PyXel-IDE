Imports FastColoredTextBoxNS

Public Class AutoCompleteTools

    Public Shared Sub LoadDefaultItems(menu As AutocompleteMenu, lang As Form1.Languages)
        Select Case lang
            Case Form1.Languages.Python
                Dim PythonItems As ICollection(Of String)
                PythonItems.Add("def")
                PythonItems.Add("import")
                menu.Items.SetAutocompleteItems(PythonItems)
        End Select
    End Sub

End Class
