//----------
        public string encriptar(string entrada)
        {
            string result = string.Empty;
            Byte[] encriptar = System.Text.Encoding.Unicode.GetBytes(entrada);
            result = Convert.ToBase64String(encriptar);
            return result;
        }
        //-----------
        public string desencriptar(string entrada)
        {
            string result = string.Empty;
            try
            {

                Byte[] desencriptar = Convert.FromBase64String(entrada);

                result = System.Text.Encoding.Unicode.GetString(desencriptar);

            }
            catch (Exception)
            {
                
            }

            return result;
        }
        //-----------