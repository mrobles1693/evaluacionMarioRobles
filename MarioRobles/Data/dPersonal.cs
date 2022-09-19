using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace Data
{
    public class dPersonal : Conexion
    {
        public eResponse sp_Personal_insert(Personal personal)
        {
            eResponse response = new eResponse();
            try
            {
                SqlParameter[] pr = new SqlParameter[11];
                pr[0] = new SqlParameter("msj", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                pr[1] = new SqlParameter("idPersonal", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                pr[2] = new SqlParameter("TipoDoc", SqlDbType.VarChar, 10)
                {
                    Value = personal.TipoDoc
                };
                pr[3] = new SqlParameter("NumeroDoc", SqlDbType.VarChar, 10)
                {
                    Value = personal.NumeroDoc
                };
                pr[4] = new SqlParameter("ApPaterno", SqlDbType.VarChar, 50)
                {
                    Value = personal.ApPaterno
                };
                pr[5] = new SqlParameter("ApMaterno", SqlDbType.VarChar, 50)
                {
                    Value = personal.ApMaterno
                };
                pr[6] = new SqlParameter("Nombre1", SqlDbType.VarChar, 50)
                {
                    Value = personal.Nombre1
                };
                pr[7] = new SqlParameter("Nombre2", SqlDbType.VarChar, 50)
                {
                    Value = personal.Nombre2
                };
                if (personal.Nombre2 == null) pr[7].Value = DBNull.Value;
                pr[8] = new SqlParameter("NombreCompleto", SqlDbType.VarChar, 300)
                {
                    Value = personal.NombreCompleto
                };
                pr[9] = new SqlParameter("FechaNac", SqlDbType.Date)
                {
                    Value = personal.FechaNac
                };
                pr[10] = new SqlParameter("FechaIngreso", SqlDbType.Date)
                {
                    Value = personal.FechaIngreso
                };

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ObjCn;
                cmd.Parameters.AddRange(pr);
                cmd.CommandText = "sp_Personal_insert";
                cmd.CommandType = CommandType.StoredProcedure;

                ObjCn.Open();
                cmd.ExecuteNonQuery();

                if (pr[0].Value != null && pr[0].Value.ToString() != "")
                {
                    response.code = 3;
                    response.mensaje = pr[0].Value.ToString();
                    return response;
                }

                personal.idPersonal = int.Parse(pr[1].Value.ToString());
                response.data = personal;
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

        public eResponse sp_Personal_select()
        {
            eResponse response = new eResponse();
            List<Personal> list = new List<Personal>();
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
                cmd.CommandText = "sp_Personal_select";
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
                    Personal personal = new Personal();
                    personal.idPersonal = reader.GetInt32("idPersonal");
                    personal.TipoDoc = reader.GetString("TipoDoc");
                    personal.NumeroDoc = reader.GetString("NumeroDoc");
                    personal.ApPaterno = reader.GetString("ApPaterno");
                    personal.ApMaterno = reader.GetString("ApMaterno");
                    personal.Nombre1 = reader.GetString("Nombre1");
                    personal.Nombre2 = reader.IsDBNull("Nombre2") ? String.Empty : reader.GetString("Nombre2");
                    personal.FechaNac = reader.GetDateTime("FechaNac");
                    personal.FechaIngreso = reader.GetDateTime("FechaIngreso");
                    list.Add(personal);
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

        public eResponse sp_Personal_select_by_id(int idPersonal)
        {
            eResponse response = new eResponse();
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
                cmd.CommandText = "sp_Personal_select_by_id";
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
                
                Personal personal = new Personal();
                personal.idPersonal = reader.GetInt32("idPersonal");
                personal.TipoDoc = reader.GetString("TipoDoc");
                personal.NumeroDoc = reader.GetString("NumeroDoc");
                personal.ApPaterno = reader.GetString("ApPaterno");
                personal.ApMaterno = reader.GetString("ApMaterno");
                personal.Nombre1 = reader.GetString("Nombre1");
                personal.Nombre2 = reader.IsDBNull("Nombre2") ? String.Empty : reader.GetString("Nombre2");
                personal.FechaNac = reader.GetDateTime("FechaNac");
                personal.FechaIngreso = reader.GetDateTime("FechaIngreso");
                
                reader.Close();

                response.data = personal;
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

        public eResponse sp_Personal_delete(int idPersonal)
        {
            eResponse response = new eResponse();
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
                cmd.CommandText = "sp_Personal_delete";
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

        public eResponse sp_Personal_update(Personal personal)
        {
            eResponse response = new eResponse();
            try
            {
                SqlParameter[] pr = new SqlParameter[11];
                pr[0] = new SqlParameter("msj", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                pr[1] = new SqlParameter("idPersonal", SqlDbType.Int)
                {
                    Value = personal.idPersonal
                };
                pr[2] = new SqlParameter("TipoDoc", SqlDbType.VarChar, 10)
                {
                    Value = personal.TipoDoc
                };
                pr[3] = new SqlParameter("NumeroDoc", SqlDbType.VarChar, 10)
                {
                    Value = personal.NumeroDoc
                };
                pr[4] = new SqlParameter("ApPaterno", SqlDbType.VarChar, 50)
                {
                    Value = personal.ApPaterno
                };
                pr[5] = new SqlParameter("ApMaterno", SqlDbType.VarChar, 50)
                {
                    Value = personal.ApMaterno
                };
                pr[6] = new SqlParameter("Nombre1", SqlDbType.VarChar, 50)
                {
                    Value = personal.Nombre1
                };
                pr[7] = new SqlParameter("Nombre2", SqlDbType.VarChar, 50)
                {
                    Value = personal.Nombre2
                };
                if (personal.Nombre2 == null) pr[7].Value = DBNull.Value;
                pr[8] = new SqlParameter("NombreCompleto", SqlDbType.VarChar, 300)
                {
                    Value = personal.NombreCompleto
                };
                pr[9] = new SqlParameter("FechaNac", SqlDbType.Date)
                {
                    Value = personal.FechaNac
                };
                pr[10] = new SqlParameter("FechaIngreso", SqlDbType.Date)
                {
                    Value = personal.FechaIngreso
                };

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ObjCn;
                cmd.Parameters.AddRange(pr);
                cmd.CommandText = "sp_Personal_update";
                cmd.CommandType = CommandType.StoredProcedure;

                ObjCn.Open();
                cmd.ExecuteNonQuery();

                if (pr[0].Value != null && pr[0].Value.ToString() != "")
                {
                    response.code = 3;
                    response.mensaje = pr[0].Value.ToString();
                    return response;
                }

                response.data = personal;
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
