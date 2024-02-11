namespace LR2_ASP_Zhyhlova
{
    public class Company
    {
        public string Name { get; set; }
        public int Employees { get; set; }

        public override string ToString()
        {
            return "Company: " + Name + " | Number of employees: " + Employees;
        }
    }
}