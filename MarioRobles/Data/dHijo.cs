using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace Data
{
    public class dHijo : Conexion
    {
        public eResponse sp_Hijo_insert(Hijo hijo)
        {
            eResponse response = new eResponse();
            try
            {
                SqlParameter[] pr = new SqlParameter[11];
                pr[0] = new SqlParameter("msj", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                pr[1] = new SqlParameter("idHijo", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                pr[2] = new SqlParameter("idPersonal", SqlDbType.Int)
                {
                    Value = hijo.idPersonal
                };
                pr[3] = new SqlParameter("TipoDoc", SqlDbType.VarChar, 10)
                {
                    Value = hijo.TipoDoc
                };
                pr[4] = new SqlParameter("NumeroDoc", SqlDbType.VarChar, 10)
                {
                    Value = hijo.NumeroDoc
                };
                pr[5] = new SqlParameter("ApPaterno", SqlDbType.VarChar, 50)
                {
                    Value = hijo.ApPaterno
                };
                pr[6] = new SqlParameter("ApMaterno", SqlDbType.VarChar, 50)
                {
                    Value = hijo.ApMaterno
                };
                pr[7] = new SqlParameter("Nombre1", SqlDbType.VarChar, 50)
                {
                    Value = hijo.Nombre1
                };
                pr[8] = new SqlParameter("Nombre2", SqlDbType.VarChar, 50)
                {
                    Value = hijo.Nombre2
                };
                if (hijo.Nombre2 == null) pr[8].Value = DBNull.Value;
                pr[9] = new SqlParameter("NombreCompleto", SqlDbType.VarChar, 300)
                {
                    Value = hijo.NombreCompleto
                };
                pr[10] = new SqlParameter("FechaNac", SqlDbType.Date)
                {
                    Value = hijo.FechaNac
                };

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ObjCn;
                cmd.Parameters.AddRange(pr);
                cmd.CommandText = "sp_Hijo_insert";
                cmd.CommandType = CommandType.StoredProcedure;

                ObjCn.Open();
                cmd.ExecuteNonQuery();

                if (pr[0].Value != null && pr[0].Value.ToString() != "")
                {
                    response.code = 3;
                    response.mensaje = pr[0].Value.ToString();
                    return response;
                }

                hijo.idHijo = int.Parse(pr[1].Value.ToString());
                response.data = hijo;
                response.code = 1;
                response.mensaje = "SUCCESS";
            }
            catch (Exception e)
            {
                response.code = 2;
                response.mensaje = e.Message;
            }
            finally
            {
                ObjCn.Close();
            }
            return response;
        }

        public eResponse sp_Hijo_select()
        {
            eResponse response = new eResponse();
            List<Hijo> list = new List<Hijo>();
            try
            {
                SqlParameter[] pr = new SqlParameter[1];
                pr[0] = new SqlParameter("msj", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ObjCn;
                cmd.Parameters.AddRange(pr);
                cmd.CommandText = "sp_Hijo_select";
                cmd.CommandType = CommandType.StoredProcedure;

                ObjCn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (pr[0].Value != null && pr[0].Value.ToString() != "")
                {
                    response.code = 3;
                    response.mensaje = pr[0].Value.ToString();
                    return response;
                }

                while (reader.Read())
                {
                    Hijo hijo = new Hijo();
                    hijo.idHijo = reader.GetInt32("idHijo");
                    hijo.idPersonal = reader.GetInt32("idPersonal");
                    hijo.TipoDoc = reader.GetString("TipoDoc");
                    hijo.NumeroDoc = reader.GetString("NumeroDoc");
                    hijo.ApPaterno = reader.GetString("ApPaterno");
                    hijo.ApMaterno = reader.GetString("ApMaterno");
                    hijo.Nombre1 = reader.GetString("Nombre1");
                    hijo.Nombre2 = reader.IsDBNull("Nombre2") ? String.Empty : reader.GetString("Nombre2");
                    hijo.FechaNac = reader.GetDateTime("FechaNac");
                    list.Add(hijo);
                }
                reader.Close();

                response.data = list;
                response.code = 1;
                response.mensaje = "SUCCESS";
            }
            catch (Exception e)
            {
                response.code = 2;
                response.mensaje = e.Message;
            }
            finally
            {
                ObjCn.Close();
            }
            return response;
        }

        public eResponse sp_Hijo_select_by_id(int idHijo)
        {
            eResponse response = new eResponse();
            try
            {
                SqlParameter[] pr = new SqlParameter[2];
                pr[0] = new SqlParameter("msj", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                pr[1] = new SqlParameter("idHijo", SqlDbType.Int)
                {
                    Value = idHijo
                };

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ObjCn;
                cmd.Parameters.AddRange(pr);
                cmd.CommandText = "sp_Hijo_select_by_id";
                cmd.CommandType = CommandType.StoredProcedure;

                ObjCn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (pr[0].Value != null && pr[0].Value.ToString() != "")
                {
                    response.code = 3;
                    response.mensaje = pr[0].Value.ToString();
                    return response;
                }

                reader.Read();
                
                Hijo hijo = new Hijo();
                hijo.idHijo = reader.GetInt32("idHijo");
                hijo.idPersonal = reader.GetInt32("idPersonal");
                hijo.TipoDoc = reader.GetString("TipoDoc");
                hijo.NumeroDoc = reader.GetString("NumeroDoc");
                hijo.ApPaterno = reader.GetString("ApPaterno");
                hijo.ApMaterno = reader.GetString("ApMaterno");
                hijo.Nombre1 = reader.GetString("Nombre1");
                hijo.Nombre2 = reader.IsDBNull("Nombre2") ? String.Empty : reader.GetString("Nombre2");
                hijo.FechaNac = reader.GetDateTime("FechaNac");
                
                reader.Close();

                response.data = hijo;
                response.code = 1;
                response.mensaje = "SUCCESS";
            }
            catch (Exception e)
            {
                response.code = 2;
                response.mensaje = e.Message;
            }
            finally
            {
                ObjCn.Close();
            }
            return response;
        }

        public eResponse sp_Hijo_select_by_personal(int idPersonal)
        {
            eResponse response = new eResponse();
            List<Hijo> list = new List<Hijo>();
            try
            {
                SqlParameter[] pr = new SqlParameter[2];
                pr[0] = new SqlParameter("msj", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                pr[1] = new SqlParameter("idPersonal", SqlDbType.Int)
                {
                    Value = idPersonal
                };

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ObjCn;
                cmd.Parameters.AddRange(pr);
                cmd.CommandText = "sp_Hijo_select_by_personal";
                cmd.CommandType = CommandType.StoredProcedure;

                ObjCn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (pr[0].Value != null && pr[0].Value.ToString() != "")
                {
                    response.code = 3;
                    response.mensaje = pr[0].Value.ToString();
                    return response;
                }

                while (reader.Read())
                {
                    Hijo hijo = new Hijo();
                    hijo.idHijo = reader.GetInt32("idHijo");
                    hijo.idPersonal = reader.GetInt32("idPersonal");
                    hijo.TipoDoc = reader.GetString("TipoDoc");
                    hijo.NumeroDoc = reader.GetString("NumeroDoc");
                    hijo.ApPaterno = reader.GetString("ApPaterno");
                    hijo.ApMaterno = reader.GetString("ApMaterno");
                    hijo.Nombre1 = reader.GetString("Nombre1");
                    hijo.Nombre2 = reader.IsDBNull("Nombre2") ? String.Empty : reader.GetString("Nombre2");
                    hijo.FechaNac = reader.GetDateTime("FechaNac");
                    list.Add(hijo);
                }
                reader.Close();

                response.data = list;
                response.code = 1;
                response.mensaje = "SUCCESS";
            }
            catch (Exception e)
            {
                response.code = 2;
                response.mensaje = e.Message;
            }
            finally
            {
                ObjCn.Close();
            }
            return response;
        }

        public eResponse sp_Hijo_delete(int idHijo)
        {
            eResponse response = new eResponse();
            try
            {
                SqlParameter[] pr = new SqlParameter[2];
                pr[0] = new SqlParameter("msj", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                pr[1] = new SqlParameter("idHijo", SqlDbType.Int)
                {
                    Value = idHijo
                };

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ObjCn;
                cmd.Parameters.AddRange(pr);
                cmd.CommandText = "sp_Hijo_delete";
                cmd.CommandType = CommandType.StoredProcedure;

                ObjCn.Open();
                cmd.ExecuteNonQuery();

                if (pr[0].Value != null && pr[0].Value.ToString() != "")
                {
                    response.code = 3;
                    response.mensaje = pr[0].Value.ToString();
                    return response;
                }
                response.code = 1;
                response.mensaje = "SUCCESS";
            }
            catch (Exception e)
            {
                response.code = 2;
                response.mensaje = e.Message;
            }
            finally
            {
                ObjCn.Close();
            }
            return response;
        }

        public eResponse sp_Hijo_update(Hijo hijo)
        {
            eResponse response = new eResponse();
            try
            {
                SqlParameter[] pr = new SqlParameter[11];
                pr[0] = new SqlParameter("msj", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                pr[1] = new SqlParameter("idHijo", SqlDbType.Int)
                {
                    Value = hijo.idHijo
                };
                pr[2] = new SqlParameter("idPersonal", SqlDbType.Int)
                {
                    Value = hijo.idPersonal
                };
                pr[3] = new SqlParameter("TipoDoc", SqlDbType.VarChar, 10)
                {
                    Value = hijo.TipoDoc
                };
                pr[4] = new SqlParameter("NumeroDoc", SqlDbType.VarChar, 10)
                {
                    Value = hijo.NumeroDoc
                };
                pr[5] = new SqlParameter("ApPaterno", SqlDbType.VarChar, 50)
                {
                    Value = hijo.ApPaterno
                };
                pr[6] = new SqlParameter("ApMaterno", SqlDbType.VarChar, 50)
                {
                    Value = hijo.ApMaterno
                };
                pr[7] = new SqlParameter("Nombre1", SqlDbType.VarChar, 50)
                {
                    Value = hijo.Nombre1
                };
                pr[8] = new SqlParameter("Nombre2", SqlDbType.VarChar, 50)
                {
                    Value = hijo.Nombre2
                };
                if (hijo.Nombre2 == null) pr[8].Value = DBNull.Value;
                pr[9] = new SqlParameter("NombreCompleto", SqlDbType.VarChar, 300)
                {
                    Value = hijo.NombreCompleto
                };
                pr[10] = new SqlParameter("FechaNac", SqlDbType.Date)
                {
                    Value = hijo.FechaNac
                };

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ObjCn;
                cmd.Parameters.AddRange(pr);
                cmd.CommandText = "sp_Hijo_update";
                cmd.CommandType = CommandType.StoredProcedure;

                ObjCn.Open();
                cmd.ExecuteNonQuery();

                if (pr[0].Value != null && pr[0].Value.ToString() != "")
                {
                    response.code = 3;
                    response.mensaje = pr[0].Value.ToString();
                    return response;
                }

                response.data = hijo;
                response.code = 1;
                response.mensaje = "SUCCESS";
            }
            catch (Exception e)
            {
                response.code = 2;
                response.mensaje = e.Message;
            }
            finally
            {
                ObjCn.Close();
            }
            return response;
        }
    }
}
