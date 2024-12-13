namespace Database_Milestone3
{
    internal class SqlParameters
    {
        private string v;
        private string pass;

        public SqlParameters(string v, int id)
        {
        }

        public SqlParameters(string v, string pass)
        {
            this.v = v;
            this.pass = pass;
        }
    }
}