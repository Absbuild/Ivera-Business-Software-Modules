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

    //------
    public SqlConnection methodConnect()    
    {
        ficheiroTextoConexao();
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(@"Data Source='" + nameServer.ToString() + "';Initial Catalog='" + nameDataBase + "';Integrated Security=false; User ID = " + nameUser.ToString() + "; Password = " + passwordUser.ToString());
            conn.Open();
            return conn;

        }
        catch (Exception e)
        {

            calert.AlertError(e.Message);

        }
        return conn;
    }
    //-------
    String msg=null;
    public void connectionTest(string server, string database, string user, string password)
    {
        string connectionString = @"Server=" + server+ ";Database=" +database + ";Uid=" +user + ";Password=" + password + ";";
        try
        {
            SqlHelper helper = new SqlHelper(connectionString);
            if (helper.isConnection)
            
            calert.AlertSuccess("Conexão efectuada com sucesso...");
        }
        catch (Exception ex)
        {
            calert.AlertError("Erro de conexão: " + ex.Message);
            msg = "error: " + ex.Message;
        }
        
    }
    
}