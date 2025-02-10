using InterfaceSegregation.Interface;

namespace InterfaceSegregation.Services
{
    public class RobotService : IRobotService
    {
        public void DoRobotThings()
        {
            Console.WriteLine("I am a bobot i can do this");
        }
    }
}
