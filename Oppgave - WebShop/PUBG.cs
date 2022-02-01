namespace Oppgave___WebShop
{
    public class PUBG : Game, IDownloadable, IShippable
    {
        public PUBG()
        {
            GameName = "Player unknown battlegrounds";
            Id = "4";
            Price = 100;
        }
    }
}