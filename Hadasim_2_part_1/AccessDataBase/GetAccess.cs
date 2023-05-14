using Hadasim_2_part_1.Model;
using Npgsql;
using System.Collections.Generic;
using TodoApi.Models;

namespace Hadasim_2_part_1.AccessDataBase
{
    public static class GetAccess
    {
        public static Company_Vaccine GetCompany_Vaccine(int id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;User Id=postgres;Password=325030268;Database=korona;"))
            {
                con.Open();

                string query = $"SELECT * FROM public.company_vaccine WHERE cv_id = @Id;";
                using (NpgsqlCommand command = new NpgsqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Company_Vaccine company_Vaccine = new Company_Vaccine
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };

                            return company_Vaccine;
                        }
                    }
                }
            }
            return null;
        }
        public static Negative GetNegative(int id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;User Id=postgres;Password=325030268;Database=korona;"))
            {
                con.Open();

                string query = $"SELECT * FROM public.negative WHERE p_id = @Id;";
                using (NpgsqlCommand command = new NpgsqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Negative negative = new Negative
                            {
                                Id = reader.GetInt32(0),
                                Patient_Id = reader.GetInt32(1),
                                Recovery = reader.GetDateTime(2)
                            };

                            return negative;
                        }
                    }
                }
            }
            return null;
        }
        public static Positive GetPositive(int id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;User Id=postgres;Password=325030268;Database=korona;"))
            {
                con.Open();

                string query = $"SELECT * FROM public.positive WHERE p_id = @Id;";
                using (NpgsqlCommand command = new NpgsqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Positive positive = new Positive
                            {
                                Id = reader.GetInt32(0),
                                Patient_Id = reader.GetInt32(1),
                                Diagnosed= reader.GetDateTime(2)
                            };

                            return positive;
                        }
                    }
                }
            }
            return null;
        }

        public static Patient GetPatient(int id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;User Id=postgres;Password=325030268;Database=korona;"))
            {
                con.Open();

                string query = $"SELECT * FROM public.patient WHERE p_id = @Id;";
                using (NpgsqlCommand command = new NpgsqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Patient patient = new Patient
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2),
                                BirthDate = reader.GetDateTime(3),
                                Tphone = reader.GetString(4),
                                Pphone = reader.GetString(5)
                            };

                            return patient;
                        }
                    }
                }
            }
            return null;
        }

        public static List<Vaccination> GetVaccination(int id)
        {
            List<Vaccination> vaccinations = new List<Vaccination>();
            using (NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;User Id=postgres;Password=325030268;Database=korona;"))
            {
                con.Open();
               

                string query = $"SELECT * FROM public.vaccination WHERE p_id = @Id;";
                using (NpgsqlCommand command = new NpgsqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Vaccination vaccination = new Vaccination
                            {
                                Id = reader.GetInt32(0),
                                Patient_Id = reader.GetInt32(1),
                                Accept= reader.GetDateTime(2),
                                Company_Vaccine_Id = reader.GetInt32(3)
                            };

                            vaccinations.Add(vaccination);
                        }
                    }
                }
            }
            return vaccinations;

        }


    }
}

