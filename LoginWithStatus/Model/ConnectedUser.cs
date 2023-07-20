namespace LoginWithStatus.Model
{
    public class ConnectedUser
    {
       List<User> users = new List<User>();     
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
