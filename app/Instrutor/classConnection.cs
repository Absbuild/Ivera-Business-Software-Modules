using System;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

public class Connection{
    public void ficheiroTextoConexao()
    {
        StreamReader sr;
        string ficheiro = @"connection.txt";
        if (File.Exists(folder + "\\" + ficheiro) == true)
        {
            sr = File.OpenText(folder + "\\" + ficheiro);
            string linha = "";
            while ((linha = sr.ReadLine()) != null)
            {
                string[] campos = new string[5];
                campos = linha.Split(';');

                nameServer = campos[0];
                nameDataBase = campos[1];
                nameUser = campos[2];
                passwordUser = ce.desencriptar(campos[3]);

            }
            sr.Close();
        }
        if (File.Exists(folder + "\\" + ficheiro) == false)
        {   
            MessageBox.Show("Ficheiro de conexao não encontrado!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Interface.ConfigConnection con = new Interface.ConfigConnection(1);
            con.ShowDialog();
        }
    }
}