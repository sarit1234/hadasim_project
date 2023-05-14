using Hadasim_2_part_1.Model;
using TodoApi.Models;
using Npgsql;

namespace Hadasim_2_part_1.AccessDataBase
{
    public static class AddAccess
    {
        public static void AddCompany_Vaccine(Company_Vaccine company_Vaccine)
        {
            Company_Vaccine ExistsCV = GetAccess.GetCompany_Vaccine(company_Vaccine.Id);
            if (ExistsCV==null)
            {
                NpgsqlConnection con;
                using (con = new NpgsqlConnection(@"server=localhost;port=5432;User Id=postgres;Password=325030268;Database=korona;"))
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Connected");
                        string insertQuery = "INSERT INTO public.\"company_vaccine\" (cv_id, \"name\") " +
                                    "VALUES (@company_vaccine_id, @name)";
                        using (var command = new NpgsqlCommand(insertQuery, con))
                        {
                            command.Parameters.AddWithValue("company_vaccine_id", company_Vaccine.Id);
                            command.Parameters.AddWithValue("name", company_Vaccine.Name);
                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine($"{rowsAffected} row(s) inserted.");
                        }

                    }
                    else
                    {
                       throw new Exception( "Can't connect to Database");

                    }
                }

            }
            else
            {
                throw new Exception("Id aleady exist");

            }

        }
        public static void AddNegative(Negative negative)
        {
            Positive positive = GetAccess.GetPositive(negative.Patient_Id);
            if (positive == null)
                throw new Exception("This patient was not found as positive");
            Negative ExistsN = GetAccess.GetNegative(negative.Patient_Id);
            if (ExistsN == null)
            {
                NpgsqlConnection con;
                using (con = new NpgsqlConnection(@"server=localhost;port=5432;User Id=postgres;Password=325030268;Database=korona;"))
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Connected");
                        string insertQuery = "INSERT INTO public.\"negative\" (p_id, \"recovery\") " +
                                    "VALUES (@patient_id, @recovery)";
                        using (var command = new NpgsqlCommand(insertQuery, con))
                        {
                            command.Parameters.AddWithValue("patient_id",negative.Patient_Id);
                            command.Parameters.AddWithValue("recovery", negative.Recovery);
                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine($"{rowsAffected} row(s) inserted.");
                        }

                    }
                    else
                    {
                        throw new Exception("Can't connect to Database");

                    }
                }

            }
            else
            {
                throw new Exception("Id patient aleady exist");

            }
        }

        public static void AddPositive(Positive positive)
        {
            Patient ExistsP = GetAccess.GetPatient(positive.Patient_Id);
            if (ExistsP == null)
                throw new Exception("Patient with such an id doesn't exists");
            Positive ExistsN = GetAccess.GetPositive(positive.Patient_Id);
            if (ExistsN == null)
            {
                NpgsqlConnection con;
                using (con = new NpgsqlConnection(@"server=localhost;port=5432;User Id=postgres;Password=325030268;Database=korona;"))
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Connected");
                        string insertQuery = "INSERT INTO public.\"positive\" (p_id, \"diagnosed\") " +
                                    "VALUES (@patient_id, @diagnosed)";
                        using (var command = new NpgsqlCommand(insertQuery, con))
                        {
                            command.Parameters.AddWithValue("patient_id", positive.Patient_Id);
                            command.Parameters.AddWithValue("diagnosed", positive.Diagnosed);
                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine($"{rowsAffected} row(s) inserted.");
                        }

                    }
                    else
                    {
                        throw new Exception("Can't connect to Database");

                    }
                }

            }
            else
            {
                throw new Exception("Id patient aleady exist");

            }
        }

        public static void AddPatient(Patient patient)
        {
            Patient ExistsP = GetAccess.GetPatient(patient.Id);
            if (ExistsP == null)
            {
                NpgsqlConnection con;
                using (con = new NpgsqlConnection(@"server=localhost;port=5432;User Id=postgres;Password=325030268;Database=korona;"))
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Connected");
                        string insertQuery = "INSERT INTO public.\"patient\" (p_id, \"name\",\"address\",\"birthdate\",\"tphone\",\"pphone\") " +
                                    "VALUES (@patient_id, @patient_name, @patient_address,@patient_birthdate, @patient_tphone, @patient_pphone)";
                        using (var command = new NpgsqlCommand(insertQuery, con))
                        {
                            command.Parameters.AddWithValue("patient_id", patient.Id);
                            command.Parameters.AddWithValue("patient_name", patient.Name);
                            command.Parameters.AddWithValue("patient_address", patient.Address);
                            command.Parameters.AddWithValue("patient_birthdate", patient.BirthDate);
                            command.Parameters.AddWithValue("patient_tphone", patient.Tphone);
                            command.Parameters.AddWithValue("patient_pphone", patient.Pphone);

                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine($"{rowsAffected} row(s) inserted.");
                        }

                    }
                    else
                    {
                        throw new Exception("Can't connect to Database");

                    }
                }

            }
            else
            {
                throw new Exception("Id patient aleady exist");

            }
        }

        public static void AddVaccination(Vaccination vaccination)
        {
            Patient patient = GetAccess.GetPatient(vaccination.Patient_Id);
            if (patient == null)
                throw new Exception("Id patient not exist");
            int ExistsV = GetAccess.GetVaccination(vaccination.Patient_Id).Count();
            if (ExistsV < 4)
            {
                NpgsqlConnection con;
                using (con = new NpgsqlConnection(@"server=localhost;port=5432;User Id=postgres;Password=325030268;Database=korona;"))
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Connected");
                        string insertQuery = "INSERT INTO public.\"vaccination\" (p_id, \"accept\",\"vc_id\") " +
                                    "VALUES (@patient_id, @vaccination_accept, @company_id)";
                        using (var command = new NpgsqlCommand(insertQuery, con))
                        {
                            command.Parameters.AddWithValue("patient_id", vaccination.Patient_Id);
                            command.Parameters.AddWithValue("vaccination_accept", vaccination.Accept);
                            command.Parameters.AddWithValue("company_id", vaccination.Company_Vaccine_Id);
                            ;

                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine($"{rowsAffected} row(s) inserted.");
                        }

                    }
                    else
                    {
                        throw new Exception("Can't connect to Database");

                    }
                }

            }
            else
            {
                throw new Exception("There are already 4 vaccinations fo this patient");

            }

        }


    }
}
