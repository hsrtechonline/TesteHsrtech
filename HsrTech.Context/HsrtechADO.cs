using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Context
{
    public class HsrTechADO
    {
        string _strConexao;
        public HsrTechADO(string connectionString)
        {
            _strConexao = connectionString;

        }

        public List<dynamic> ExecuteQuery(string query)
        {
            List<dynamic> importacaoDetalhes = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(_strConexao))
            {

                conn.Open();

                SqlCommand comando = new SqlCommand();
                comando.Connection = conn;
                comando.CommandTimeout = 3600;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = query;

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Dictionary<string, object> propriedades = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            try
                            {
                                propriedades.Add(reader.GetName(i), reader[i] == System.DBNull.Value ? string.Empty : reader[i]);
                            }
                            catch (ArgumentException ex)
                            {

                                if (ex.Message != "")
                                    propriedades.Add(reader.GetName(i) + "_" + i, reader[i] == System.DBNull.Value ? string.Empty : reader[i]);
                            }
                        }
                        importacaoDetalhes.Add(propriedades);
                    }
                }

                conn.Close();

                return importacaoDetalhes;

            }
        }
    }
}
