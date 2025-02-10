using InterfaceSegregation.Interface;

namespace InterfaceSegregation.Services
{
    public class RobotChefService : RobotService, IChefRobotService
    {
        public void Cook()
        {
            Console.WriteLine("I can cook");
        }
    }
}