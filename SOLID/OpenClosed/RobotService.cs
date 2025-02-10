namespace OpenClosed
{
    public class RobotService
    {
        //private bool _isReadyForCooking = false;

        public void DoThings()
        {
            Cook();

            Drive();

            CutGarden();
        }

        public void Cook() { }
        public void Drive() { }
        public void CutGarden() { }

        //public void DoThings()
        //{
        //    if (_isReadyForCooking)
        //    {
        //        Cook();
        //        _isReadyForCooking = false;
        //    }
        //    else
        //    {
        //        Drive();
        //        _isReadyForCooking = true;
        //    }
        //}
        //
        //public void Cook() { }
        //public void Drive() { }
    }
}
