namespace LR2_ASP_Zhyhlova
{
    public class AboutMyself
    {
        public AboutMyself(string name, int age, string education)
        {
            Name = name;
            Age = age;
            Education = education;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Education { get; set; }

        public override string ToString()
        {
            return "Name: " + Name + " | Age: " + Age + " | Education: " + Education;
        }
    }
}
