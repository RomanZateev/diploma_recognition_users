namespace Recognition
{
    public class UserСomparison
    {
        private string realUser { get; set; }

        private string recognizeduser { get; set; }

        public bool Correctness()
        {
            if (realUser.Equals(recognizeduser))
                return true;
            else
                return false;
        }

        public bool FAR()
        {
            if (!(realUser.Equals(recognizeduser) || recognizeduser.Equals("unknown")))
                return true;
            else
                return false;
        }

        public bool FRR()
        {
            if (recognizeduser.Equals("unknown"))
                return true;
            else
                return false;
        }

        public UserСomparison()
        {

        }

        public UserСomparison(string _realUser, string _recognizedUser)
        {
            this.realUser = _realUser;
            this.recognizeduser = _recognizedUser;
        }
    }
}
