namespace Hadasim_2_part_1.Model
{
    public class Vaccination
    {       
        public int Id { get; set; }
        public int Patient_Id { get; set; }
        public DateTime Accept { get; set; }
        public int Company_Vaccine_Id { get; set; }
    }
}
