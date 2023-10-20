using Lab01Lib;

namespace Lab01WebAPI.DAL
{
    public class SubjectDAO
    {
        public static List<Subject> sList = new List<Subject>() 
        {
            new Subject{Code="7023-EJA", Name="Emerging Jobs Areas", Fee=27360000},
            new Subject{Code="7023-ENJS", Name="Essentials of NodeJS", Fee=27360000},
            new Subject{Code="7023-WDA", Name="Web Developing using ASP.NET MVC", Fee=4560000},
        };
        public SubjectDAO() { }
        public static List<Subject> GetSubjects() 
        { 
            return sList; 
        }
        public static void saveSubject(Subject newSubject)
        {
            sList.Add(newSubject);
        }
        public static bool deleteSubject(string code) 
        {
            var subject = sList.FirstOrDefault(s => s.Code == code);
            if (subject != null) 
            {
                sList.Remove(subject);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
