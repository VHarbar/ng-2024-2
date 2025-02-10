using SingleResponsibility;

namespace LiskovSubstitution
{
    public class RobotService
    {

        public RobotService() 
        {
            var subChef = new RobotSubChef();

            DoAMeal(subChef);

            var chef = new RobotChef();

            DoAMeal(chef);
        }

        public void DoAMeal(RobotSubChef robot)
        {
            robot.Cook();
        }
    }
}
