Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports RataPerez

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub ProbarCédula()
        Dim DU As New DatosUsuario
        DU.Cedula.Valor = "las pelotas"
        Assert.AreEqual(False, DU.CedulaBien)
    End Sub

End Class