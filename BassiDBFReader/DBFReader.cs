using Newtonsoft.Json;
using System.Data;

namespace BassiDBFReader
{
    public static class DBFReader
    {
        private static string dataSource = "C:\\dbfs\\";
        private static string[] tableNames =
        {
            "ADHERENT",
            "ADHESION",
            "ASOCIADO",
            "CERTIFIC",
            "RECIBOS",
        };

        public static string GetDataFromFile(Tables table)
        {
            string filePath = dataSource + tableNames[(int)table];
            return GetDataTableDBF(filePath);
        }

        private static string GetDataTableDBF(string filePath)
        {
            string provider = "Microsoft.Jet.OLEDB.4.0";
            string dataSource = System.IO.Path.GetFullPath(filePath).Replace(System.IO.Path.GetFileName(filePath), "");
            string connectionString = $"Provider={provider}; Data Source={dataSource}; Extended Properties=dBASE IV;User ID=;Password=;";
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            string strQuery = "SELECT * FROM [" + System.IO.Path.GetFileName(filePath) + "]";
            System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);
            System.Data.DataSet ds = new System.Data.DataSet();
            adapter.Fill(ds);
            return JsonConvert.SerializeObject(ds.Tables[0]);
        }
    }

    public enum Tables
    {
        Adherent = 0,
        Adhesion = 1,
        Asociado = 2,
        Certificado = 3,
        Recibos = 4
    }
}
